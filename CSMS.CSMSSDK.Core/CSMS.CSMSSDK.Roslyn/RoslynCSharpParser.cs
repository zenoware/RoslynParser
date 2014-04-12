/*******************************************************************
Information: Copyright 2014 Zenoware

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at

    http://www.apache.org/licenses/LICENSE-2.0

Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*******************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using CSMS.CSMSSDK.Model;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.CSharp;

namespace CSMS.CSMSSDK.Roslyn
{
    public class RoslynCSharpParser
    {
        private SyntaxTree mTree;
        private CompilationUnitSyntax mRoot;
        public Model.ParsingResults ParseSource(string filename)
        {
            try
            {
                mTree = CSharpSyntaxTree.ParseFile(filename);
                mRoot = (CompilationUnitSyntax)mTree.GetRoot();
            }
            catch
            {
                throw;
            }
            return Model.ParsingResults.Success;
        }

        public Namespace TraverseTree()
        {
            Namespace retNS = new Namespace();

            //Get using statements first
            List<UsingList> usingList = TraverseUsingList();
            retNS.UsingList = usingList;
            //Next, traverse namespaces
            var ns = from aNS in mRoot.ChildNodes().OfType<NamespaceDeclarationSyntax>() select aNS;
            foreach (NamespaceDeclarationSyntax nds in ns)
            {
                Namespace aNS = TraverseNamespace(nds);
                aNS.UsingList = usingList;
                retNS.Namespaces.Add(aNS);
            }
            //TODO check if this needs to be declaration rather than declarator
            var vars = from aVar in mRoot.ChildNodes().OfType<VariableDeclaratorSyntax>() select aVar;
            foreach (VariableDeclaratorSyntax vds in vars)
            {
                Method tempMethod = TraverseVarDeclarators(vds);
                retNS.Attributes.AddRange(tempMethod.AccessedVariables);
            }
            var classes = from aClass in mRoot.ChildNodes().OfType<ClassDeclarationSyntax>() select aClass;
            foreach (ClassDeclarationSyntax cds in classes)
            {
                Class tempClass = TraverseClass(cds);
                retNS.Classes.Add(tempClass);
            }
            //public List<Class> ClassPrototypes { get; set; }
            var constructors = from aConstructor in mRoot.ChildNodes().OfType<ConstructorDeclarationSyntax>() select aConstructor;
            foreach (ConstructorDeclarationSyntax cds in constructors)
            {
                Constructor tempConstructor = TransverseConstructors(cds);
                retNS.Constructors.Add(tempConstructor);
            }
            var delegates = from aDelegate in mRoot.ChildNodes().OfType<DelegateDeclarationSyntax>() select aDelegate;
            foreach (DelegateDeclarationSyntax dds in delegates)
            {
                Model.Delegate tempDelegate = TraverseDelegates(dds);
                retNS.Delegates.Add(tempDelegate);
            }
            var destructors = from aDestructor in mRoot.ChildNodes().OfType<DestructorDeclarationSyntax>() select aDestructor;
            foreach (DestructorDeclarationSyntax dds in destructors)
            {
                Destructor tempDestructor = TransverseDestructors(dds);
                retNS.Destructors.Add(tempDestructor);
            }
            var enums = from aEnum in mRoot.ChildNodes().OfType<EnumDeclarationSyntax>() select aEnum;
            foreach (EnumDeclarationSyntax eds in enums)
            {
                Model.Enum tempEnum = TraverseEnums(eds);
                retNS.Enums.Add(tempEnum);
            }
            //TODO find the difference between funcdefs and methods
            var methods = from aMethod in mRoot.ChildNodes().OfType<MethodDeclarationSyntax>() select aMethod;
            foreach (MethodDeclarationSyntax mds in methods)
            {
                Method tempMethod = TransverseMethods(mds);
                retNS.Methods.Add(tempMethod);
                retNS.FunctionDefs.Add(tempMethod);
            }
            var interfaces = from aInterface in mRoot.ChildNodes().OfType<InterfaceDeclarationSyntax>() select aInterface;
            foreach (InterfaceDeclarationSyntax ids in interfaces)
            {
                Interface tempInterface = TraverseInterface(ids);
                retNS.Interfaces.Add(tempInterface);
            }
            //public List<Module> Modules { get; set; }
            //public string Name { get; set; }
            //public List<Preprocessor> Preprocessors { get; set; }
            //public List<Qualifiers> Qualifiers { get; set; }
            //public List<Struct> StructPrototypes { get; set; }
            var structs = from aStruct in mRoot.ChildNodes().OfType<StructDeclarationSyntax>() select aStruct;
            foreach (StructDeclarationSyntax sds in structs)
            {
                Struct tempStruct = TransverseStructs(sds);
                retNS.Structs.Add(tempStruct);
            }
            //public List<Union> Unions { get; set; }
            return retNS;
        }

        private Model.Delegate TraverseDelegates(DelegateDeclarationSyntax dds)
        {
            Model.Delegate retDel = new Model.Delegate();
            return retDel;
        }

        private Namespace TraverseNamespace(NamespaceDeclarationSyntax nds)
        {
            Namespace retNS = new Namespace();

            retNS.Name = nds.Name.ToString();

            //First, grab any objects defined at the beginning of the namespace (even delegates!)
            var delegates = from aDelegate in nds.ChildNodes().OfType<DelegateDeclarationSyntax>() select aDelegate;
            foreach (DelegateDeclarationSyntax dds in delegates)
            {
                //TraverseDelegate
            }

            //Next, traverse any classes
            var classes = from cls in nds.ChildNodes().OfType<ClassDeclarationSyntax>() select cls;
            foreach (ClassDeclarationSyntax cds in classes)
            {
                retNS.Classes.Add(TraverseClass(cds));
            }

            var interfaces = from anInterface in nds.ChildNodes().OfType<InterfaceDeclarationSyntax>() select anInterface;
            foreach (InterfaceDeclarationSyntax ids in interfaces)
            {
                Interface tempInterface = TraverseInterface(ids);
                retNS.Interfaces.Add(tempInterface);
            }
            var enums = from aEnum in nds.ChildNodes().OfType<EnumDeclarationSyntax>() select aEnum;
            foreach (EnumDeclarationSyntax eds in enums)
            {
                Model.Enum tempEnum = TraverseEnums(eds);
                retNS.Enums.Add(tempEnum);
            }
            //TODO: Don't forget enums
            return retNS;
        }

        private string QualifiedName(QualifiedNameSyntax qns)
        {
            string qName = "";
            ChildSyntaxList idn = qns.ChildNodesAndTokens();
            foreach(SyntaxNodeOrToken snot in idn.ToArray())
            {
                if (snot.IsToken)
                {
                    SyntaxToken st = (SyntaxToken)snot;
                    if (st.IsKind(SyntaxKind.IdentifierToken))
                    {
                        qName += st.ValueText;
                    }
                    else if (st.IsKind(SyntaxKind.DotToken))
                    {
                        qName += ".";
                    }
                }
            }
            return qName;
        }

        private List<UsingList> TraverseUsingList()
        {
            List<UsingList> retUL = new List<UsingList>();
            var usings = (SyntaxList<UsingDirectiveSyntax>)mRoot.Usings;
            foreach (UsingDirectiveSyntax uds in usings)
            {
                UsingList ul = new UsingList();
                ul.LibName = uds.Name.ToString();
                ul.Identifier = ""; //??
            }

            return retUL;
        }

        public Class TraverseClass(ClassDeclarationSyntax cds)
        {
            Class retClass = new Class();
        //public List<Delegate> Delegates { get; set; }
        //public List<Method> FunctionDefs { get; set; }
        //public Inheritance Inheritance { get; set; }
        //public List<Module> Modules { get; set; }
        //public List<Preprocessor> Preprocessors { get; set; }
        //public List<Property> Properties { get; set; }
        //public List<Union> Unions { get; set; }
            retClass.Name = cds.Identifier.ValueText;
            foreach (SyntaxToken st in cds.Modifiers)
            {
                string modifier = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(st.ValueText);
                Encapsulation encap;
                Qualifiers qual;
                if (System.Enum.TryParse<Encapsulation>( modifier, out encap))
                {
                    retClass.Encapsulation.Add(encap);
                }
                else if (System.Enum.TryParse<Qualifiers>(modifier, out qual))
                {
                    retClass.Qualifiers.Add(qual);
                }
            }

            var enums = from aEnu in cds.ChildNodes().OfType<EnumDeclarationSyntax>() select aEnu;
            foreach (EnumDeclarationSyntax eds in enums)
            {
                retClass.Enums.Add(TraverseEnums(eds));
            }

            var structs = from aStruct in cds.ChildNodes().OfType<StructDeclarationSyntax>() select aStruct;
            foreach (StructDeclarationSyntax sds in structs)
            {
                retClass.Structs.Add(TransverseStructs(sds));
            }

            var methods = from aMethod in cds.ChildNodes().OfType<MethodDeclarationSyntax>() select aMethod;
            foreach (MethodDeclarationSyntax mds in methods)
            {
                retClass.Methods.Add(TransverseMethods(mds));
            }

            var Fields = from aField in cds.ChildNodes().OfType<FieldDeclarationSyntax>() select aField;
            foreach (FieldDeclarationSyntax fds in Fields)
            {
                retClass.Fields.Add(TransverseVariables(fds));
            }

            //var properties = from aProperty in cds.ChildNodes().OfType<PropertyDeclarationSyntax>() select aProperty;
            //foreach (PropertyDeclarationSyntax pds in properties)
            //{
            //    //traverse attributes
            //}

            var constructors = from aConstructor in cds.ChildNodes().OfType<ConstructorDeclarationSyntax>() select aConstructor;
            foreach (ConstructorDeclarationSyntax cods in constructors)
            {
                retClass.Constructors.Add(TransverseConstructors(cods));
            }

            var destructors = from aDestructor in cds.ChildNodes().OfType<DestructorDeclarationSyntax>() select aDestructor;
            foreach (DestructorDeclarationSyntax dds in destructors)
            {
                retClass.Destructors.Add(TransverseDestructors(dds));
            }

            var classes = from aClass in cds.ChildNodes().OfType<ClassDeclarationSyntax>() select aClass;
            foreach (ClassDeclarationSyntax cds2 in classes)
            {
                retClass.Classes.Add(TraverseClass(cds2));
            }

            return retClass;
        }
        /// <summary>
        /// Still needs work!
        /// </summary>
        /// <returns></returns>
        private Model.Enum TraverseEnums(EnumDeclarationSyntax eds)
        {
            Model.Enum retEnu = new Model.Enum();
            //public List<string> EnumItems { get; set; }
            //public string Name { get; set; }
            //public Type Type { get; set; }

            var types = from aType in eds.ChildNodes().OfType<TypeDeclarationSyntax>() select aType;
            foreach (TypeDeclarationSyntax tds in types)
            {
                //TODO put breakpoint here
                //to find out how to get types
            }
            foreach (SyntaxToken st in eds.Modifiers)
            {
                string modifier = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(st.ValueText);
                retEnu.Encapsulation.Add((Encapsulation)System.Enum.Parse(typeof(Encapsulation), modifier));
            }

            var enumItems = from aEnumItem in eds.ChildNodes().OfType<EnumMemberDeclarationSyntax>() select aEnumItem;
            foreach (EnumMemberDeclarationSyntax emds in enumItems)
            {
                //TODO put breakpoint here
                //to find out how to get enumitems
            }

            return retEnu;
        }

        private Struct TransverseStructs(StructDeclarationSyntax sds)
        {
            Struct retStruct = new Struct();
            //public List<Delegate> Delegates { get; set; }
            //public List<Method> FunctionDefs { get; set; }
            //public Inheritance Inheritance { get; set; }
            //public List<Module> Modules { get; set; }
            //public string Name { get; set; }
            //public List<Preprocessor> Preprocessors { get; set; }
            //public List<Property> Properties { get; set; }
            //public List<Union> Unions { get; set; }
            retStruct.Name = sds.Identifier.ValueText;
            foreach (SyntaxToken st in sds.Modifiers)
            {
                string modifier = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(st.ValueText);
                Encapsulation encap;
                Qualifiers qual;
                if (System.Enum.TryParse<Encapsulation>(modifier, out encap))
                {
                    retStruct.Encapsulation.Add(encap);
                }
                else if (System.Enum.TryParse<Qualifiers>(modifier, out qual))
                {
                    retStruct.Qualifiers.Add(qual);
                }
            }

            var enums = from aEnu in sds.ChildNodes().OfType<EnumDeclarationSyntax>() select aEnu;
            foreach (EnumDeclarationSyntax eds in enums)
            {
                retStruct.Enums.Add(TraverseEnums(eds));
            }

            var structs = from aStruct in sds.ChildNodes().OfType<StructDeclarationSyntax>() select aStruct;
            foreach (StructDeclarationSyntax sdecs in structs)
            {
                retStruct.Structs.Add(TransverseStructs(sdecs));
            }

            var methods = from aMethod in sds.ChildNodes().OfType<MethodDeclarationSyntax>() select aMethod;
            foreach (MethodDeclarationSyntax mds in methods)
            {
                retStruct.Methods.Add(TransverseMethods(mds));
            }

            var fields = from aField in sds.ChildNodes().OfType<FieldDeclarationSyntax>() select aField;
            foreach (FieldDeclarationSyntax fds in fields)
            {
                retStruct.Fields.Add(TransverseVariables(fds));
            }

            //var properties = from aProperty in sds.ChildNodes().OfType<PropertyDeclarationSyntax>() select aProperty;
            //foreach (PropertyDeclarationSyntax pds in properties)
            //{
            //    //traverse attributes
            //}

            var constructors = from aConstructor in sds.ChildNodes().OfType<ConstructorDeclarationSyntax>() select aConstructor;
            foreach (ConstructorDeclarationSyntax cods in constructors)
            {
                retStruct.Constructors.Add(TransverseConstructors(cods));
            }

            var destructors = from aDestructor in sds.ChildNodes().OfType<DestructorDeclarationSyntax>() select aDestructor;
            foreach (DestructorDeclarationSyntax dds in destructors)
            {
                retStruct.Destructors.Add(TransverseDestructors(dds));
            }

            var classes = from aClass in sds.ChildNodes().OfType<ClassDeclarationSyntax>() select aClass;
            foreach (ClassDeclarationSyntax sds2 in classes)
            {
                retStruct.Classes.Add(TraverseClass(sds2));
            }

            return retStruct;
        }
        
        //private object TransverseClassTypes(object classType)
        //{
        //    object retObj;
        //    if (classType is ClassDeclarationSyntax)
        //    {
        //        retObj = new Class();
        //        classType = classType as ClassDeclarationSyntax;
        //    }
        //    else if (classType is StructDeclarationSyntax)
        //    {
        //        retObj = new Struct();
        //        classType = classType as StructDeclarationSyntax;
        //    }
        //        //Class retObj = new Class();
        //        //Name
        //        (retObj is Class ? retObj as Class : retObj as Struct).Name = (classType is ClassDeclarationSyntax ? (ClassDeclarationSyntax)classType : (StructDeclarationSyntax)classType).Identifier.ValueText;
        //        //encapsulation
        //        foreach (SyntaxToken st in classType.Modifiers)
        //        {
        //            string modifier = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(st.ValueText);
        //            retObj.Encapsulation.Add((Encapsulation)System.Enum.Parse(typeof(Encapsulation), modifier));
        //        }

        //        var enums = from aEnu in classType.ChildNodes().OfType<EnumDeclarationSyntax>() select aEnu;
        //        foreach (EnumDeclarationSyntax eds in enums)
        //        {
        //            retObj.Enums.Add(TraverseEnums(eds));
        //        }

        //        var structs = from aStruct in classType.ChildNodes().OfType<StructDeclarationSyntax>() select aStruct;
        //        foreach (StructDeclarationSyntax sds in structs)
        //        {
        //            retObj.Structs.Add(TransverseStructs(sds));
        //        }

        //        var methods = from aMethod in classType.ChildNodes().OfType<MethodDeclarationSyntax>() select aMethod;
        //        foreach (MethodDeclarationSyntax mds in methods)
        //        {
        //            retObj.Methods.Add(TransverseMethods(mds));
        //        }

        //        var fields = from aField in classType.ChildNodes().OfType<FieldDeclarationSyntax>() select aField;
        //        foreach (FieldDeclarationSyntax fds in fields)
        //        {
        //            retObj.Attributes.Add(TransverseVariables(fds));
        //        }

        //        //var properties = from aProperty in classType.ChildNodes().OfType<PropertyDeclarationSyntax>() select aProperty;
        //        //foreach (PropertyDeclarationSyntax pds in properties)
        //        //{
        //        //    //traverse attributes
        //        //}

        //        var constructors = from aConstructor in classType.ChildNodes().OfType<ConstructorDeclarationSyntax>() select aConstructor;
        //        foreach (ConstructorDeclarationSyntax cods in constructors)
        //        {
        //            retObj.Constructors.Add(TransverseConstructors(cods));
        //        }

        //        var destructors = from aDestructor in classType.ChildNodes().OfType<DestructorDeclarationSyntax>() select aDestructor;
        //        foreach (DestructorDeclarationSyntax dds in destructors)
        //        {
        //            retObj.Destructors.Add(TransverseDestructors(dds));
        //        }

        //        var classes = from aClass in classType.ChildNodes().OfType<ClassDeclarationSyntax>() select aClass;
        //        foreach (ClassDeclarationSyntax classType2 in classes)
        //        {
        //            retObj.Classes.Add(TraverseClass(classType2));
        //        }

        //        return retObj;
        //}

        private Method TransverseMethods(MethodDeclarationSyntax mds)
        {
            Method retMethod = new Method();
            //public int DecisionsCount { get; }
            //public int ExitPoints { get; set; }
            //public bool IsFriend { get; }
            //public bool IsPolymophic { get; }
            //public bool IsPublic { get; }
            //public bool IsStatic { get; }
            //public List<Preprocessor> Preprocessors { get; set; }
            retMethod.Name = mds.Identifier.ValueText;

            foreach (SyntaxToken st in mds.Modifiers)
            {
                string modifier = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(st.ValueText);
                Encapsulation encap;
                Qualifiers qual;
                if (System.Enum.TryParse<Encapsulation>(modifier, out encap))
                {
                    retMethod.Encapsulation.Add(encap);
                }
                else if (System.Enum.TryParse<Qualifiers>(modifier, out qual))
                {
                    retMethod.Qualifiers.Add(qual);
                }
            }

            TypeSyntax ts = mds.ReturnType;
            Model.Type retType = new Model.Type();
            retType.Name = ts.ToString();
            retType.IsKnownType = SyntaxFacts.IsKeywordKind(ts.CSharpKind());
            retType.IsNotUserDefined = SyntaxFacts.IsKeywordKind(ts.CSharpKind());
            //TODO
            //rettype.generictype
            retMethod.ReturnType = retType;

            ParameterListSyntax pls = mds.ParameterList;
            foreach (ParameterSyntax ps in pls.Parameters)
            {
                retMethod.Parameters.Add(TraverseParamaters(ps));
            }
            BlockSyntax bs = mds.Body;
            if (bs != null)
            {
                var labelStatements = from aLabelStatement in bs.ChildNodes().OfType<LabeledStatementSyntax>() select aLabelStatement;
                foreach (LabeledStatementSyntax lss in labelStatements)
                {
                    retMethod.LabelStatements.Add(TraverseLabelStatements(lss));
                }

                var goToStatements = from aGoToStatement in bs.ChildNodes().OfType<GotoStatementSyntax>() select aGoToStatement;
                foreach (GotoStatementSyntax gtss in goToStatements)
                {
                    GoTo gt = TraverseGoToStatements(gtss);
                    retMethod.GoToStatements.Add(gt);
                }

                //Preprocessors = new List<Preprocessor>();
                //Base = new List<InvokedMethod>();
                //Decisions = new Decisions();

                var accessVarsDecl = from aAccessVarsDecl in bs.ChildNodes().OfType<LocalDeclarationStatementSyntax>() select aAccessVarsDecl;
                foreach (LocalDeclarationStatementSyntax ldss in accessVarsDecl)
                {
                    Method tempMethod = TransverseAccessVars(ldss);
                    retMethod.AccessedVariables.AddRange(tempMethod.AccessedVariables);
                    retMethod.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }

                var ifStatements = from aIfStatement in bs.ChildNodes().OfType<IfStatementSyntax>() select aIfStatement;
                foreach (IfStatementSyntax iss in ifStatements)
                {
                    int exitPoints = retMethod.ExitPoints;
                    Decisions tempDecision = AllDecisions(TraverseIfStatements(iss, ref exitPoints));
                    retMethod.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                    retMethod.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                    retMethod.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                    retMethod.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                    retMethod.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                    retMethod.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                    retMethod.Decisions.Catches.AddRange(tempDecision.Catches);
                    retMethod.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                    retMethod.ExitPoints = exitPoints;
                }
                var elseStatements = from aElseStatements in bs.ChildNodes().OfType<ElseClauseSyntax>() select aElseStatements;
                foreach (ElseClauseSyntax ecs in elseStatements)
                {
                    int exitPoints = retMethod.ExitPoints;
                    Decisions tempDecision = TraverseElseClauses(ecs, ref exitPoints);
                    retMethod.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                    retMethod.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                    retMethod.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                    retMethod.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                    retMethod.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                    retMethod.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                    retMethod.Decisions.Catches.AddRange(tempDecision.Catches);
                    retMethod.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                    retMethod.ExitPoints = exitPoints;
                }
                var whileLoops = from aWhileLoop in bs.ChildNodes().OfType<WhileStatementSyntax>() select aWhileLoop;
                foreach (WhileStatementSyntax wss in whileLoops)
                {
                    int exitPoints = retMethod.ExitPoints;
                    Decisions tempDecision = TraverseWhileLoops(wss, ref exitPoints);
                    retMethod.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                    retMethod.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                    retMethod.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                    retMethod.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                    retMethod.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                    retMethod.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                    retMethod.Decisions.Catches.AddRange(tempDecision.Catches);
                    retMethod.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                    retMethod.ExitPoints = exitPoints;
                }
                var doWhileLoops = from aDoWhileLoop in bs.ChildNodes().OfType<DoStatementSyntax>() select aDoWhileLoop;
                foreach (DoStatementSyntax dss in doWhileLoops)
                {
                    int exitPoints = retMethod.ExitPoints;
                    Decisions tempDecision = TraverseDoStatements(dss, ref exitPoints);
                    retMethod.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                    retMethod.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                    retMethod.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                    retMethod.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                    retMethod.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                    retMethod.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                    retMethod.Decisions.Catches.AddRange(tempDecision.Catches);
                    retMethod.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                    retMethod.ExitPoints = exitPoints;
                }
                var forLoops = from aForLoop in bs.ChildNodes().OfType<ForStatementSyntax>() select aForLoop;
                foreach (ForStatementSyntax fss in forLoops)
                {
                    int exitPoints = retMethod.ExitPoints;
                    Decisions tempDecision = TraverseForStatements(fss, ref exitPoints);
                    retMethod.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                    retMethod.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                    retMethod.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                    retMethod.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                    retMethod.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                    retMethod.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                    retMethod.Decisions.Catches.AddRange(tempDecision.Catches);
                    retMethod.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                    retMethod.ExitPoints = exitPoints;
                }
                var foreachLoops = from aForeachLoop in bs.ChildNodes().OfType<ForEachStatementSyntax>() select aForeachLoop;
                foreach (ForEachStatementSyntax fess in foreachLoops)
                {
                    int exitPoints = retMethod.ExitPoints;
                    Decisions tempDecision = TraverseForEachStatements(fess, ref exitPoints);
                    retMethod.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                    retMethod.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                    retMethod.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                    retMethod.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                    retMethod.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                    retMethod.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                    retMethod.Decisions.Catches.AddRange(tempDecision.Catches);
                    retMethod.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                    retMethod.ExitPoints = exitPoints;
                }
                var switches = from aSwitch in bs.ChildNodes().OfType<SwitchStatementSyntax>() select aSwitch;
                foreach (SwitchStatementSyntax sss in switches)
                {
                    int exitPoints = retMethod.ExitPoints;
                    Decisions tempDecision = TraverseSwitchStatements(sss, ref exitPoints);
                    retMethod.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                    retMethod.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                    retMethod.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                    retMethod.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                    retMethod.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                    retMethod.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                    retMethod.Decisions.Catches.AddRange(tempDecision.Catches);
                    retMethod.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                    retMethod.ExitPoints = exitPoints;
                }
                var catches = from aCatch in bs.ChildNodes().OfType<CatchClauseSyntax>() select aCatch;
                foreach (CatchClauseSyntax ccs in catches)
                {
                    int exitPoints = retMethod.ExitPoints;
                    Decisions tempDecision = TraverseCatchClauses(ccs, ref exitPoints);
                    retMethod.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                    retMethod.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                    retMethod.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                    retMethod.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                    retMethod.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                    retMethod.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                    retMethod.Decisions.Catches.AddRange(tempDecision.Catches);
                    retMethod.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                    retMethod.ExitPoints = exitPoints;
                }
                var breaks = from aBreak in bs.ChildNodes().OfType<BreakStatementSyntax>() select aBreak;
                foreach (BreakStatementSyntax bss in breaks)
                {
                    //TODO get breaks
                    //note that breaks are NOT in retMethod.Decisions
                }
                var checks = from aCheck in bs.ChildNodes().OfType<CheckedStatementSyntax>() select aCheck;
                foreach (CheckedStatementSyntax css in checks)
                {
                    //TODO get checks
                    //note that checks are NOT in retMethod.Decisions
                }
                var continues = from aContinue in bs.ChildNodes().OfType<ContinueStatementSyntax>() select aContinue;
                foreach (ContinueStatementSyntax css in continues)
                {
                    //TODO get continues
                    //note that continues are NOT in retMethod.Decisions
                }
                var emptys = from aEmpty in bs.ChildNodes().OfType<EmptyStatementSyntax>() select aEmpty;
                foreach (EmptyStatementSyntax ess in emptys)
                {
                    //TODO get emptys
                    //note that emptys are NOT in retMethod.Decisions
                }
                var exprs = from aExpr in bs.ChildNodes().OfType<ExpressionStatementSyntax>() select aExpr;
                foreach (ExpressionStatementSyntax ess in exprs)
                {
                    //TODO get expressions
                    //note that expressions are NOT in retMethod.Decisions
                }
                var fixeds = from aFixed in bs.ChildNodes().OfType<FixedStatementSyntax>() select aFixed;
                foreach (FixedStatementSyntax fss in fixeds)
                {
                    //TODO get fixed
                    //note that these are NOT in retMethod.Decisions
                }
                var locks = from aLock in bs.ChildNodes().OfType<LockStatementSyntax>() select aLock;
                foreach (LockStatementSyntax lss in locks)
                {
                    //TODO get lock
                    //note that these are NOT in retMethod.Decisions
                }
                var returns = from aReturn in bs.ChildNodes().OfType<ReturnStatementSyntax>() select aReturn;
                foreach (ReturnStatementSyntax rss in returns)
                {
                    retMethod.ExitPoints++;
                }
                var throws = from aThrow in bs.ChildNodes().OfType<ThrowStatementSyntax>() select aThrow;
                foreach (ThrowStatementSyntax tss in throws)
                {
                    //TODO get throws
                    //note that these are NOT in retMethod.Decisions
                }
                var trys = from aTry in bs.ChildNodes().OfType<TryStatementSyntax>() select aTry;
                foreach (TryStatementSyntax tss in trys)
                {
                    //TODO get trys
                    //note that these are NOT in retMethod.Decisions
                }
                var unsafes = from aUnsafe in bs.ChildNodes().OfType<UnsafeStatementSyntax>() select aUnsafe;
                foreach (UnsafeStatementSyntax uss in unsafes)
                {
                    //TODO get unsafes
                    //note that these are NOT in retMethod.Decisions
                }
                var usings = from aUsing in bs.ChildNodes().OfType<UsingStatementSyntax>() select aUsing;
                foreach (UsingStatementSyntax uss in usings)
                {
                    //TODO get usings
                    //note that these are NOT in retMethod.Decisions
                }
                var yields = from aYield in bs.ChildNodes().OfType<YieldStatementSyntax>() select aYield;
                foreach (YieldStatementSyntax yss in yields)
                {
                    //TODO get yields
                    //note that these are NOT in retMethod.Decisions
                }
                var invokedMethods = from aInvokedMethod in bs.ChildNodes().OfType<InvocationExpressionSyntax>() select aInvokedMethod;
                foreach (InvocationExpressionSyntax ies in invokedMethods)
                {
                    Method tempMethod = TraverseInvocationExpression(ies);
                    retMethod.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                    retMethod.AccessedVariables.AddRange(tempMethod.AccessedVariables);
                }

                //InvokedMethods = new List<InvokedMethod>();
            }
            return retMethod;
        }

        private Decisions AllDecisions(Decisions decisions)
        {
            Decisions retDecisions = new Decisions();
            foreach (IfStatement bd in decisions.IfStatements)
            {
                retDecisions.Add(bd);
                RecursiveDecisions(bd.Nested, ref retDecisions);
            }
            foreach (ElseStatement bd in decisions.ElseStatements)
            {
                retDecisions.Add(bd);
                RecursiveDecisions(bd.Nested, ref retDecisions);
            }
            foreach (ForStatement bd in decisions.ForStatements)
            {
                retDecisions.Add(bd);
                RecursiveDecisions(bd.Nested, ref retDecisions);
            }
            foreach (ForEachStatement bd in decisions.ForEachStatements)
            {
                retDecisions.Add(bd);
                RecursiveDecisions(bd.Nested, ref retDecisions);
            }
            foreach (WhileLoop bd in decisions.WhileLoops)
            {
                retDecisions.Add(bd);
                RecursiveDecisions(bd.Nested, ref retDecisions);
            }
            foreach (DoWhileLoop bd in decisions.DoWhileLoops)
            {
                retDecisions.Add(bd);
                RecursiveDecisions(bd.Nested, ref retDecisions);
            }
            foreach (SwitchStatement bd in decisions.SwitchStatements)
            {
                retDecisions.Add(bd);
                RecursiveDecisions(bd.Nested, ref retDecisions);
            }
            foreach (CatchStatements bd in decisions.Catches)
            {
                retDecisions.Add(bd);
                RecursiveDecisions(bd.Nested, ref retDecisions);
            }
            return retDecisions;
        }

        private void RecursiveDecisions(List<BaseDecisions> nested, ref Decisions decisions)
        {
            foreach (BaseDecisions bd in nested)
            {
                decisions.Add(bd);
                RecursiveDecisions(bd.Nested, ref decisions);
            }
        }


        private Decisions TraverseIfStatements(IfStatementSyntax iss, ref int exitPoints, bool nested = false)
        {
            Decisions retDecision = new Decisions();
            IfStatement ifStm = new IfStatement();
            ifStm.IsNested = nested;
            //public int ExpressionListEndLn { get; set; }
            //public int ExpressionListStartLn { get; set; }
            //public bool IsNested { get; set; }
            ExpressionSyntax es = iss.Condition;
            var binaryExpressions = from aBinaryExpression in iss.Condition.DescendantNodesAndSelf().OfType<BinaryExpressionSyntax>() select aBinaryExpression;
            ifStm.ConditionCount = binaryExpressions.Count();
            //This area is for the conditions i.e. the stuff in the () of if ()
            foreach (BinaryExpressionSyntax bes in binaryExpressions)
            {
                Method tempMethod = TraverseBinaryExpression(bes);
                ifStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                ifStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
            }
            //TODO handle catches (if there are even catches inside if statements)
            var catches = from aCatch in iss.ChildNodes().OfType<CatchClauseSyntax>() select aCatch;
            foreach (CatchClauseSyntax ccs in catches)
            {
                Decisions tempCatch = TraverseCatchClauses(ccs, ref exitPoints, true);
                ifStm.Nested.AddRange(tempCatch.Catches);
            }
            //TODO need to handle else clauses
            var elses = from aElse in iss.ChildNodes().OfType<ElseClauseSyntax>() select aElse;
            foreach (ElseClauseSyntax ecs in elses)
            {
                //TODO
                //Traverse ElseClauseSyntax
                Decisions tempElse = TraverseElseClauses(ecs, ref exitPoints, true);
                ifStm.Nested.AddRange(tempElse.ElseStatements);
                #region old code with method return
                //ifStm.InvokedMethods.AddRange(tempElse.InvokedMethods);
                //ifStm.AccessedVars.AddRange(tempElse.AccessedVars);
                //ifStm.Nested.Add(tempElse);
                //foreach (BaseDecisions bd in ifStm.Nested)
                //{
                //    bd.IsNested = true;
                //}
                #endregion
            }
            //TODO need to find a way to return both nested
            //and invoked methods / accessedvars to the parent method
            var statements = from aStatement in iss.Statement.ChildNodes().OfType<StatementSyntax>() select aStatement;
            List<BaseDecisions> retBd = new List<BaseDecisions>();
            List<InvokedMethod> retIm = new List<InvokedMethod>();
            #region Nested and Invoked Methods and accessed vars
            foreach (StatementSyntax ss in statements)
            {
                
                //if (ss is BreakStatementSyntax)
                //{
                //}
                //else if (ss is CheckedStatementSyntax)
                //{
                //}
                //else if (ss is ContinueStatementSyntax)
                //{
                //}
                if (ss is DoStatementSyntax)
                {
                    Decisions dwl = TraverseDoStatements(ss as DoStatementSyntax, ref exitPoints, true);
                    ifStm.Nested.AddRange(dwl.DoWhileLoops);
                    //dwl.IsNested = true;
                    //ifStm.Nested.Add(dwl);
                }
                //else if (ss is EmptyStatementSyntax)
                //{
                //}
                else if (ss is ExpressionStatementSyntax)
                {
                    Method tempMethod = TraverseExpressionStatementSyntax(ss as ExpressionStatementSyntax);
                    ifStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    ifStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                //else if (ss is FixedStatementSyntax)
                //{
                //}
                else if (ss is ForEachStatementSyntax)
                {
                    Decisions fes = TraverseForEachStatements(ss as ForEachStatementSyntax, ref exitPoints, true);
                    ifStm.Nested.AddRange(fes.ForEachStatements);
                    //fes.IsNested = true;
                    //ifStm.Nested.Add(fes);
                }
                else if (ss is ForStatementSyntax)
                {
                    Decisions fs = TraverseForStatements(ss as ForStatementSyntax, ref exitPoints, true);
                    ifStm.Nested.AddRange(fs.ForStatements);
                    //fs.IsNested = true;
                    //ifStm.Nested.Add(fs);
                }
                //else if (ss is GotoStatementSyntax)
                //{
                //}
                else if (ss is IfStatementSyntax)
                {
                    Decisions decision = TraverseIfStatements(ss as IfStatementSyntax, ref exitPoints, true);
                    ifStm.Nested.AddRange(decision.IfStatements);
                }
                //else if (ss is LabeledStatementSyntax)
                //{
                //    BaseDecisions bd = new BaseDecisions();
                //    bd.IsNested = true;
                //    bd.Nested.Add(TraverseLabelStatements(ss as LabeledStatementSyntax));
                //    retIf.Nested.Add(bd);
                //}
                else if (ss is LocalDeclarationStatementSyntax)
                {
                    Model.Type tempType = new Model.Type();
                    LocalDeclarationStatementSyntax ldss = ss as LocalDeclarationStatementSyntax;
                    if (ldss.Declaration != null)
                    {
                        VariableDeclarationSyntax vds = ldss.Declaration;
                        tempType.Name = vds.Type.ToString();
                        tempType.IsKnownType = true;
                        tempType.IsNotUserDefined = true;
                    }
                    Method tempMethod = TransverseAccessVars(ss as LocalDeclarationStatementSyntax);
                    //NOT SURE if this will work but here goes
                    tempMethod.AccessedVariables[0].Type = tempType;
                    ifStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    ifStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                //else if (ss is LockStatementSyntax)
                //{
                //}
                else if (ss is ReturnStatementSyntax)
                {
                    exitPoints++;
                }
                else if (ss is SwitchStatementSyntax)
                {
                    Decisions switchStm = TraverseSwitchStatements(ss as SwitchStatementSyntax, ref exitPoints, true);
                    ifStm.Nested.AddRange(switchStm.SwitchStatements);
                    //switchStm.IsNested = true;
                    //ifStm.Nested.Add(switchStm);
                }
                //else if (ss is ThrowStatementSyntax)
                //{
                //}
                //else if (ss is TryStatementSyntax)
                //{
                //}
                //else if (ss is UnsafeStatementSyntax)
                //{
                //}
                //else if (ss is UsingStatementSyntax)
                //{
                //    //using list?
                //}
                else if (ss is WhileStatementSyntax)
                {
                    Decisions wl = TraverseWhileLoops(ss as WhileStatementSyntax, ref exitPoints, true);
                    ifStm.Nested.AddRange(wl.WhileLoops);
                    //wl.IsNested = true;
                    //ifStm.Nested.Add(wl);
                }
                //else if (ss is YieldStatementSyntax)
                //{
                //}
            }
            #endregion

            retDecision.IfStatements.Add(ifStm);

            return retDecision;
        }

        private Decisions TraverseCatchClauses(CatchClauseSyntax ccs, ref int exitPoints, bool nested = false)
        {
            Decisions retDecision = new Decisions();
            CatchStatements retCatch = new CatchStatements();
            retCatch.IsNested = nested;
            var binaryExpressions = from aBinaryExpression in ccs.ChildNodes().OfType<BinaryExpressionSyntax>() select aBinaryExpression;
            foreach (BinaryExpressionSyntax bes in binaryExpressions)
            {
                Method tempMethod = TraverseBinaryExpression(bes);
                retCatch.AccessedVars.AddRange(tempMethod.AccessedVariables);
                retCatch.InvokedMethods.AddRange(tempMethod.InvokedMethods);
            }
            var catches = from aCatch in ccs.ChildNodes().OfType<CatchClauseSyntax>() select aCatch;
            foreach (CatchClauseSyntax ccs2 in catches)
            {
                Decisions tempCatch = TraverseCatchClauses(ccs2, ref exitPoints, true);
                retCatch.Nested.AddRange(tempCatch.Catches);
            }
            var elses = from aElse in ccs.ChildNodes().OfType<ElseClauseSyntax>() select aElse;
            foreach (ElseClauseSyntax ecs2 in elses)
            {
                Decisions tempElse = TraverseElseClauses(ecs2, ref exitPoints, true);
                retCatch.Nested.AddRange(tempElse.ElseStatements);
            }
            #region nested stuff
            var statements = from aStatement in ccs.ChildNodes().OfType<StatementSyntax>() select aStatement;
            foreach (StatementSyntax ss in statements)
            {
                if (ss is DoStatementSyntax)
                {
                    Decisions dwl = TraverseDoStatements(ss as DoStatementSyntax, ref exitPoints, true);
                    retCatch.Nested.AddRange(dwl.DoWhileLoops);
                }
                else if (ss is ExpressionStatementSyntax)
                {
                    Method tempMethod = TraverseExpressionStatementSyntax(ss as ExpressionStatementSyntax);
                    retCatch.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    retCatch.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                else if (ss is ForEachStatementSyntax)
                {
                    Decisions fes = TraverseForEachStatements(ss as ForEachStatementSyntax, ref exitPoints, true);
                    retCatch.Nested.AddRange(fes.ForEachStatements);
                }
                else if (ss is ForStatementSyntax)
                {
                    Decisions fs = TraverseForStatements(ss as ForStatementSyntax, ref exitPoints, true);
                    retCatch.Nested.AddRange(fs.ForStatements);
                }
                else if (ss is IfStatementSyntax)
                {
                    Decisions decision = TraverseIfStatements(ss as IfStatementSyntax, ref exitPoints, true);
                    retCatch.Nested.AddRange(decision.IfStatements);
                }
                else if (ss is LocalDeclarationStatementSyntax)
                {
                    Model.Type tempType = new Model.Type();
                    LocalDeclarationStatementSyntax ldss = ss as LocalDeclarationStatementSyntax;
                    if (ldss.Declaration != null)
                    {
                        VariableDeclarationSyntax vds = ldss.Declaration;
                        tempType.Name = vds.Type.ToString();
                        tempType.IsKnownType = true;
                        tempType.IsNotUserDefined = true;
                    }
                    Method tempMethod = TransverseAccessVars(ss as LocalDeclarationStatementSyntax);
                    //NOT SURE if this will work but here goes
                    tempMethod.AccessedVariables[0].Type = tempType;
                    retCatch.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    retCatch.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                else if (ss is ReturnStatementSyntax)
                {
                    exitPoints++;
                }
                else if (ss is SwitchStatementSyntax)
                {
                    Decisions switchStm = TraverseSwitchStatements(ss as SwitchStatementSyntax, ref exitPoints, true);
                    retCatch.Nested.AddRange(switchStm.SwitchStatements);
                }
                else if (ss is WhileStatementSyntax)
                {
                    Decisions wl = TraverseWhileLoops(ss as WhileStatementSyntax, ref exitPoints, true);
                    retCatch.Nested.AddRange(wl.WhileLoops);
                }
            }
            #endregion
            retDecision.Catches.Add(retCatch);
            return retDecision;
        }

        //private Method TraverseStatementSyntax(StatementSyntax ss)
        //{
        //    Method retMethod = new Method();
        //    //TODO
        //    //Get catches for decisions
        //    if (ss is DoStatementSyntax)
        //    {
        //        DoWhileLoop dwl = TraverseDoStatements(ss as DoStatementSyntax);
        //        dwl.IsNested = true;
        //        retMethod.Decisions.DoWhileLoops.Add(dwl);
        //    }
        //    else if (ss is ExpressionStatementSyntax)
        //    {
        //        Method tempMethod = TraverseExpressionStatementSyntax(ss as ExpressionStatementSyntax);
        //        retMethod.AccessedVariables.AddRange(tempMethod.AccessedVariables);
        //        retMethod.InvokedMethods.AddRange(tempMethod.InvokedMethods);
        //    }
        //    else if (ss is ForEachStatementSyntax)
        //    {
        //        ForEachStatement fes = TraverseForEachStatements(ss as ForEachStatementSyntax);
        //        fes.IsNested = true;
        //        retMethod.Decisions.ForEachStatements.Add(fes);
        //    }
        //    else if (ss is ForStatementSyntax)
        //    {
        //        ForStatement fs = TraverseForStatements(ss as ForStatementSyntax);
        //        fs.IsNested = true;
        //        retMethod.Decisions.ForStatements.Add(fs);
        //    }
        //    else if (ss is IfStatementSyntax)
        //    {
        //        IfStatement ifstm = TraverseIfStatements(ss as IfStatementSyntax);
        //        ifstm.IsNested = true;
        //        retMethod.Decisions.IfStatements.Add(ifstm);
        //    }
        //    else if (ss is LocalDeclarationStatementSyntax)
        //    {
        //        Model.Type tempType = new Model.Type();
        //        LocalDeclarationStatementSyntax ldss = ss as LocalDeclarationStatementSyntax;
        //        if (ldss.Declaration != null)
        //        {
        //            VariableDeclarationSyntax vds = ldss.Declaration;
        //            tempType.Name = vds.Type.ToString();
        //            tempType.IsKnownType = true;
        //            tempType.IsNotUserDefined = true;
        //        }
        //        Method tempMethod = TransverseAccessVars(ss as LocalDeclarationStatementSyntax);
        //        //NOT SURE if this will work but here goes
        //        tempMethod.AccessedVariables[0].Type = tempType;
        //        retMethod.AccessedVariables.AddRange(tempMethod.AccessedVariables);
        //        retMethod.InvokedMethods.AddRange(tempMethod.InvokedMethods);
        //    }
        //    else if (ss is SwitchStatementSyntax)
        //    {
        //        SwitchStatement switchStm = TraverseSwitchStatements(ss as SwitchStatementSyntax);
        //        switchStm.IsNested = true;
        //        retMethod.Decisions.SwitchStatements.Add(switchStm);
        //    }
        //    else if (ss is WhileStatementSyntax)
        //    {
        //        WhileLoop wl = TraverseWhileLoops(ss as WhileStatementSyntax);
        //        wl.IsNested = true;
        //        retMethod.Decisions.WhileLoops.Add(wl);
        //    }
        //    return retMethod;
        //}

        private Method TraverseExpressionStatementSyntax(ExpressionStatementSyntax ess)
        {
            Method retMethod = new Method();
            var vars = from aVar in ess.ChildNodes().OfType<BinaryExpressionSyntax>() select aVar;
            foreach (BinaryExpressionSyntax bes in vars)
            {
                Method tempMethod = TraverseBinaryExpression(bes);
                retMethod.AccessedVariables.AddRange(tempMethod.AccessedVariables);
                retMethod.InvokedMethods.AddRange(tempMethod.InvokedMethods);
            }
            var invokedMethods = from aInvokedMethod in ess.ChildNodes().OfType<InvocationExpressionSyntax>() select aInvokedMethod;
            foreach (InvocationExpressionSyntax ies in invokedMethods)
            {
                Method tempMethod = TraverseInvocationExpression(ies);
                retMethod.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                retMethod.AccessedVariables.AddRange(tempMethod.AccessedVariables);
            }
            var postfixUnaryExpressions = from aPostfixUnaryExpression in ess.ChildNodes().OfType<PostfixUnaryExpressionSyntax>() select aPostfixUnaryExpression;
            foreach (PostfixUnaryExpressionSyntax pues in postfixUnaryExpressions)
            {
                Method tempMethod = TraversePostfixUnaryExpressions(pues);
                retMethod.AccessedVariables.AddRange(tempMethod.AccessedVariables);
                retMethod.InvokedMethods.AddRange(tempMethod.InvokedMethods);
            }
            var prefixUnaryExpressions = from aPrefixUnaryExpressions in ess.ChildNodes().OfType<PrefixUnaryExpressionSyntax>() select aPrefixUnaryExpressions;
            foreach (PrefixUnaryExpressionSyntax pues in prefixUnaryExpressions)
            {
                Method tempMethod = TraversePrefixUnaryExpressions(pues);
                retMethod.AccessedVariables.AddRange(tempMethod.AccessedVariables);
                retMethod.InvokedMethods.AddRange(tempMethod.InvokedMethods);
            }
            return retMethod;
        }

        private Method TraversePrefixUnaryExpressions(PrefixUnaryExpressionSyntax pues)
        {
            Method retMethod = new Method();
            var vars = from aVar in pues.ChildNodes().OfType<IdentifierNameSyntax>() select aVar;
            foreach (IdentifierNameSyntax ins in vars)
            {
                Variables tempVar = new Variables();
                tempVar.Name = ins.Identifier.ValueText;
                retMethod.AccessedVariables.Add(tempVar);
            }
            return retMethod;
        }

        private Method TraversePostfixUnaryExpressions(PostfixUnaryExpressionSyntax pues)
        {
            Method retMethod = new Method();
            var vars = from aVar in pues.ChildNodes().OfType<IdentifierNameSyntax>() select aVar;
            foreach (IdentifierNameSyntax ins in vars)
            {
                Variables tempVar = new Variables();
                tempVar.Name = ins.Identifier.ValueText;
                retMethod.AccessedVariables.Add(tempVar);
            }
            return retMethod;
        }

        private Decisions TraverseElseClauses(ElseClauseSyntax ecs, ref int exitPoints, bool nested = false)
        {
            Decisions retDecision = new Decisions();
            ElseStatement elseStm = new ElseStatement();
            elseStm.IsNested = nested;
            var binaryExpressions = from aBinaryExpression in ecs.ChildNodes().OfType<BinaryExpressionSyntax>() select aBinaryExpression;
            foreach (BinaryExpressionSyntax bes in binaryExpressions)
            {
                Method tempMethod = TraverseBinaryExpression(bes);
                elseStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                elseStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
            }
            var catches = from aCatch in ecs.ChildNodes().OfType<CatchClauseSyntax>() select aCatch;
            foreach (CatchClauseSyntax ccs in catches)
            {
                Decisions tempCatch = TraverseCatchClauses(ccs, ref exitPoints, true);
                elseStm.Nested.AddRange(tempCatch.Catches);
            }
            var elses = from aElse in ecs.ChildNodes().OfType<ElseClauseSyntax>() select aElse;
            foreach (ElseClauseSyntax ecs2 in elses)
            {
                Decisions tempElse = TraverseElseClauses(ecs2, ref exitPoints, true);
                elseStm.Nested.AddRange(tempElse.ElseStatements);
            }
            #region nested stuff
            var statements = from aStatement in ecs.ChildNodes().OfType<StatementSyntax>() select aStatement;
            foreach (StatementSyntax ss in statements)
            {
                if (ss is DoStatementSyntax)
                {
                    Decisions dwl = TraverseDoStatements(ss as DoStatementSyntax, ref exitPoints, true);
                    elseStm.Nested.AddRange(dwl.DoWhileLoops);
                }
                else if (ss is ExpressionStatementSyntax)
                {
                    Method tempMethod = TraverseExpressionStatementSyntax(ss as ExpressionStatementSyntax);
                    elseStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    elseStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                else if (ss is ForEachStatementSyntax)
                {
                    Decisions fes = TraverseForEachStatements(ss as ForEachStatementSyntax, ref exitPoints, true);
                    elseStm.Nested.AddRange(fes.ForEachStatements);
                }
                else if (ss is ForStatementSyntax)
                {
                    Decisions fs = TraverseForStatements(ss as ForStatementSyntax, ref exitPoints, true);
                    elseStm.Nested.AddRange(fs.ForStatements);
                }
                else if (ss is IfStatementSyntax)
                {
                    Decisions decision = TraverseIfStatements(ss as IfStatementSyntax, ref exitPoints, true);
                    elseStm.Nested.AddRange(decision.IfStatements);
                }
                else if (ss is LocalDeclarationStatementSyntax)
                {
                    Model.Type tempType = new Model.Type();
                    LocalDeclarationStatementSyntax ldss = ss as LocalDeclarationStatementSyntax;
                    if (ldss.Declaration != null)
                    {
                        VariableDeclarationSyntax vds = ldss.Declaration;
                        tempType.Name = vds.Type.ToString();
                        tempType.IsKnownType = true;
                        tempType.IsNotUserDefined = true;
                    }
                    Method tempMethod = TransverseAccessVars(ss as LocalDeclarationStatementSyntax);
                    //NOT SURE if this will work but here goes
                    tempMethod.AccessedVariables[0].Type = tempType;
                    elseStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    elseStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                else if (ss is ReturnStatementSyntax)
                {
                    exitPoints++;
                }
                else if (ss is SwitchStatementSyntax)
                {
                    Decisions switchStm = TraverseSwitchStatements(ss as SwitchStatementSyntax, ref exitPoints, true);
                    elseStm.Nested.AddRange(switchStm.SwitchStatements);
                }
                else if (ss is WhileStatementSyntax)
                {
                    Decisions wl = TraverseWhileLoops(ss as WhileStatementSyntax, ref exitPoints, true);
                    elseStm.Nested.AddRange(wl.WhileLoops);
                }
            }
            #endregion
            retDecision.ElseStatements.Add(elseStm);
            return retDecision;
        }

        private Method TraverseInvocationExpression(InvocationExpressionSyntax ies)
        {
            //TODO
            //get method name and accessed variables
            //and attributes and qualifiers
            Method retIm = new Method();
            //havent tested this with extra stuff like setting the variable equal to the method call
            //or with variables in the method call
            var methods = from aMethod in ies.ChildNodes().OfType<IdentifierNameSyntax>() select aMethod;
            foreach (IdentifierNameSyntax ins in methods)
            {
                InvokedMethod tempMethod = new InvokedMethod();
                tempMethod.Name = ins.Identifier.ValueText;
                retIm.InvokedMethods.Add(tempMethod);
            }
            //var args = from aArg in ies.ArgumentList.Arguments.OfType<ArgumentSyntax>() select aArg;
            //foreach (ArgumentSyntax asyn in args)
            //{
            //    Variables tempVar = new Variables();

            //}
            var args = from aArg in ies.Expression.ChildNodes().OfType<IdentifierNameSyntax>() select aArg;
            foreach (IdentifierNameSyntax ins in args)
            {
                Variables tempVar = new Variables();
                tempVar.Name = ins.Identifier.ValueText;
                retIm.AccessedVariables.Add(tempVar);
            }
            retIm.Name = ies.Expression.ToString();
            return retIm;
        }

        private Decisions TraverseWhileLoops(WhileStatementSyntax wss, ref int exitPoints, bool nested = false)
        {
            //TODO
            //get accessed vars, invoked methods, nested
            Decisions retDecision = new Decisions();
            WhileLoop whileStm = new WhileLoop();
            ExpressionSyntax es = wss.Condition;
            //var binaryExpressions = from aBinaryExpression in wss.Condition.DescendantNodesAndSelf().OfType<BinaryExpressionSyntax>() select aBinaryExpression;
            var binaryExpressions = from abinaryExpression in wss.ChildNodes().OfType<BinaryExpressionSyntax>() select abinaryExpression;
            whileStm.ConditionCount = binaryExpressions.Count();
            if (wss.Condition is BinaryExpressionSyntax)
            {
                //this next line doesn't ever fire
                //binaryExpressions = from aBinaryExpression in wss.Condition.DescendantNodes().OfType<BinaryExpressionSyntax>() select aBinaryExpression;
                foreach (BinaryExpressionSyntax bes in binaryExpressions)
                {
                    Method tempMethod = TraverseBinaryExpression(bes);
                    whileStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    whileStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
            }
            var catches = from aCatch in wss.ChildNodes().OfType<CatchClauseSyntax>() select aCatch;
            foreach (CatchClauseSyntax ccs in catches)
            {
                Decisions tempCatch = TraverseCatchClauses(ccs, ref exitPoints, true);
                whileStm.Nested.AddRange(tempCatch.Catches);
            }
            var statements = from aStatement in wss.Statement.ChildNodes().OfType<StatementSyntax>() select aStatement;
            List<BaseDecisions> retBd = new List<BaseDecisions>();
            List<InvokedMethod> retIm = new List<InvokedMethod>();
            #region Nested and Invoked Methods and accessed vars
            foreach (StatementSyntax ss in statements)
            {
                
                //if (ss is BreakStatementSyntax)
                //{
                //}
                //else if (ss is CheckedStatementSyntax)
                //{
                //}
                //else if (ss is ContinueStatementSyntax)
                //{
                //}
                if (ss is DoStatementSyntax)
                {
                    Decisions dwl = TraverseDoStatements(ss as DoStatementSyntax, ref exitPoints, true);
                    whileStm.Nested.AddRange(dwl.DoWhileLoops);
                    //dwl.IsNested = true;
                    //whileStm.Nested.Add(dwl);
                }
                //else if (ss is EmptyStatementSyntax)
                //{
                //}
                else if (ss is ExpressionStatementSyntax)
                {
                    Method tempMethod = TraverseExpressionStatementSyntax(ss as ExpressionStatementSyntax);
                    whileStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    whileStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                //else if (ss is FixedStatementSyntax)
                //{
                //}
                else if (ss is ForEachStatementSyntax)
                {
                    Decisions fes = TraverseForEachStatements(ss as ForEachStatementSyntax, ref exitPoints, true);
                    whileStm.Nested.AddRange(fes.ForEachStatements);
                    //fes.IsNested = true;
                    //whileStm.Nested.Add(fes);
                }
                else if (ss is ForStatementSyntax)
                {
                    Decisions fs = TraverseForStatements(ss as ForStatementSyntax, ref exitPoints, true);
                    whileStm.Nested.AddRange(fs.WhileLoops);
                    //fs.IsNested = true;
                    //whileStm.Nested.Add(fs);
                }
                //else if (ss is GotoStatementSyntax)
                //{
                //}
                else if (ss is IfStatementSyntax)
                {
                    Decisions decision = TraverseIfStatements(ss as IfStatementSyntax, ref exitPoints, true);
                    whileStm.Nested.AddRange(decision.IfStatements);
                }
                //else if (ss is LabeledStatementSyntax)
                //{
                //    BaseDecisions bd = new BaseDecisions();
                //    bd.IsNested = true;
                //    bd.Nested.Add(TraverseLabelStatements(ss as LabeledStatementSyntax));
                //    retIf.Nested.Add(bd);
                //}
                else if (ss is LocalDeclarationStatementSyntax)
                {
                    Method tempMethod = TransverseAccessVars(ss as LocalDeclarationStatementSyntax);
                    whileStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    whileStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                //else if (ss is LockStatementSyntax)
                //{
                //}
                //else if (ss is ReturnStatementSyntax)
                //{
                //}
                else if (ss is SwitchStatementSyntax)
                {
                    Decisions switchStm = TraverseSwitchStatements(ss as SwitchStatementSyntax, ref exitPoints, true);
                    whileStm.Nested.AddRange(switchStm.SwitchStatements);
                    //switchStm.IsNested = true;
                    //whileStm.Nested.Add(switchStm);
                }
                //else if (ss is ThrowStatementSyntax)
                //{
                //}
                //else if (ss is TryStatementSyntax)
                //{
                //}
                //else if (ss is UnsafeStatementSyntax)
                //{
                //}
                //else if (ss is UsingStatementSyntax)
                //{
                //    //using list?
                //}
                else if (ss is WhileStatementSyntax)
                {
                    Decisions wl = TraverseWhileLoops(ss as WhileStatementSyntax, ref exitPoints, true);
                    whileStm.Nested.AddRange(wl.WhileLoops);
                    //wl.IsNested = true;
                    //whileStm.Nested.Add(wl);
                }
                //else if (ss is YieldStatementSyntax)
                //{
                //}
            }
            #endregion

            retDecision.WhileLoops.Add(whileStm);

            return retDecision;
        }

        private Decisions TraverseSwitchStatements(SwitchStatementSyntax sss, ref int exitPoints, bool nested = false)
        {
            Decisions retDecision = new Decisions();
            SwitchStatement retSwitch = new SwitchStatement();
            ExpressionSyntax es = sss.Expression;
            var binaryExprs = from aBinaryExpr in sss.ChildNodes().OfType<BinaryExpressionSyntax>() select aBinaryExpr;
            foreach (BinaryExpressionSyntax bes in binaryExprs)
            {
                Method tempMethod = TraverseBinaryExpression(bes);
                retSwitch.AccessedVars.AddRange(tempMethod.AccessedVariables);
                retSwitch.InvokedMethods.AddRange(tempMethod.InvokedMethods);
            }
            var catches = from aCatch in sss.ChildNodes().OfType<CatchClauseSyntax>() select aCatch;
            foreach (CatchClauseSyntax ccs in catches)
            {
                Decisions tempCatch = TraverseCatchClauses(ccs, ref exitPoints, true);
                retSwitch.Nested.AddRange(tempCatch.Catches);
            }
            var statements = from aStatement in sss.ChildNodes().OfType<StatementSyntax>() select aStatement;
            List<BaseDecisions> retBd = new List<BaseDecisions>();
            List<InvokedMethod> retIm = new List<InvokedMethod>();
            #region Nested and Invoked Methods and accessed vars
            foreach (StatementSyntax ss in statements)
            {

                //if (ss is BreakStatementSyntax)
                //{
                //}
                //else if (ss is CheckedStatementSyntax)
                //{
                //}
                //else if (ss is ContinueStatementSyntax)
                //{
                //}
                if (ss is DoStatementSyntax)
                {
                    Decisions dwl = TraverseDoStatements(ss as DoStatementSyntax, ref exitPoints, true);
                    retSwitch.Nested.AddRange(dwl.DoWhileLoops);
                    //dwl.Nested.Add(TraverseDoStatements(ss as DoStatementSyntax));
                    //retSwitch.Nested.Add(dwl);
                }
                //else if (ss is EmptyStatementSyntax)
                //{
                //}
                else if (ss is ExpressionStatementSyntax)
                {
                    var vars = from aVar in ss.ChildNodes().OfType<BinaryExpressionSyntax>() select aVar;
                    foreach (BinaryExpressionSyntax bes in vars)
                    {
                        Method tempMethod = TraverseBinaryExpression(bes);
                        retSwitch.AccessedVars.AddRange(tempMethod.AccessedVariables);
                        retSwitch.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                    }
                    var invokedMethods = from aInvokedMethod in ss.ChildNodes().OfType<InvocationExpressionSyntax>() select aInvokedMethod;
                    foreach (InvocationExpressionSyntax ies in invokedMethods)
                    {
                        Method tempMethod = TraverseInvocationExpression(ies);
                        retSwitch.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                        retSwitch.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    }
                }
                //else if (ss is FixedStatementSyntax)
                //{
                //}
                else if (ss is ForEachStatementSyntax)
                {
                    Decisions fes = TraverseForEachStatements(ss as ForEachStatementSyntax, ref exitPoints, true);
                    retSwitch.Nested.AddRange(fes.ForEachStatements);
                    //fes.IsNested = true;
                    //retSwitch.Nested.Add(fes);
                }
                else if (ss is ForStatementSyntax)
                {
                    Decisions fs = TraverseForStatements(ss as ForStatementSyntax, ref exitPoints, true);
                    retSwitch.Nested.AddRange(fs.ForStatements);
                    //fs.IsNested = true;
                    //retSwitch.Nested.Add(fs);
                }
                //else if (ss is GotoStatementSyntax)
                //{
                //}
                else if (ss is IfStatementSyntax)
                {
                    Decisions ifstm = TraverseIfStatements(ss as IfStatementSyntax, ref exitPoints, true);
                    retSwitch.Nested.AddRange(ifstm.IfStatements);
                    //ifstm.IsNested = true;
                    //retSwitch.Nested.Add(ifstm);
                }
                //else if (ss is LabeledStatementSyntax)
                //{
                //    BaseDecisions bd = new BaseDecisions();
                //    bd.IsNested = true;
                //    bd.Nested.Add(TraverseLabelStatements(ss as LabeledStatementSyntax));
                //    retIf.Nested.Add(bd);
                //}
                else if (ss is LocalDeclarationStatementSyntax)
                {
                    Method tempMethod = TransverseAccessVars(ss as LocalDeclarationStatementSyntax);
                    retSwitch.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    retSwitch.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                //else if (ss is LockStatementSyntax)
                //{
                //}
                //else if (ss is ReturnStatementSyntax)
                //{
                //}
                else if (ss is SwitchStatementSyntax)
                {
                    Decisions switchStm = TraverseSwitchStatements(ss as SwitchStatementSyntax, ref exitPoints, true);
                    retSwitch.Nested.AddRange(switchStm.SwitchStatements);
                    //switchStm.IsNested = true;
                    //retSwitch.Nested.Add(switchStm);
                }
                //else if (ss is ThrowStatementSyntax)
                //{
                //}
                //else if (ss is TryStatementSyntax)
                //{
                //}
                //else if (ss is UnsafeStatementSyntax)
                //{
                //}
                //else if (ss is UsingStatementSyntax)
                //{
                //    //using list?
                //}
                else if (ss is WhileStatementSyntax)
                {
                    Decisions wl = TraverseWhileLoops(ss as WhileStatementSyntax, ref exitPoints, true);
                    retSwitch.Nested.AddRange(wl.WhileLoops);
                    //wl.IsNested = true;
                    //retSwitch.Nested.Add(wl);
                }
                //else if (ss is YieldStatementSyntax)
                //{
                //}
            }
            #endregion
            retDecision.SwitchStatements.Add(retSwitch);
            return retDecision;
        }

        private Decisions TraverseForStatements(ForStatementSyntax fss, ref int exitPoints, bool nested = false)
        {
            Decisions retDecision = new Decisions();
            ForStatement retFor = new ForStatement();
            ExpressionSyntax es = fss.Condition;
            if (es != null)
            {
                var binaryExpressions = from aBinaryExpression in es.DescendantNodesAndSelf().OfType<BinaryExpressionSyntax>() select aBinaryExpression;
                retFor.ConditionCount = binaryExpressions.Count();
                foreach (BinaryExpressionSyntax bes in binaryExpressions)
                {
                    Method tempMethod = TraverseBinaryExpression(bes);
                    retFor.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    retFor.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
            }
            var catches = from aCatch in fss.ChildNodes().OfType<CatchClauseSyntax>() select aCatch;
            foreach (CatchClauseSyntax ccs in catches)
            {
                Decisions tempCatch = TraverseCatchClauses(ccs, ref exitPoints, true);
                retFor.Nested.AddRange(tempCatch.Catches);
            }
            var statements = from aStatement in fss.Statement.ChildNodes().OfType<StatementSyntax>() select aStatement;
            List<BaseDecisions> retBd = new List<BaseDecisions>();
            List<InvokedMethod> retIm = new List<InvokedMethod>();
            #region Nested and Invoked Methods and accessed vars
            foreach (StatementSyntax ss in statements)
            {

                //if (ss is BreakStatementSyntax)
                //{
                //}
                //else if (ss is CheckedStatementSyntax)
                //{
                //}
                //else if (ss is ContinueStatementSyntax)
                //{
                //}
                if (ss is DoStatementSyntax)
                {
                    Decisions dwl = TraverseDoStatements(ss as DoStatementSyntax, ref exitPoints, true);
                    retFor.Nested.AddRange(dwl.DoWhileLoops);
                    //dwl.IsNested = true;
                    //retFor.Nested.Add(dwl);
                }
                //else if (ss is EmptyStatementSyntax)
                //{
                //}
                else if (ss is ExpressionStatementSyntax)
                {
                    Method tempMethod = TraverseExpressionStatementSyntax(ss as ExpressionStatementSyntax);
                    retFor.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    retFor.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                //else if (ss is FixedStatementSyntax)
                //{
                //}
                else if (ss is ForEachStatementSyntax)
                {
                    Decisions fes = TraverseForEachStatements(ss as ForEachStatementSyntax, ref exitPoints, true);
                    retFor.Nested.AddRange(fes.ForEachStatements);
                    //fes.IsNested = true;
                    //retFor.Nested.Add(fes);
                }
                else if (ss is ForStatementSyntax)
                {
                    Decisions fs = TraverseForStatements(ss as ForStatementSyntax, ref exitPoints, true);
                    retFor.Nested.AddRange(fs.ForStatements);
                    //fs.IsNested = true;
                    //retFor.Nested.Add(fs);
                }
                //else if (ss is GotoStatementSyntax)
                //{
                //}
                else if (ss is IfStatementSyntax)
                {
                    Decisions ifstm = TraverseIfStatements(ss as IfStatementSyntax, ref exitPoints, true);
                    retFor.Nested.AddRange(ifstm.IfStatements);
                    //ifstm.IsNested = true;
                    //retFor.Nested.Add(ifstm);
                }
                //else if (ss is LabeledStatementSyntax)
                //{
                //    BaseDecisions bd = new BaseDecisions();
                //    bd.IsNested = true;
                //    bd.Nested.Add(TraverseLabelStatements(ss as LabeledStatementSyntax));
                //    retIf.Nested.Add(bd);
                //}
                else if (ss is LocalDeclarationStatementSyntax)
                {
                    Method tempMethod = TransverseAccessVars(ss as LocalDeclarationStatementSyntax);
                    retFor.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    retFor.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                //else if (ss is LockStatementSyntax)
                //{
                //}
                //else if (ss is ReturnStatementSyntax)
                //{
                //}
                else if (ss is SwitchStatementSyntax)
                {
                    Decisions switchStm = TraverseSwitchStatements(ss as SwitchStatementSyntax, ref exitPoints, true);
                    retFor.Nested.AddRange(switchStm.SwitchStatements);
                    //switchStm.IsNested = true;
                    //retFor.Nested.Add(switchStm);
                }
                //else if (ss is ThrowStatementSyntax)
                //{
                //}
                //else if (ss is TryStatementSyntax)
                //{
                //}
                //else if (ss is UnsafeStatementSyntax)
                //{
                //}
                //else if (ss is UsingStatementSyntax)
                //{
                //    //using list?
                //}
                else if (ss is WhileStatementSyntax)
                {
                    Decisions wl = TraverseWhileLoops(ss as WhileStatementSyntax, ref exitPoints, true);
                    retFor.Nested.AddRange(wl.WhileLoops);
                    //wl.IsNested = true;
                    //retFor.Nested.Add(wl);
                }
                //else if (ss is YieldStatementSyntax)
                //{
                //}
            }
            #endregion
            retDecision.ForStatements.Add(retFor);
            return retDecision;
        }

        private Decisions TraverseForEachStatements(ForEachStatementSyntax fes, ref int exitPoints, bool nested = false)
        {
            Decisions retDecision = new Decisions();
            ForEachStatement retForEach = new ForEachStatement();
            var binaryExpressions = from aBinaryExpression in fes.ChildNodes().OfType<BinaryExpressionSyntax>() select aBinaryExpression;
            retForEach.ConditionCount = binaryExpressions.Count();
            foreach (BinaryExpressionSyntax bes in binaryExpressions)
            {
                Method tempMethod = TraverseBinaryExpression(bes);
                retForEach.AccessedVars.AddRange(tempMethod.AccessedVariables);
                retForEach.InvokedMethods.AddRange(tempMethod.InvokedMethods);
            }
            var catches = from aCatch in fes.ChildNodes().OfType<CatchClauseSyntax>() select aCatch;
            foreach (CatchClauseSyntax ccs in catches)
            {
                Decisions tempCatch = TraverseCatchClauses(ccs, ref exitPoints, true);
                retForEach.Nested.AddRange(tempCatch.Catches);
            }
            var statements = from aStatement in fes.Statement.ChildNodes().OfType<StatementSyntax>() select aStatement;
            List<BaseDecisions> retBd = new List<BaseDecisions>();
            List<InvokedMethod> retIm = new List<InvokedMethod>();
            #region Nested and Invoked Methods and accessed vars
            foreach (StatementSyntax ss in statements)
            {

                //if (ss is BreakStatementSyntax)
                //{
                //}
                //else if (ss is CheckedStatementSyntax)
                //{
                //}
                //else if (ss is ContinueStatementSyntax)
                //{
                //}
                if (ss is DoStatementSyntax)
                {
                    Decisions dwl = TraverseDoStatements(ss as DoStatementSyntax, ref exitPoints, true);
                    retForEach.Nested.AddRange(dwl.DoWhileLoops);
                    //dwl.IsNested = true;
                    //retForEach.Nested.Add(dwl);
                }
                //else if (ss is EmptyStatementSyntax)
                //{
                //}
                else if (ss is ExpressionStatementSyntax)
                {
                    var vars = from aVar in ss.ChildNodes().OfType<BinaryExpressionSyntax>() select aVar;
                    foreach (BinaryExpressionSyntax bes in vars)
                    {
                        Method tempMethod = TraverseBinaryExpression(bes);
                        retForEach.AccessedVars.AddRange(tempMethod.AccessedVariables);
                        retForEach.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                    }
                    var invokedMethods = from aInvokedMethod in ss.ChildNodes().OfType<InvocationExpressionSyntax>() select aInvokedMethod;
                    foreach (InvocationExpressionSyntax ies in invokedMethods)
                    {
                        Method tempMethod = TraverseInvocationExpression(ies);
                        retForEach.AccessedVars.AddRange(tempMethod.AccessedVariables);
                        retForEach.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                    }
                }
                //else if (ss is FixedStatementSyntax)
                //{
                //}
                else if (ss is ForEachStatementSyntax)
                {
                    Decisions forES = TraverseForEachStatements(ss as ForEachStatementSyntax, ref exitPoints, true);
                    retForEach.Nested.AddRange(forES.ForEachStatements);
                    //forES.IsNested = true;
                    //retForEach.Nested.Add(forES);
                }
                else if (ss is ForStatementSyntax)
                {
                    Decisions fs = TraverseForStatements(ss as ForStatementSyntax, ref exitPoints, true);
                    retForEach.Nested.AddRange(fs.ForStatements);
                    //fs.IsNested = true;
                    //retForEach.Nested.Add(fs);
                }
                //else if (ss is GotoStatementSyntax)
                //{
                //}
                else if (ss is IfStatementSyntax)
                {
                    Decisions ifstm = TraverseIfStatements(ss as IfStatementSyntax, ref exitPoints, true);
                    retForEach.Nested.AddRange(ifstm.IfStatements);
                    //ifstm.IsNested = true;
                    //retForEach.Nested.Add(ifstm);
                }
                //else if (ss is LabeledStatementSyntax)
                //{
                //    BaseDecisions bd = new BaseDecisions();
                //    bd.IsNested = true;
                //    bd.Nested.Add(TraverseLabelStatements(ss as LabeledStatementSyntax));
                //    retIf.Nested.Add(bd);
                //}
                else if (ss is LocalDeclarationStatementSyntax)
                {
                    Method tempMethod = TransverseAccessVars(ss as LocalDeclarationStatementSyntax);
                    retForEach.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    retForEach.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                //else if (ss is LockStatementSyntax)
                //{
                //}
                //else if (ss is ReturnStatementSyntax)
                //{
                //}
                else if (ss is SwitchStatementSyntax)
                {
                    Decisions switchStm = TraverseSwitchStatements(ss as SwitchStatementSyntax, ref exitPoints, true);
                    retForEach.Nested.AddRange(switchStm.SwitchStatements);
                    //switchStm.IsNested = true;
                    //retForEach.Nested.Add(switchStm);
                }
                //else if (ss is ThrowStatementSyntax)
                //{
                //}
                //else if (ss is TryStatementSyntax)
                //{
                //}
                //else if (ss is UnsafeStatementSyntax)
                //{
                //}
                //else if (ss is UsingStatementSyntax)
                //{
                //    //using list?
                //}
                else if (ss is WhileStatementSyntax)
                {
                    Decisions wl = TraverseWhileLoops(ss as WhileStatementSyntax, ref exitPoints, true);
                    retForEach.Nested.AddRange(wl.WhileLoops);
                    //wl.IsNested = true;
                    //retForEach.Nested.Add(wl);
                }
                //else if (ss is YieldStatementSyntax)
                //{
                //}
            }
            #endregion
            retDecision.ForEachStatements.Add(retForEach);
            return retDecision;
        }

        private Decisions TraverseDoStatements(DoStatementSyntax dss, ref int exitPoints, bool nested = false)
        {
            Decisions retDecision = new Decisions();
            DoWhileLoop retDo = new DoWhileLoop();
            ExpressionSyntax es = dss.Condition;
            var binaryExpressions = from aBinaryExpression in dss.Condition.DescendantNodesAndSelf().OfType<BinaryExpressionSyntax>() select aBinaryExpression;
            retDo.ConditionCount = binaryExpressions.Count();
            foreach (BinaryExpressionSyntax bes in binaryExpressions)
            {
                Method tempMethod = TraverseBinaryExpression(bes);
                retDo.AccessedVars.AddRange(tempMethod.AccessedVariables);
                retDo.InvokedMethods.AddRange(tempMethod.InvokedMethods);
            }
            var catches = from aCatch in dss.ChildNodes().OfType<CatchClauseSyntax>() select aCatch;
            foreach (CatchClauseSyntax ccs in catches)
            {
                Decisions tempCatch = TraverseCatchClauses(ccs, ref exitPoints, true);
                retDo.Nested.AddRange(tempCatch.Catches);
            }
            var statements = from aStatement in dss.Statement.ChildNodes().OfType<StatementSyntax>() select aStatement;
            List<BaseDecisions> retBd = new List<BaseDecisions>();
            List<InvokedMethod> retIm = new List<InvokedMethod>();
            #region Nested and Invoked Methods and accessed vars
            foreach (StatementSyntax ss in statements)
            {

                //if (ss is BreakStatementSyntax)
                //{
                //}
                //else if (ss is CheckedStatementSyntax)
                //{
                //}
                //else if (ss is ContinueStatementSyntax)
                //{
                //}
                if (ss is DoStatementSyntax)
                {
                    Decisions dwl = TraverseDoStatements(ss as DoStatementSyntax, ref exitPoints, true);
                    retDo.Nested.AddRange(dwl.DoWhileLoops);
                    //dwl.IsNested = true;
                    //retDo.Nested.Add(dwl);
                }
                //else if (ss is EmptyStatementSyntax)
                //{
                //}
                else if (ss is ExpressionStatementSyntax)
                {
                    Method tempMethod = TraverseExpressionStatementSyntax(ss as ExpressionStatementSyntax);
                    retDo.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    retDo.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                //else if (ss is FixedStatementSyntax)
                //{
                //}
                else if (ss is ForEachStatementSyntax)
                {
                    Decisions fes = TraverseForEachStatements(ss as ForEachStatementSyntax, ref exitPoints, true);
                    retDo.Nested.AddRange(fes.ForEachStatements);
                    //fes.IsNested = true;
                    //retDo.Nested.Add(fes);
                }
                else if (ss is ForStatementSyntax)
                {
                    Decisions fs = TraverseForStatements(ss as ForStatementSyntax, ref exitPoints, true);
                    retDo.Nested.AddRange(fs.ForStatements);
                    //fs.IsNested = true;
                    //retDo.Nested.Add(fs);
                }
                //else if (ss is GotoStatementSyntax)
                //{
                //}
                else if (ss is IfStatementSyntax)
                {
                    Decisions ifstm = TraverseIfStatements(ss as IfStatementSyntax, ref exitPoints, true);
                    retDo.Nested.AddRange(ifstm.IfStatements);
                    //ifstm.IsNested = true;
                    //retDo.Nested.Add(ifstm);
                }
                //else if (ss is LabeledStatementSyntax)
                //{
                //    BaseDecisions bd = new BaseDecisions();
                //    bd.IsNested = true;
                //    bd.Nested.Add(TraverseLabelStatements(ss as LabeledStatementSyntax));
                //    retIf.Nested.Add(bd);
                //}
                else if (ss is LocalDeclarationStatementSyntax)
                {
                    Method tempMethod = TransverseAccessVars(ss as LocalDeclarationStatementSyntax);
                    retDo.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    retDo.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                //else if (ss is LockStatementSyntax)
                //{
                //}
                //else if (ss is ReturnStatementSyntax)
                //{
                //}
                else if (ss is SwitchStatementSyntax)
                {
                    Decisions switchStm = TraverseSwitchStatements(ss as SwitchStatementSyntax, ref exitPoints, true);
                    retDo.Nested.AddRange(switchStm.SwitchStatements);
                    //switchStm.IsNested = true;
                    //retDo.Nested.Add(switchStm);
                }
                //else if (ss is ThrowStatementSyntax)
                //{
                //}
                //else if (ss is TryStatementSyntax)
                //{
                //}
                //else if (ss is UnsafeStatementSyntax)
                //{
                //}
                //else if (ss is UsingStatementSyntax)
                //{
                //    //using list?
                //}
                else if (ss is WhileStatementSyntax)
                {
                    Decisions wl = TraverseWhileLoops(ss as WhileStatementSyntax, ref exitPoints, true);
                    retDo.Nested.AddRange(wl.WhileLoops);
                    //wl.IsNested = true;
                    //retDo.Nested.Add(wl);
                }
                //else if (ss is YieldStatementSyntax)
                //{
                //}
            }
            #endregion
            retDecision.DoWhileLoops.Add(retDo);
            return retDecision;
        }

        private Method TraverseBinaryExpression(BinaryExpressionSyntax bes)
        {
            var variables = from aVariable in bes.ChildNodes().OfType<IdentifierNameSyntax>() select aVariable;
            Method retMethod = new Method();
            //Casting on the back end....ex:
            // abc = def as double ------- def as double is the binary expression
            if (bes.OperatorToken.IsKind(SyntaxKind.AsKeyword))
            {
                if (bes.Left is IdentifierNameSyntax)
                {
                    IdentifierNameSyntax ins = bes.Left as IdentifierNameSyntax;
                    Variables tempVar = new Variables();
                    tempVar.Name = ins.Identifier.ValueText;
                    if (bes.Right is PredefinedTypeSyntax)
                    {
                        PredefinedTypeSyntax pts = bes.Right as PredefinedTypeSyntax;
                        Model.Type tempType = new Model.Type();
                        tempType.Name = pts.ToString();
                        tempType.IsKnownType = true;
                        tempType.IsNotUserDefined = true;
                        tempVar.Type = tempType;
                    }
                    retMethod.AccessedVariables.Add(tempVar);
                }
                else if (bes.Left is MemberAccessExpressionSyntax)
                {
                    MemberAccessExpressionSyntax maes = bes.Left as MemberAccessExpressionSyntax;
                    Variables tempVar = new Variables();
                    tempVar.Name = maes.ToString();
                    tempVar.IsReferenced = true;
                    retMethod.AccessedVariables.Add(tempVar);
                }
            }
            else
            {
                foreach (IdentifierNameSyntax ins in variables)
                {
                    //TODO put a bp here and test if this adds method names (bad) or just var names(good)
                    Variables vars = new Variables();
                    vars.Name = ins.Identifier.ValueText;
                    vars.IsReferenced = true;
                    retMethod.AccessedVariables.Add(vars);
                    //TODO variable types
                }
                var binaryExprs = from aBinaryExpr in bes.ChildNodes().OfType<BinaryExpressionSyntax>() select aBinaryExpr;
                foreach (BinaryExpressionSyntax bes2 in binaryExprs)
                {
                    Method retMethod2 = TraverseBinaryExpression(bes2);
                    retMethod.AccessedVariables.AddRange(retMethod2.AccessedVariables);
                    retMethod.InvokedMethods.AddRange(retMethod2.InvokedMethods);
                }
                var invokedMethods = from aInvokedMethod in bes.ChildNodes().OfType<InvocationExpressionSyntax>() select aInvokedMethod;
                foreach (InvocationExpressionSyntax ies in invokedMethods)
                {
                    Method tempMethod = TraverseInvocationExpression(ies);
                    retMethod.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                    retMethod.AccessedVariables.AddRange(tempMethod.AccessedVariables);
                }
                var castExprs = from aCastExpr in bes.ChildNodes().OfType<CastExpressionSyntax>() select aCastExpr;
                foreach (CastExpressionSyntax ces in castExprs)
                {
                    Method retMethod3 = TraverseCastExpressions(ces);
                    retMethod.AccessedVariables.AddRange(retMethod3.AccessedVariables);
                    retMethod.InvokedMethods.AddRange(retMethod3.InvokedMethods);
                }
            }
            return retMethod;
            
        }

        private Method TraverseCastExpressions(CastExpressionSyntax ces)
        {
            Method retMethod = new Method();
            var variables = from aVariable in ces.ChildNodes().OfType<IdentifierNameSyntax>() select aVariable;
            Model.Type type = new Model.Type();
            type.Name = ces.Type.ToString();
            type.IsKnownType = SyntaxFacts.IsKeywordKind(ces.Type.CSharpKind());
            type.IsNotUserDefined = SyntaxFacts.IsKeywordKind(ces.Type.CSharpKind());
            foreach (IdentifierNameSyntax ins in variables)
            {
                //TODO put a bp here and test if this adds method names (bad) or just var names(good)
                Variables vars = new Variables();
                vars.Name = ins.Identifier.ValueText;
                vars.IsReferenced = true;
                vars.Type = type;
                retMethod.AccessedVariables.Add(vars);
            }
            var binaryExprs = from aBinaryExpr in ces.ChildNodes().OfType<BinaryExpressionSyntax>() select aBinaryExpr;
            foreach (BinaryExpressionSyntax bes in binaryExprs)
            {
                Method retMethod2 = TraverseBinaryExpression(bes);
                retMethod.AccessedVariables.AddRange(retMethod2.AccessedVariables);
                retMethod.InvokedMethods.AddRange(retMethod2.InvokedMethods);
            }
            var invokedMethods = from aInvokedMethod in ces.ChildNodes().OfType<InvocationExpressionSyntax>() select aInvokedMethod;
            foreach (InvocationExpressionSyntax ies in invokedMethods)
            {
                Method tempMethod = TraverseInvocationExpression(ies);
                retMethod.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                retMethod.AccessedVariables.AddRange(tempMethod.AccessedVariables);
            }
            var castExprs = from aCastExpr in ces.ChildNodes().OfType<CastExpressionSyntax>() select aCastExpr;
            foreach (CastExpressionSyntax ces2 in castExprs)
            {
                Method retMethod3 = TraverseCastExpressions(ces2);
                retMethod.AccessedVariables.AddRange(retMethod3.AccessedVariables);
                retMethod.InvokedMethods.AddRange(retMethod3.InvokedMethods);
            }
            return retMethod;
        }

        private Method TransverseAccessVars(LocalDeclarationStatementSyntax ldss)
        {
            Method retMethod = new Method();
            List<Encapsulation> accessability = new List<Encapsulation>();
            List<Qualifiers> qualifiers = new List<Qualifiers>();
            foreach (SyntaxToken st in ldss.Modifiers)
            {
                string modifier = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(st.ValueText);
                Encapsulation encap;
                Qualifiers qual;
                if (System.Enum.TryParse<Encapsulation>(modifier, out encap))
                {
                    accessability.Add(encap);
                }
                else if (System.Enum.TryParse<Qualifiers>(modifier, out qual))
                {
                    qualifiers.Add(qual);
                }
            }
            retMethod.Qualifiers.AddRange(qualifiers);
            retMethod.Encapsulation.AddRange(accessability);
            VariableDeclarationSyntax varDecl = ldss.Declaration;
            Model.Type tempType = new Model.Type();
            if(varDecl.Type is PredefinedTypeSyntax)
            {
                tempType.Name = varDecl.Type.ToString();
                tempType.IsKnownType = true;
                tempType.IsNotUserDefined = true;
            }
            var vars = from aVar in varDecl.ChildNodes().OfType<VariableDeclaratorSyntax>() select aVar;
            foreach (VariableDeclaratorSyntax vds in vars)
            {
                //Variables retVar = new Variables();
                Method tempMethod = TraverseVarDeclarators(vds);
                foreach (Variables vrs in tempMethod.AccessedVariables)
                {
                    vrs.Type = tempType;
                }
                retMethod.AccessedVariables.AddRange(tempMethod.AccessedVariables);
                if (vds.Initializer != null)
                {
                    var castStatements = from aCastStatement in vds.Initializer.Value.ChildNodes().OfType<CastExpressionSyntax>() select aCastStatement;
                    foreach (CastExpressionSyntax ces in castStatements)
                    {
                        Method retCast = TraverseCastExpressions(ces);
                        retMethod.AccessedVariables.AddRange(retCast.AccessedVariables);
                        retMethod.InvokedMethods.AddRange(retCast.InvokedMethods);
                    }
                }
            }

            return retMethod;
        }

        private Method TraverseVarDeclarators(VariableDeclaratorSyntax vds)
        {
            Method retMethod = new Method();
            Variables retVar = new Variables();
            retVar.Name = vds.Identifier.ValueText;
            Model.Type retType = new Model.Type();
            retType.IsKnownType = SyntaxFacts.IsKeywordKind(vds.CSharpKind());
            retType.IsNotUserDefined = SyntaxFacts.IsKeywordKind(vds.CSharpKind());
            retVar.Type = retType;
            retMethod.AccessedVariables.Add(retVar);
            var valueClauses = from aValueClase in vds.ChildNodes().OfType<EqualsValueClauseSyntax>() select aValueClase;
            foreach (EqualsValueClauseSyntax evcs in valueClauses)
            {
                retMethod.AccessedVariables.AddRange(TraverseEqualsClause(evcs).AccessedVariables);
            }
            //TODO
            //Don't know if I need more stuff here
            //or even if i can fetch it from vds
            return retMethod;
        }

        private Method TraverseEqualsClause(EqualsValueClauseSyntax evcs)
        {
            Method retMethod = new Method();
            var binaryExprs = from aBinaryExpr in evcs.ChildNodes().OfType<BinaryExpressionSyntax>() select aBinaryExpr;
            foreach(BinaryExpressionSyntax bes in binaryExprs)
            {
                Method tempMethod = TraverseBinaryExpression(bes);
                retMethod.AccessedVariables.AddRange(tempMethod.AccessedVariables);
                retMethod.InvokedMethods.AddRange(tempMethod.InvokedMethods);
            }
            var castExprs = from aCastExpr in evcs.ChildNodes().OfType<CastExpressionSyntax>() select aCastExpr;
            foreach (CastExpressionSyntax ces in castExprs)
            {
                Method tempMethod = TraverseCastExpressions(ces);
                retMethod.AccessedVariables.AddRange(tempMethod.AccessedVariables);
                retMethod.InvokedMethods.AddRange(tempMethod.InvokedMethods);
            }
            return retMethod;
        }

        private GoTo TraverseGoToStatements(GotoStatementSyntax gtss)
        {
            GoTo retGoTo = new GoTo();

            var labelStatements = from aLabelStatement in gtss.ChildNodes().OfType<LabeledStatementSyntax>() select aLabelStatement;

            foreach (LabeledStatementSyntax lss in labelStatements)
            {
                retGoTo.GoToLabel = TraverseLabelStatements(lss);
            }

            return retGoTo;
        }

        private LabelStatement TraverseLabelStatements(LabeledStatementSyntax lss)
        {
            LabelStatement retLabelStatement = new LabelStatement();
            retLabelStatement.Name = lss.Identifier.ValueText;
            return retLabelStatement;
        }

        private Variables TraverseParamaters(ParameterSyntax ps, bool isRef = false)
        {
            Variables retVar = new Variables();
            retVar.IsReferenced = isRef;
            TypeSyntax ts = ps.Type;
            //Breakpoint here to test return type!
            Model.Type retType = new Model.Type();
            retType.Name = ts.ToString();
            retType.IsKnownType = SyntaxFacts.IsKeywordKind(ts.CSharpKind());
            retType.IsNotUserDefined = SyntaxFacts.IsKeywordKind(ts.CSharpKind());
            //rettype.generictype
            retVar.Type = retType;

            foreach (SyntaxToken st in ps.Modifiers)
            {
                string modifier = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(st.ValueText);
                Encapsulation encap;
                Qualifiers qual;
                if (System.Enum.TryParse<Encapsulation>(modifier, out encap))
                {
                    retVar.Accessibility.Add(encap);
                }
                else if (System.Enum.TryParse<Qualifiers>(modifier, out qual))
                {
                    retVar.Qualifiers.Add(qual);
                }
                else if (modifier == "Ref")
                {
                    //TODO handle ref
                }
            }
            //need retvar's name
            //TODO check if this actually works
            retVar.Name = ps.Identifier.ValueText;
            return retVar;
        }

        private Variables TransverseVariables(FieldDeclarationSyntax fds, bool isRef = false)
        {
            Variables retVar = new Variables();
            retVar.IsReferenced = isRef;
            //Not sure if right
            retVar.Type.IsKnownType = SyntaxFacts.IsKeywordKind(fds.CSharpKind());
            retVar.Type.IsNotUserDefined = SyntaxFacts.IsKeywordKind(fds.CSharpKind());
            //This should pick up the "type" name
            retVar.Type.Name = fds.Declaration.Type.ToString();

            foreach (SyntaxToken st in fds.Modifiers)
            {
                string modifier = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(st.ValueText);
                Encapsulation encap;
                Qualifiers qual;
                if (System.Enum.TryParse<Encapsulation>(modifier, out encap))
                {
                    retVar.Accessibility.Add(encap);
                }
                else if (System.Enum.TryParse<Qualifiers>(modifier, out qual))
                {
                    retVar.Qualifiers.Add(qual);
                }
            }
            //This does return variable name but I don't know if fds can contain a list of
            //variables or if it will always be 1
            retVar.Name = fds.Declaration.Variables.ToString();
            return retVar;
        }

        private Constructor TransverseConstructors(ConstructorDeclarationSyntax cds)
        {
            Constructor retConstructor = new Constructor();
            //public int DecisionsCount { get; }
            //public int ExitPoints { get; set; }
            //public bool IsFriend { get; }
            //public bool IsPolymophic { get; }
            //public bool IsPublic { get; }
            //public bool IsStatic { get; }
            //public List<Preprocessor> Preprocessors { get; set; }
            retConstructor.Name = cds.Identifier.ValueText;

            foreach (SyntaxToken st in cds.Modifiers)
            {
                string modifier = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(st.ValueText);
                Encapsulation encap;
                Qualifiers qual;
                if (System.Enum.TryParse<Encapsulation>(modifier, out encap))
                {
                    retConstructor.Encapsulation.Add(encap);
                }
                else if (System.Enum.TryParse<Qualifiers>(modifier, out qual))
                {
                    retConstructor.Qualifiers.Add(qual);
                }
            }

            //TypeSyntax ts = cds.ReturnType;
            //Model.Type retType = new Model.Type();
            //retType.Name = ts.ToString();
            //retType.IsKnownType = ts.Kind.IsKeywordKind();
            //retType.IsNotUserDefined = ts.Kind.IsKeywordKind();
            //TODO
            //rettype.generictype
            //retConstructor.ReturnType = retType;

            ParameterListSyntax pls = cds.ParameterList;
            foreach (ParameterSyntax ps in pls.Parameters)
            {
                retConstructor.Parameters.Add(TraverseParamaters(ps));
            }
            BlockSyntax bs = cds.Body;
            var labelStatements = from aLabelStatement in bs.ChildNodes().OfType<LabeledStatementSyntax>() select aLabelStatement;
            foreach (LabeledStatementSyntax lss in labelStatements)
            {
                retConstructor.LabelStatements.Add(TraverseLabelStatements(lss));
            }

            var goToStatements = from aGoToStatement in bs.ChildNodes().OfType<GotoStatementSyntax>() select aGoToStatement;
            foreach (GotoStatementSyntax gtss in goToStatements)
            {
                GoTo gt = TraverseGoToStatements(gtss);
                retConstructor.GoToStatements.Add(gt);
            }

            //Preprocessors = new List<Preprocessor>();
            //Base = new List<InvokedMethod>();
            //Decisions = new Decisions();

            var accessVarsDecl = from aAccessVarsDecl in bs.ChildNodes().OfType<LocalDeclarationStatementSyntax>() select aAccessVarsDecl;
            foreach (LocalDeclarationStatementSyntax ldss in accessVarsDecl)
            {
                Method tempMethod = TransverseAccessVars(ldss);
                retConstructor.AccessedVariables.AddRange(tempMethod.AccessedVariables);
                retConstructor.InvokedMethods.AddRange(tempMethod.InvokedMethods);
            }

            var ifStatements = from aIfStatement in bs.ChildNodes().OfType<IfStatementSyntax>() select aIfStatement;
            foreach (IfStatementSyntax iss in ifStatements)
            {
                int exitPoints = retConstructor.ExitPoints;
                Decisions tempDecision = TraverseIfStatements(iss, ref exitPoints);
                retConstructor.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                retConstructor.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                retConstructor.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                retConstructor.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                retConstructor.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                retConstructor.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                retConstructor.Decisions.Catches.AddRange(tempDecision.Catches);
                retConstructor.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                retConstructor.ExitPoints = exitPoints;
            }
            var elseStatements = from aElseStatements in bs.ChildNodes().OfType<ElseClauseSyntax>() select aElseStatements;
            foreach (ElseClauseSyntax ecs in elseStatements)
            {
                int exitPoints = retConstructor.ExitPoints;
                Decisions tempDecision = TraverseElseClauses(ecs, ref exitPoints);
                retConstructor.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                retConstructor.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                retConstructor.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                retConstructor.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                retConstructor.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                retConstructor.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                retConstructor.Decisions.Catches.AddRange(tempDecision.Catches);
                retConstructor.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                retConstructor.ExitPoints = exitPoints;
            }
            var whileLoops = from aWhileLoop in bs.ChildNodes().OfType<WhileStatementSyntax>() select aWhileLoop;
            foreach (WhileStatementSyntax wss in whileLoops)
            {
                int exitPoints = retConstructor.ExitPoints;
                Decisions tempDecision = TraverseWhileLoops(wss, ref exitPoints);
                retConstructor.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                retConstructor.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                retConstructor.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                retConstructor.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                retConstructor.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                retConstructor.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                retConstructor.Decisions.Catches.AddRange(tempDecision.Catches);
                retConstructor.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                retConstructor.ExitPoints = exitPoints;
            }
            var doWhileLoops = from aDoWhileLoop in bs.ChildNodes().OfType<DoStatementSyntax>() select aDoWhileLoop;
            foreach (DoStatementSyntax dss in doWhileLoops)
            {
                int exitPoints = retConstructor.ExitPoints;
                Decisions tempDecision = TraverseDoStatements(dss, ref exitPoints);
                retConstructor.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                retConstructor.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                retConstructor.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                retConstructor.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                retConstructor.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                retConstructor.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                retConstructor.Decisions.Catches.AddRange(tempDecision.Catches);
                retConstructor.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                retConstructor.ExitPoints = exitPoints;
            }
            var forLoops = from aForLoop in bs.ChildNodes().OfType<ForStatementSyntax>() select aForLoop;
            foreach (ForStatementSyntax fss in forLoops)
            {
                int exitPoints = retConstructor.ExitPoints;
                Decisions tempDecision = TraverseForStatements(fss, ref exitPoints);
                retConstructor.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                retConstructor.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                retConstructor.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                retConstructor.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                retConstructor.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                retConstructor.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                retConstructor.Decisions.Catches.AddRange(tempDecision.Catches);
                retConstructor.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                retConstructor.ExitPoints = exitPoints;
            }
            var foreachLoops = from aForeachLoop in bs.ChildNodes().OfType<ForEachStatementSyntax>() select aForeachLoop;
            foreach(ForEachStatementSyntax fess in foreachLoops)
            {
                int exitPoints = retConstructor.ExitPoints;
                Decisions tempDecision = TraverseForEachStatements(fess, ref exitPoints);
                retConstructor.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                retConstructor.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                retConstructor.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                retConstructor.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                retConstructor.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                retConstructor.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                retConstructor.Decisions.Catches.AddRange(tempDecision.Catches);
                retConstructor.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                retConstructor.ExitPoints = exitPoints;
            }
            var switches = from aSwitch in bs.ChildNodes().OfType<SwitchStatementSyntax>() select aSwitch;
            foreach (SwitchStatementSyntax sss in switches)
            {
                int exitPoints = retConstructor.ExitPoints;
                Decisions tempDecision = TraverseSwitchStatements(sss, ref exitPoints);
                retConstructor.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                retConstructor.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                retConstructor.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                retConstructor.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                retConstructor.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                retConstructor.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                retConstructor.Decisions.Catches.AddRange(tempDecision.Catches);
                retConstructor.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                retConstructor.ExitPoints = exitPoints;
            }
            var catches = from aCatch in bs.ChildNodes().OfType<CatchClauseSyntax>() select aCatch;
            foreach (CatchClauseSyntax ccs in catches)
            {
                int exitPoints = retConstructor.ExitPoints;
                Decisions tempDecision = TraverseCatchClauses(ccs, ref exitPoints);
                retConstructor.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                retConstructor.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                retConstructor.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                retConstructor.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                retConstructor.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                retConstructor.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                retConstructor.Decisions.Catches.AddRange(tempDecision.Catches);
                retConstructor.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                retConstructor.ExitPoints = exitPoints;
            }
            var breaks = from aBreak in bs.ChildNodes().OfType<BreakStatementSyntax>() select aBreak;
            foreach(BreakStatementSyntax bss in breaks)
            {
                //TODO get breaks
                //note that breaks are NOT in retMethod.Decisions
            }
            var checks = from aCheck in bs.ChildNodes().OfType<CheckedStatementSyntax>() select aCheck;
            foreach(CheckedStatementSyntax css in checks)
            {
                //TODO get checks
                //note that checks are NOT in retMethod.Decisions
            }
            var continues = from aContinue in bs.ChildNodes().OfType<ContinueStatementSyntax>() select aContinue;
            foreach(ContinueStatementSyntax css in continues)
            {
                //TODO get continues
                //note that continues are NOT in retMethod.Decisions
            }
            var emptys = from aEmpty in bs.ChildNodes().OfType<EmptyStatementSyntax>() select aEmpty;
            foreach(EmptyStatementSyntax ess in emptys)
            {
                //TODO get emptys
                //note that emptys are NOT in retMethod.Decisions
            }
            var exprs = from aExpr in bs.ChildNodes().OfType<ExpressionStatementSyntax>() select aExpr;
            foreach(ExpressionStatementSyntax ess in exprs)
            {
                //TODO get expressions
                //note that expressions are NOT in retMethod.Decisions
            }
            var fixeds = from aFixed in bs.ChildNodes().OfType<FixedStatementSyntax>() select aFixed;
            foreach(FixedStatementSyntax fss in fixeds)
            {
                //TODO get fixed
                //note that these are NOT in retMethod.Decisions
            }
            var locks = from aLock in bs.ChildNodes().OfType<LockStatementSyntax>() select aLock;
            foreach(LockStatementSyntax lss in locks)
            {
                //TODO get lock
                //note that these are NOT in retMethod.Decisions
            }
            var returns = from aReturn in bs.ChildNodes().OfType<ReturnStatementSyntax>() select aReturn;
            foreach(ReturnStatementSyntax rss in returns)
            {
                //TODO get returns
                //note that these are NOT in retMethod.Decisions
            }
            var throws = from aThrow in bs.ChildNodes().OfType<ThrowStatementSyntax>() select aThrow;
            foreach(ThrowStatementSyntax tss in throws)
            {
                //TODO get throws
                //note that these are NOT in retMethod.Decisions
            }
            var trys = from aTry in bs.ChildNodes().OfType<TryStatementSyntax>() select aTry;
            foreach(TryStatementSyntax tss in trys)
            {
                //TODO get trys
                //note that these are NOT in retMethod.Decisions
            }
            var unsafes = from aUnsafe in bs.ChildNodes().OfType<UnsafeStatementSyntax>() select aUnsafe;
            foreach(UnsafeStatementSyntax uss in unsafes)
            {
                //TODO get unsafes
                //note that these are NOT in retMethod.Decisions
            }
            var usings = from aUsing in bs.ChildNodes().OfType<UsingStatementSyntax>() select aUsing;
            foreach(UsingStatementSyntax uss in usings)
            {
                //TODO get usings
                //note that these are NOT in retMethod.Decisions
            }
            var yields = from aYield in bs.ChildNodes().OfType<YieldStatementSyntax>() select aYield;
            foreach(YieldStatementSyntax yss in yields)
            {
                //TODO get yields
                //note that these are NOT in retMethod.Decisions
            }
            var invokedMethods = from aInvokedMethod in bs.ChildNodes().OfType<InvocationExpressionSyntax>() select aInvokedMethod;
            foreach(InvocationExpressionSyntax ies in invokedMethods)
            {
                Method tempMethod = TraverseInvocationExpression(ies);
                retConstructor.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                retConstructor.AccessedVariables.AddRange(tempMethod.AccessedVariables);
            }

            //InvokedMethods = new List<InvokedMethod>();
            return retConstructor;
        }

        private Destructor TransverseDestructors(DestructorDeclarationSyntax dds)
        {
            Destructor retDestructor = new Destructor();
            //public int DecisionsCount { get; }
            //public int ExitPoints { get; set; }
            //public bool IsFriend { get; }
            //public bool IsPolymophic { get; }
            //public bool IsPublic { get; }
            //public bool IsStatic { get; }
            //public List<Preprocessor> Preprocessors { get; set; }
            retDestructor.Name = dds.Identifier.ValueText;

            foreach (SyntaxToken st in dds.Modifiers)
            {
                string modifier = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(st.ValueText);
                Encapsulation encap;
                Qualifiers qual;
                if (System.Enum.TryParse<Encapsulation>(modifier, out encap))
                {
                    retDestructor.Encapsulation.Add(encap);
                }
                else if (System.Enum.TryParse<Qualifiers>(modifier, out qual))
                {
                    retDestructor.Qualifiers.Add(qual);
                }
            }

            //TypeSyntax ts = cds.ReturnType;
            //Model.Type retType = new Model.Type();
            //retType.Name = ts.ToString();
            //retType.IsKnownType = ts.Kind.IsKeywordKind();
            //retType.IsNotUserDefined = ts.Kind.IsKeywordKind();
            //TODO
            //rettype.generictype
            //retDestructor.ReturnType = retType;

            ParameterListSyntax pls = dds.ParameterList;
            foreach (ParameterSyntax ps in pls.Parameters)
            {
                retDestructor.Parameters.Add(TraverseParamaters(ps));
            }
            BlockSyntax bs = dds.Body;
            var labelStatements = from aLabelStatement in bs.ChildNodes().OfType<LabeledStatementSyntax>() select aLabelStatement;
            foreach (LabeledStatementSyntax lss in labelStatements)
            {
                retDestructor.LabelStatements.Add(TraverseLabelStatements(lss));
            }

            var goToStatements = from aGoToStatement in bs.ChildNodes().OfType<GotoStatementSyntax>() select aGoToStatement;
            foreach (GotoStatementSyntax gtss in goToStatements)
            {
                GoTo gt = TraverseGoToStatements(gtss);
                retDestructor.GoToStatements.Add(gt);
            }

            //Preprocessors = new List<Preprocessor>();
            //Base = new List<InvokedMethod>();
            //Decisions = new Decisions();

            var accessVarsDecl = from aAccessVarsDecl in bs.ChildNodes().OfType<LocalDeclarationStatementSyntax>() select aAccessVarsDecl;
            foreach (LocalDeclarationStatementSyntax ldss in accessVarsDecl)
            {
                Method tempMethod = TransverseAccessVars(ldss);
                retDestructor.AccessedVariables.AddRange(tempMethod.AccessedVariables);
                retDestructor.InvokedMethods.AddRange(tempMethod.InvokedMethods);
            }

            var ifStatements = from aIfStatement in bs.ChildNodes().OfType<IfStatementSyntax>() select aIfStatement;
            foreach (IfStatementSyntax iss in ifStatements)
            {
                int exitPoints = retDestructor.ExitPoints;
                Decisions tempDecision = TraverseIfStatements(iss, ref exitPoints);
                retDestructor.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                retDestructor.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                retDestructor.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                retDestructor.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                retDestructor.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                retDestructor.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                retDestructor.Decisions.Catches.AddRange(tempDecision.Catches);
                retDestructor.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                retDestructor.ExitPoints = exitPoints;
            }
            var elseStatements = from aElseStatements in bs.ChildNodes().OfType<ElseClauseSyntax>() select aElseStatements;
            foreach (ElseClauseSyntax ecs in elseStatements)
            {
                int exitPoints = retDestructor.ExitPoints;
                Decisions tempDecision = TraverseElseClauses(ecs, ref exitPoints);
                retDestructor.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                retDestructor.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                retDestructor.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                retDestructor.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                retDestructor.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                retDestructor.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                retDestructor.Decisions.Catches.AddRange(tempDecision.Catches);
                retDestructor.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                retDestructor.ExitPoints = exitPoints;
            }
            var whileLoops = from aWhileLoop in bs.ChildNodes().OfType<WhileStatementSyntax>() select aWhileLoop;
            foreach (WhileStatementSyntax wss in whileLoops)
            {
                int exitPoints = retDestructor.ExitPoints;
                Decisions tempDecision = TraverseWhileLoops(wss, ref exitPoints);
                retDestructor.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                retDestructor.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                retDestructor.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                retDestructor.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                retDestructor.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                retDestructor.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                retDestructor.Decisions.Catches.AddRange(tempDecision.Catches);
                retDestructor.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                retDestructor.ExitPoints = exitPoints;
            }
            var doWhileLoops = from aDoWhileLoop in bs.ChildNodes().OfType<DoStatementSyntax>() select aDoWhileLoop;
            foreach (DoStatementSyntax dss in doWhileLoops)
            {
                int exitPoints = retDestructor.ExitPoints;
                Decisions tempDecision = TraverseDoStatements(dss, ref exitPoints);
                retDestructor.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                retDestructor.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                retDestructor.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                retDestructor.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                retDestructor.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                retDestructor.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                retDestructor.Decisions.Catches.AddRange(tempDecision.Catches);
                retDestructor.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                retDestructor.ExitPoints = exitPoints;
            }
            var forLoops = from aForLoop in bs.ChildNodes().OfType<ForStatementSyntax>() select aForLoop;
            foreach (ForStatementSyntax fss in forLoops)
            {
                int exitPoints = retDestructor.ExitPoints;
                Decisions tempDecision = TraverseForStatements(fss, ref exitPoints);
                retDestructor.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                retDestructor.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                retDestructor.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                retDestructor.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                retDestructor.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                retDestructor.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                retDestructor.Decisions.Catches.AddRange(tempDecision.Catches);
                retDestructor.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                retDestructor.ExitPoints = exitPoints;
            }
            var foreachLoops = from aForeachLoop in bs.ChildNodes().OfType<ForEachStatementSyntax>() select aForeachLoop;
            foreach (ForEachStatementSyntax fess in foreachLoops)
            {
                int exitPoints = retDestructor.ExitPoints;
                Decisions tempDecision = TraverseForEachStatements(fess, ref exitPoints);
                retDestructor.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                retDestructor.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                retDestructor.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                retDestructor.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                retDestructor.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                retDestructor.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                retDestructor.Decisions.Catches.AddRange(tempDecision.Catches);
                retDestructor.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                retDestructor.ExitPoints = exitPoints;
            }
            var switches = from aSwitch in bs.ChildNodes().OfType<SwitchStatementSyntax>() select aSwitch;
            foreach (SwitchStatementSyntax sss in switches)
            {
                int exitPoints = retDestructor.ExitPoints;
                Decisions tempDecision = TraverseSwitchStatements(sss, ref exitPoints);
                retDestructor.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                retDestructor.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                retDestructor.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                retDestructor.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                retDestructor.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                retDestructor.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                retDestructor.Decisions.Catches.AddRange(tempDecision.Catches);
                retDestructor.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                retDestructor.ExitPoints = exitPoints;
            }
            var catches = from aCatch in bs.ChildNodes().OfType<CatchClauseSyntax>() select aCatch;
            foreach (CatchClauseSyntax ccs in catches)
            {
                int exitPoints = retDestructor.ExitPoints;
                Decisions tempDecision = TraverseCatchClauses(ccs, ref exitPoints);
                retDestructor.Decisions.IfStatements.AddRange(tempDecision.IfStatements);
                retDestructor.Decisions.ElseStatements.AddRange(tempDecision.ElseStatements);
                retDestructor.Decisions.ForEachStatements.AddRange(tempDecision.ForEachStatements);
                retDestructor.Decisions.ForStatements.AddRange(tempDecision.ForStatements);
                retDestructor.Decisions.WhileLoops.AddRange(tempDecision.WhileLoops);
                retDestructor.Decisions.DoWhileLoops.AddRange(tempDecision.DoWhileLoops);
                retDestructor.Decisions.Catches.AddRange(tempDecision.Catches);
                retDestructor.Decisions.SwitchStatements.AddRange(tempDecision.SwitchStatements);
                retDestructor.ExitPoints = exitPoints;
            }
            var breaks = from aBreak in bs.ChildNodes().OfType<BreakStatementSyntax>() select aBreak;
            foreach (BreakStatementSyntax bss in breaks)
            {
                //TODO get breaks
                //note that breaks are NOT in retMethod.Decisions
            }
            var checks = from aCheck in bs.ChildNodes().OfType<CheckedStatementSyntax>() select aCheck;
            foreach (CheckedStatementSyntax css in checks)
            {
                //TODO get checks
                //note that checks are NOT in retMethod.Decisions
            }
            var continues = from aContinue in bs.ChildNodes().OfType<ContinueStatementSyntax>() select aContinue;
            foreach (ContinueStatementSyntax css in continues)
            {
                //TODO get continues
                //note that continues are NOT in retMethod.Decisions
            }
            var emptys = from aEmpty in bs.ChildNodes().OfType<EmptyStatementSyntax>() select aEmpty;
            foreach (EmptyStatementSyntax ess in emptys)
            {
                //TODO get emptys
                //note that emptys are NOT in retMethod.Decisions
            }
            var exprs = from aExpr in bs.ChildNodes().OfType<ExpressionStatementSyntax>() select aExpr;
            foreach (ExpressionStatementSyntax ess in exprs)
            {
                //TODO get expressions
                //note that expressions are NOT in retMethod.Decisions
            }
            var fixeds = from aFixed in bs.ChildNodes().OfType<FixedStatementSyntax>() select aFixed;
            foreach (FixedStatementSyntax fss in fixeds)
            {
                //TODO get fixed
                //note that these are NOT in retMethod.Decisions
            }
            var locks = from aLock in bs.ChildNodes().OfType<LockStatementSyntax>() select aLock;
            foreach (LockStatementSyntax lss in locks)
            {
                //TODO get lock
                //note that these are NOT in retMethod.Decisions
            }
            var returns = from aReturn in bs.ChildNodes().OfType<ReturnStatementSyntax>() select aReturn;
            foreach (ReturnStatementSyntax rss in returns)
            {
                //TODO get returns
                //note that these are NOT in retMethod.Decisions
            }
            var throws = from aThrow in bs.ChildNodes().OfType<ThrowStatementSyntax>() select aThrow;
            foreach (ThrowStatementSyntax tss in throws)
            {
                //TODO get throws
                //note that these are NOT in retMethod.Decisions
            }
            var trys = from aTry in bs.ChildNodes().OfType<TryStatementSyntax>() select aTry;
            foreach (TryStatementSyntax tss in trys)
            {
                //TODO get trys
                //note that these are NOT in retMethod.Decisions
            }
            var unsafes = from aUnsafe in bs.ChildNodes().OfType<UnsafeStatementSyntax>() select aUnsafe;
            foreach (UnsafeStatementSyntax uss in unsafes)
            {
                //TODO get unsafes
                //note that these are NOT in retMethod.Decisions
            }
            var usings = from aUsing in bs.ChildNodes().OfType<UsingStatementSyntax>() select aUsing;
            foreach (UsingStatementSyntax uss in usings)
            {
                //TODO get usings
                //note that these are NOT in retMethod.Decisions
            }
            var yields = from aYield in bs.ChildNodes().OfType<YieldStatementSyntax>() select aYield;
            foreach (YieldStatementSyntax yss in yields)
            {
                //TODO get yields
                //note that these are NOT in retMethod.Decisions
            }
            var invokedMethods = from aInvokedMethod in bs.ChildNodes().OfType<InvocationExpressionSyntax>() select aInvokedMethod;
            foreach (InvocationExpressionSyntax ies in invokedMethods)
            {
                Method tempMethod = TraverseInvocationExpression(ies);
                retDestructor.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                retDestructor.AccessedVariables.AddRange(tempMethod.AccessedVariables);
            }

            //InvokedMethods = new List<InvokedMethod>();
            return retDestructor;
        }

        private Interface TraverseInterface(InterfaceDeclarationSyntax ids)
        {
            Interface retInterface = new Interface();
            foreach (SyntaxToken st in ids.Modifiers)
            {
                string modifier = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(st.ValueText);
                Encapsulation encap;
                Qualifiers qual;
                if (System.Enum.TryParse<Encapsulation>(modifier, out encap))
                {
                    retInterface.Encapsulation.Add(encap);
                }
                else if (System.Enum.TryParse<Qualifiers>(modifier, out qual))
                {
                    retInterface.Qualifiers.Add(qual);
                }
            }
            var accessVarsDecl = from aAccessVarsDecl in ids.ChildNodes().OfType<LocalDeclarationStatementSyntax>() select aAccessVarsDecl;
            foreach (LocalDeclarationStatementSyntax ldss in accessVarsDecl)
            {
                Method tempMethod = TransverseAccessVars(ldss);
                retInterface.Fields.AddRange(tempMethod.AccessedVariables);
                //retInterface.Methods.AddRange(tempMethod.InvokedMethods);
            }
            var interfaces = from aInterface in ids.ChildNodes().OfType<InterfaceDeclarationSyntax>() select aInterface;
            foreach (InterfaceDeclarationSyntax ids2 in interfaces)
            {
                Interface tempInterface = TraverseInterface(ids2);
                retInterface.InheritsInterfaces.Add(tempInterface);
            }
            retInterface.Name = ids.Identifier.ValueText;
            var methods = from aMethod in ids.ChildNodes().OfType<MethodDeclarationSyntax>() select aMethod;
            foreach (MethodDeclarationSyntax mds in methods)
            {
                Method tempMethod = TransverseMethods(mds);
                retInterface.Fields.AddRange(tempMethod.AccessedVariables);
                retInterface.Methods.Add(tempMethod);
            }
            //public List<string> InheritsStrings { get; set; }
            //public List<Property> Properties { get; set; }
            return retInterface;
        }
    }
}
