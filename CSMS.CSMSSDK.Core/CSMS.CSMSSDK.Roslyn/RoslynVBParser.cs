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

using CSMS.CSMSSDK.Model;
using System.Collections.Generic;
using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic.Syntax;
using Microsoft.CodeAnalysis.VisualBasic;

namespace CSMS.CSMSSDK.Roslyn
{
    public class RoslynVBParser
    {
        private SyntaxTree mTree;
        private CompilationUnitSyntax mRoot;
        public Model.ParsingResults ParseSource(string filename)
        {
            try
            {
                mTree = VisualBasicSyntaxTree.ParseFile(filename);
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

            List<DelegateStatementSyntax> delegates = new List<DelegateStatementSyntax>();
            List<EventBlockSyntax> delegates2 = new List<EventBlockSyntax>();
            List<InterfaceBlockSyntax> interfaces = new List<InterfaceBlockSyntax>();
            List<EnumBlockSyntax> enums = new List<EnumBlockSyntax>();
            List<StructureBlockSyntax> structs = new List<StructureBlockSyntax>();
            List<MethodBlockSyntax> methods = new List<MethodBlockSyntax>();
            List<ConstructorBlockSyntax> constructors = new List<ConstructorBlockSyntax>();
            List<ModuleBlockSyntax> modules = new List<ModuleBlockSyntax>();
            List<ClassBlockSyntax> classes = new List<ClassBlockSyntax>();
            List<NamespaceBlockSyntax> namespaces = new List<NamespaceBlockSyntax>();

            foreach (SyntaxNode sn in mRoot.ChildNodes())
            {
                if (sn is DelegateStatementSyntax)
                {
                    delegates.Add(sn as DelegateStatementSyntax);
                }
                if (sn is EventBlockSyntax)
                {
                    delegates2.Add(sn as EventBlockSyntax);
                }
                else if (sn is InterfaceBlockSyntax)
                {
                    interfaces.Add(sn as InterfaceBlockSyntax);
                }
                if (sn is EnumBlockSyntax)
                {
                    enums.Add(sn as EnumBlockSyntax);
                }
                else if (sn is StructureBlockSyntax)
                {
                    structs.Add(sn as StructureBlockSyntax);
                }
                else if (sn is MethodBlockSyntax)
                {
                    methods.Add(sn as MethodBlockSyntax);
                }
                else if (sn is ConstructorBlockSyntax)
                {
                    constructors.Add(sn as ConstructorBlockSyntax);
                }
                else if (sn is ModuleBlockSyntax)
                {
                    modules.Add(sn as ModuleBlockSyntax);
                }
                else if (sn is ClassBlockSyntax)
                {
                    classes.Add(sn as ClassBlockSyntax);
                }
                else if (sn is NamespaceBlockSyntax)
                {
                    namespaces.Add(sn as NamespaceBlockSyntax);
                }
            }

            foreach (EnumBlockSyntax ebs in enums)
            {
                //traverse enums
                retNS.Enums.Add(TraverseEnum(ebs));
            }

            foreach (StructureBlockSyntax sbs in structs)
            {
                retNS.Structs.Add(TraverseStruct(sbs));
            }

            foreach (MethodBlockSyntax mbs in methods)
            {
                bool isConstructor = false;
                Method tempMethod = TraverseMethod(mbs, ref isConstructor);
                if (isConstructor)
                {
                    retNS.Constructors.Add(tempMethod as Constructor);
                }
                else
                {
                    retNS.Methods.Add(tempMethod);
                }
            }

            foreach (ConstructorBlockSyntax css in constructors)
            {
                retNS.Constructors.Add(TraverseConstructor(css));
            }

            foreach (ModuleBlockSyntax mbs in modules)
            {
            }

            foreach (ClassBlockSyntax cbs2 in classes)
            {
                retNS.Classes.Add(TraverseClass(cbs2));
            }

            foreach (DelegateStatementSyntax dds in delegates)
            {
                //TraverseDelegate
                retNS.Delegates.Add(TraverseDelegate(dds));
            }

            foreach (EventBlockSyntax ebs in delegates2)
            {
                //TraverseDelegate
                retNS.Delegates.Add(TraverseDelegate(ebs));
            }

            //Next, traverse any classes
            foreach (ClassBlockSyntax cds in classes)
            {
                TraverseClass(cds);
            }

            foreach (InterfaceBlockSyntax ids in interfaces)
            {
                //TraverseInterface
            }

            foreach (NamespaceBlockSyntax nbs2 in namespaces)
            {
                retNS.Namespaces.Add(TraverseNamespace(nbs2));
                retNS.UsingList = usingList;
            }

            return retNS;
        }

        private Namespace TraverseNamespace(NamespaceBlockSyntax nds)
        {
            Namespace retNS = new Namespace();

            //First, grab any objects defined at the beginning of the namespace (even delegates!)
            
            List<DelegateStatementSyntax> delegates = new List<DelegateStatementSyntax>();
            List<EventBlockSyntax> delegates2 = new List<EventBlockSyntax>();
            List<InterfaceBlockSyntax> interfaces = new List<InterfaceBlockSyntax>();
            List<EnumBlockSyntax> enums = new List<EnumBlockSyntax>();
            List<StructureBlockSyntax> structs = new List<StructureBlockSyntax>();
            List<MethodBlockSyntax> methods = new List<MethodBlockSyntax>();
            List<ConstructorBlockSyntax> constructors = new List<ConstructorBlockSyntax>();
            List<ModuleBlockSyntax> modules = new List<ModuleBlockSyntax>();
            List<ClassBlockSyntax> classes = new List<ClassBlockSyntax>();
            List<NamespaceBlockSyntax> namespaces = new List<NamespaceBlockSyntax>();

            foreach (SyntaxNode sn in nds.ChildNodes())
            {
                if (sn is DelegateStatementSyntax)
                {
                    delegates.Add(sn as DelegateStatementSyntax);
                }
                if (sn is EventBlockSyntax)
                {
                    delegates2.Add(sn as EventBlockSyntax);
                }
                else if (sn is InterfaceBlockSyntax)
                {
                    interfaces.Add(sn as InterfaceBlockSyntax);
                }
                if (sn is EnumBlockSyntax)
                {
                    enums.Add(sn as EnumBlockSyntax);
                }
                else if (sn is StructureBlockSyntax)
                {
                    structs.Add(sn as StructureBlockSyntax);
                }
                else if (sn is MethodBlockSyntax)
                {
                    methods.Add(sn as MethodBlockSyntax);
                }
                else if (sn is ConstructorBlockSyntax)
                {
                    constructors.Add(sn as ConstructorBlockSyntax);
                }
                else if (sn is ModuleBlockSyntax)
                {
                    modules.Add(sn as ModuleBlockSyntax);
                }
                else if (sn is ClassBlockSyntax)
                {
                    classes.Add(sn as ClassBlockSyntax);
                }
                else if (sn is NamespaceBlockSyntax)
                {
                    namespaces.Add(sn as NamespaceBlockSyntax);
                }
            }

            foreach (EnumBlockSyntax ebs in enums)
            {
                //traverse enums
                retNS.Enums.Add(TraverseEnum(ebs));
            }

            foreach (StructureBlockSyntax sbs in structs)
            {
                retNS.Structs.Add(TraverseStruct(sbs));
            }

            foreach (MethodBlockSyntax mbs in methods)
            {
                bool isConstructor = false;
                Method tempMethod = TraverseMethod(mbs, ref isConstructor);
                if (isConstructor)
                {
                    retNS.Constructors.Add(tempMethod as Constructor);
                }
                else
                {
                    retNS.Methods.Add(tempMethod);
                }
            }

            foreach (ConstructorBlockSyntax css in constructors)
            {
                retNS.Constructors.Add(TraverseConstructor(css));
            }

            foreach (ModuleBlockSyntax mbs in modules)
            {
                retNS.Modules.Add(TraverseModule(mbs));
            }

            foreach (ClassBlockSyntax cbs2 in classes)
            {
                retNS.Classes.Add(TraverseClass(cbs2));
            }

            foreach (DelegateStatementSyntax dds in delegates)
            {
                //TraverseDelegate
                retNS.Delegates.Add(TraverseDelegate(dds));
            }

            foreach (EventBlockSyntax ebs in delegates2)
            {
                //TraverseDelegate
                retNS.Delegates.Add(TraverseDelegate(ebs));
            }

            //Next, traverse any classes
            foreach (ClassBlockSyntax cds in classes)
            {
                TraverseClass(cds);
            }
            
            foreach (InterfaceBlockSyntax ids in interfaces)
            {
                //TraverseInterface
            }

            foreach (NamespaceBlockSyntax nbs2 in namespaces)
            {
                retNS.Namespaces.Add(TraverseNamespace(nbs2));
            }
            return retNS;
        }

        private string QualifiedName(QualifiedNameSyntax qns)
        {
            string qName = "";
            ChildSyntaxList idn = qns.ChildNodesAndTokens();
            foreach(SyntaxNodeOrToken snot in idn)
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

        #region Using list
        private List<UsingList> TraverseUsingList()
        {
            List<UsingList> retUL = new List<UsingList>();
            var usings = mRoot.Imports;
            foreach (ImportsStatementSyntax uds in usings)
            {
                UsingList ul = new UsingList();
                ul.LibName = uds.ImportsClauses.ToFullString();
                ul.Identifier = ""; //??
            }

            return retUL;
        }
        #endregion

        #region Delegates

        private Model.Delegate TraverseDelegate(EventBlockSyntax ebs)
        {
            Model.Delegate retDelegate = new Model.Delegate();

            retDelegate.IsEvent = true;

            EventStatementSyntax ess = ebs.EventStatement;

            foreach (SyntaxToken st in ess.Modifiers)
            {
                string modifier = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(st.ValueText);
                Encapsulation encap;
                if (System.Enum.TryParse<Encapsulation>(modifier, out encap))
                {
                    retDelegate.Encapsulation.Add(encap);
                }
            }

            foreach (AccessorBlockSyntax ass in ebs.Accessors){
                foreach(SyntaxNode sn in ass.ChildNodes())
                {
                    if (sn is MethodBlockSyntax)
                    {
                        bool isConstructor = false;
                        retDelegate.ReferencedMethods.Add(TraverseMethod((sn as MethodBlockSyntax), ref isConstructor));
                    }
                }
            }

            return retDelegate;
        }

        private Model.Delegate TraverseDelegate(DelegateStatementSyntax ebs)
        {
            Model.Delegate retDelegate = new Model.Delegate();

            foreach (SyntaxToken st in ebs.Modifiers)
            {
                string modifier = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(st.ValueText);
                Encapsulation encap;
                if (System.Enum.TryParse<Encapsulation>(modifier, out encap))
                {
                    retDelegate.Encapsulation.Add(encap);
                }
            }

            Method aMethod = new Method();

            aMethod.Name = ebs.Identifier.ValueText;

            ParameterListSyntax pls = ebs.ParameterList;

            //Parameters
            foreach (ParameterSyntax ps in pls.Parameters)
            {
                aMethod.Parameters.Add(TraverseParameters(ps));
            }

            retDelegate.ReferencedMethods.Add(aMethod);

            return retDelegate;
        }

        #endregion

        private Interface TraverseInterface(InterfaceBlockSyntax ibs)
        {
            Interface retInterface = new Interface();

            /*
            Encapsulation = new List<Encapsulation>();
			Qualifiers = new List<Qualifiers>();
			Attributes = new List<Variables>();
			Methods = new List<Method>();
			InheritsStrings = new List<string>();
			InheritsInterfaces = new List<Interface>();
            */

            InterfaceStatementSyntax iss = ibs.Begin;

            foreach (SyntaxToken st in iss.Modifiers)
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

            retInterface.Name = iss.Identifier.ValueText;

            foreach(InheritsStatementSyntax inherits in ibs.Inherits){
                foreach (SyntaxNode sn in inherits.ChildNodes())
                {
                    if (sn is IdentifierNameSyntax)
                    {
                        retInterface.InheritsStrings.Add((sn as IdentifierNameSyntax).Identifier.ValueText);
                    }
                }
            }

            List<MethodBlockSyntax> methods = new List<MethodBlockSyntax>();
            List<FieldDeclarationSyntax> Fields = new List<FieldDeclarationSyntax>();
            List<PropertyBlockSyntax> properties = new List<PropertyBlockSyntax>();

            foreach (SyntaxNode sn in ibs.ChildNodes())
            {
                if (sn is MethodBlockSyntax)
                {
                    methods.Add(sn as MethodBlockSyntax);
                }
                else if (sn is FieldDeclarationSyntax)
                {
                    Fields.Add(sn as FieldDeclarationSyntax);
                }
                else if (sn is PropertyBlockSyntax)
                {
                    properties.Add(sn as PropertyBlockSyntax);
                }
            }

            foreach (MethodBlockSyntax mbs in methods)
            {
                bool isConstructor = false;
                retInterface.Methods.Add(TraverseMethod(mbs, ref isConstructor));
            }

            foreach (FieldDeclarationSyntax fds in Fields)
            {
                retInterface.Fields.Add(TraverseField(fds));
            }

            foreach (PropertyBlockSyntax pbs in properties)
            {
                retInterface.Properties.Add(TraverseProperties(pbs));
            }

            return retInterface;
        }

        #region Classes

        private Class TraverseClass(ClassBlockSyntax cbs)
        {
            Class retClass = new Class();
            //Name
            retClass.Name = cbs.Begin.Identifier.ValueText;
            //encapsulation
            
            foreach (SyntaxToken st in cbs.Begin.Modifiers)
            {
                string modifier = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(st.ValueText);
                Encapsulation encap;
                Qualifiers qual;
                if (System.Enum.TryParse<Encapsulation>(modifier, out encap))
                {
                    retClass.Encapsulation.Add(encap);
                }
                else if (System.Enum.TryParse<Qualifiers>(modifier, out qual))
                {
                    retClass.Qualifiers.Add(qual);
                }
            }

            List<EnumBlockSyntax> enums = new List<EnumBlockSyntax>();
            List<StructureBlockSyntax> structs = new List<StructureBlockSyntax>();
            List<MethodBlockSyntax> methods = new List<MethodBlockSyntax>();
            List<FieldDeclarationSyntax> Fields = new List<FieldDeclarationSyntax>();
            List<PropertyBlockSyntax> properties = new List<PropertyBlockSyntax>();
            List<ConstructorBlockSyntax> constructors = new List<ConstructorBlockSyntax>();
            List<ModuleBlockSyntax> modules = new List<ModuleBlockSyntax>();
            List<ClassBlockSyntax> classes = new List<ClassBlockSyntax>();
            

            foreach (SyntaxNode sn in cbs.ChildNodes())
            {
                if (sn is EnumBlockSyntax)
                {
                    enums.Add(sn as EnumBlockSyntax);
                }
                else if (sn is StructureBlockSyntax)
                {
                    structs.Add(sn as StructureBlockSyntax);
                }
                else if (sn is MethodBlockSyntax)
                {
                    methods.Add(sn as MethodBlockSyntax);
                }
                else if (sn is FieldDeclarationSyntax)
                {
                    Fields.Add(sn as FieldDeclarationSyntax);
                }
                else if (sn is PropertyBlockSyntax)
                {
                    properties.Add(sn as PropertyBlockSyntax);
                }
                else if (sn is ConstructorBlockSyntax)
                {
                    constructors.Add(sn as ConstructorBlockSyntax);
                }
                else if (sn is ModuleBlockSyntax)
                {
                    modules.Add(sn as ModuleBlockSyntax);
                }
                else if (sn is ClassBlockSyntax)
                {
                    classes.Add(sn as ClassBlockSyntax);
                }
            }

            foreach (EnumBlockSyntax ebs in enums)
            {
                //traverse enums
                retClass.Enums.Add(TraverseEnum(ebs));
            }

            foreach (StructureBlockSyntax sbs in structs)
            {
                retClass.Structs.Add(TraverseStruct(sbs));
            }

            foreach (MethodBlockSyntax mbs in methods)
            {
                bool isConstructor = false;
                Method tempMethod = TraverseMethod(mbs, ref isConstructor);
                if (isConstructor)
                {
                    retClass.Constructors.Add(tempMethod as Constructor);
                }
                else
                {
                    retClass.Methods.Add(tempMethod);
                }
            }

            foreach (FieldDeclarationSyntax fds in Fields)
            {
                retClass.Fields.Add(TraverseField(fds));
            }

            foreach (PropertyBlockSyntax pbs in properties)
            {
                retClass.Properties.Add(TraverseProperties(pbs));
            }

            foreach (ConstructorBlockSyntax css in constructors)
            {
                retClass.Constructors.Add(TraverseConstructor(css));
            }

            foreach (ModuleBlockSyntax mbs in modules)
            {
                retClass.Modules.Add(TraverseModule(mbs));
            }

            foreach (ClassBlockSyntax cbs2 in classes)
            {
                retClass.Classes.Add(TraverseClass(cbs2));
            }

            foreach (SyntaxNode sn in cbs.Begin.ChildNodes())
            {
                if (sn is InheritsOrImplementsStatementSyntax)
                {
                }
            }

            return retClass;
        }

        private Inheritance TraverseInheritance(InheritsOrImplementsStatementSyntax ioiss)
        {
            Inheritance inheritance = new Inheritance();

            return inheritance;
        }

        #endregion

        #region Enums
        private Model.Enum TraverseEnum(EnumBlockSyntax ebs)
        {
            Model.Enum retEnum = new Model.Enum();

            /*
             Type = new Type();
			Encapsulation = new List<Encapsulation>();
			EnumItems = new List<string>();
             */
            retEnum.Name = ebs.EnumStatement.Identifier.ValueText;

            //TODO: What is the deal with Type?

            foreach (SyntaxToken st in ebs.EnumStatement.Modifiers)
            {
                string modifier = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(st.ValueText);
                retEnum.Encapsulation.Add((Encapsulation)System.Enum.Parse(typeof(Encapsulation), modifier));
            }

            //TODO: EnumItems
            foreach (EnumMemberDeclarationSyntax emds in ebs.Members)
            {
                retEnum.EnumItems.Add(emds.Identifier.ValueText);
            }

            return retEnum;
        }
        #endregion

        #region Structs
        private Struct TraverseStruct(StructureBlockSyntax sbs)
        {
            Struct retClass = new Struct();
            retClass.Name = sbs.Begin.Identifier.ValueText;
            //encapsulation

            foreach (SyntaxToken st in sbs.Begin.Modifiers)
            {
                string modifier = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(st.ValueText);
                Encapsulation encap;
                Qualifiers qual;
                if (System.Enum.TryParse<Encapsulation>(modifier, out encap))
                {
                    retClass.Encapsulation.Add(encap);
                }
                else if (System.Enum.TryParse<Qualifiers>(modifier, out qual))
                {
                    retClass.Qualifiers.Add(qual);
                }
            }

            List<EnumBlockSyntax> enums = new List<EnumBlockSyntax>();
            List<StructureBlockSyntax> structs = new List<StructureBlockSyntax>();
            List<MethodBlockSyntax> methods = new List<MethodBlockSyntax>();
            List<FieldDeclarationSyntax> Fields = new List<FieldDeclarationSyntax>();
            List<PropertyBlockSyntax> properties = new List<PropertyBlockSyntax>();
            List<ConstructorBlockSyntax> constructors = new List<ConstructorBlockSyntax>();
            List<ModuleBlockSyntax> modules = new List<ModuleBlockSyntax>();
            List<ClassBlockSyntax> classes = new List<ClassBlockSyntax>();


            foreach (SyntaxNode sn in sbs.ChildNodes())
            {
                if (sn is EnumBlockSyntax)
                {
                    enums.Add(sn as EnumBlockSyntax);
                }
                else if (sn is StructureBlockSyntax)
                {
                    structs.Add(sn as StructureBlockSyntax);
                }
                else if (sn is MethodBlockSyntax)
                {
                    methods.Add(sn as MethodBlockSyntax);
                }
                else if (sn is FieldDeclarationSyntax)
                {
                    Fields.Add(sn as FieldDeclarationSyntax);
                }
                else if (sn is PropertyBlockSyntax)
                {
                    properties.Add(sn as PropertyBlockSyntax);
                }
                else if (sn is ConstructorBlockSyntax)
                {
                    constructors.Add(sn as ConstructorBlockSyntax);
                }
                else if (sn is ModuleBlockSyntax)
                {
                    modules.Add(sn as ModuleBlockSyntax);
                }
                else if (sn is ClassBlockSyntax)
                {
                    classes.Add(sn as ClassBlockSyntax);
                }
            }

            foreach (EnumBlockSyntax ebs in enums)
            {
                //traverse enums
                retClass.Enums.Add(TraverseEnum(ebs));
            }

            foreach (StructureBlockSyntax sbs2 in structs)
            {
                retClass.Structs.Add(TraverseStruct(sbs2));
            }

            foreach (MethodBlockSyntax mbs in methods)
            {
                bool isConstructor = false;
                Method tempMethod = TraverseMethod(mbs, ref isConstructor);
                if (isConstructor)
                {
                    retClass.Constructors.Add(tempMethod as Constructor);
                }
                else
                {
                    retClass.Methods.Add(tempMethod);
                }
            }

            foreach (FieldDeclarationSyntax fds in Fields)
            {
                retClass.Fields.Add(TraverseField(fds));
            }

            foreach (PropertyBlockSyntax pbs in properties)
            {
                retClass.Properties.Add(TraverseProperties(pbs));
            }

            foreach (ConstructorBlockSyntax css in constructors)
            {
                retClass.Constructors.Add(TraverseConstructor(css));
            }

            foreach (ModuleBlockSyntax mbs in modules)
            {
                retClass.Modules.Add(TraverseModule(mbs));
            }

            foreach (ClassBlockSyntax sbs2 in classes)
            {
                retClass.Classes.Add(TraverseClass(sbs2));
            }

            foreach (SyntaxNode sn in sbs.Begin.ChildNodes())
            {
                if (sn is InheritsOrImplementsStatementSyntax)
                {
                }
            }

            return retClass;
        }
        #endregion

        #region Modules
        private Module TraverseModule(ModuleBlockSyntax mbs)
        {
            Module retClass = new Module();
            retClass.Name = mbs.Begin.Identifier.ValueText;
            //encapsulation

            foreach (SyntaxToken st in mbs.Begin.Modifiers)
            {
                string modifier = System.Threading.Thread.CurrentThread.CurrentCulture.TextInfo.ToTitleCase(st.ValueText);
                Encapsulation encap;
                Qualifiers qual;
                if (System.Enum.TryParse<Encapsulation>(modifier, out encap))
                {
                    retClass.Encapsulation.Add(encap);
                }
                else if (System.Enum.TryParse<Qualifiers>(modifier, out qual))
                {
                    retClass.Qualifiers.Add(qual);
                }
            }

            List<EnumBlockSyntax> enums = new List<EnumBlockSyntax>();
            List<StructureBlockSyntax> structs = new List<StructureBlockSyntax>();
            List<MethodBlockSyntax> methods = new List<MethodBlockSyntax>();
            List<FieldDeclarationSyntax> Fields = new List<FieldDeclarationSyntax>();
            List<PropertyBlockSyntax> properties = new List<PropertyBlockSyntax>();
            List<ConstructorBlockSyntax> constructors = new List<ConstructorBlockSyntax>();
            List<ModuleBlockSyntax> modules = new List<ModuleBlockSyntax>();
            List<ClassBlockSyntax> classes = new List<ClassBlockSyntax>();


            foreach (SyntaxNode sn in mbs.ChildNodes())
            {
                if (sn is EnumBlockSyntax)
                {
                    enums.Add(sn as EnumBlockSyntax);
                }
                else if (sn is StructureBlockSyntax)
                {
                    structs.Add(sn as StructureBlockSyntax);
                }
                else if (sn is MethodBlockSyntax)
                {
                    methods.Add(sn as MethodBlockSyntax);
                }
                else if (sn is FieldDeclarationSyntax)
                {
                    Fields.Add(sn as FieldDeclarationSyntax);
                }
                else if (sn is PropertyBlockSyntax)
                {
                    properties.Add(sn as PropertyBlockSyntax);
                }
                else if (sn is ConstructorBlockSyntax)
                {
                    constructors.Add(sn as ConstructorBlockSyntax);
                }
                else if (sn is ModuleBlockSyntax)
                {
                    modules.Add(sn as ModuleBlockSyntax);
                }
                else if (sn is ClassBlockSyntax)
                {
                    classes.Add(sn as ClassBlockSyntax);
                }
            }

            foreach (EnumBlockSyntax ebs in enums)
            {
                //traverse enums
                retClass.Enums.Add(TraverseEnum(ebs));
            }

            foreach (StructureBlockSyntax sbs in structs)
            {
                retClass.Structs.Add(TraverseStruct(sbs));
            }

            foreach (MethodBlockSyntax methbs in methods)
            {
                bool isConstructor = false;
                Method tempMethod = TraverseMethod(methbs, ref isConstructor);
                if (isConstructor)
                {
                    retClass.Constructors.Add(tempMethod as Constructor);
                }
                else
                {
                    retClass.Methods.Add(tempMethod);
                }
            }

            foreach (FieldDeclarationSyntax fds in Fields)
            {
                retClass.Fields.Add(TraverseField(fds));
            }

            foreach (PropertyBlockSyntax pbs in properties)
            {
                retClass.Properties.Add(TraverseProperties(pbs));
            }

            foreach (ConstructorBlockSyntax css in constructors)
            {
                retClass.Constructors.Add(TraverseConstructor(css));
            }

            foreach (ModuleBlockSyntax mbs2 in modules)
            {
                retClass.Modules.Add(TraverseModule(mbs2));
            }

            foreach (ClassBlockSyntax mbs2 in classes)
            {
                retClass.Classes.Add(TraverseClass(mbs2));
            }

            foreach (SyntaxNode sn in mbs.Begin.ChildNodes())
            {
                if (sn is InheritsOrImplementsStatementSyntax)
                {
                }
            }
            return retClass;
        }
        #endregion

        #region Methods

        private Method TraverseMethod(MethodBlockSyntax mbs, ref bool isConstructor)
        {
            Method retMethod = new Method();

            //get the MethodStatementSyntax
            MethodStatementSyntax methodss = null; 
            foreach (SyntaxNode sn in mbs.ChildNodes())
            {
                if (sn is MethodStatementSyntax)
                {
                    methodss = sn as MethodStatementSyntax;
                    break;
                }
                else if (sn is ConstructorBlockSyntax)
                {
                    return TraverseConstructor(sn as ConstructorBlockSyntax);
                }
            }

            if (methodss == null)
            {
                throw new Exception("Bad MethodBlockStatement!");
            }

            if (methodss != null)
            {
                retMethod.Name = methodss.Identifier.ValueText;
            }

            /*
            Preprocessors = new List<Preprocessor>();
            Encapsulation = new List<Encapsulation>();
            Base = new List<InvokedMethod>();
            ReturnType = new Type();
            Qualifiers = new List<Qualifiers>();
            Parameters = new List<Variables>();
            Decisions = new Decisions();
            AccessedVariables = new List<Variables>();
            LabelStatements = new List<LabelStatement>();
            GoToStatements = new List<GoTo>();
            InvokedMethods = new List<InvokedMethod>();
             */

            

            //Encapsulation
            foreach (SyntaxToken st in methodss.Modifiers)
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

            //TODO: Need to determine what the qualifers are

            //TODO: Qualifiers

            ParameterListSyntax pls = methodss.ParameterList;

            //Parameters
            foreach (ParameterSyntax ps in pls.Parameters)
            {
                retMethod.Parameters.Add(TraverseParameters(ps));
            }

            //Decisions
            List<MultiLineIfBlockSyntax> multiIfStms = new List<MultiLineIfBlockSyntax>();
            List<SingleLineIfStatementSyntax> ifStms = new List<SingleLineIfStatementSyntax>();
            List<ElseStatementSyntax> elseStm = new List<ElseStatementSyntax>();
            List<ForEachStatementSyntax> foreachStm = new List<ForEachStatementSyntax>();
            List<ForBlockSyntax> forStm = new List<ForBlockSyntax>();
            List<DoLoopBlockSyntax> doWhileStm = new List<DoLoopBlockSyntax>();
            List<WhileBlockSyntax> whileStm = new List<WhileBlockSyntax>();
            List<SelectBlockSyntax> switchStm = new List<SelectBlockSyntax>();
            List<CatchPartSyntax> catchStmm = new List<CatchPartSyntax>();
            //Access Variables
            List<LocalDeclarationStatementSyntax> accessVarDefs = new List<LocalDeclarationStatementSyntax>();
            List<AssignmentStatementSyntax> accessVars = new List<AssignmentStatementSyntax>();
            //Label Statements
            List<LabelStatementSyntax> labelStms = new List<LabelStatementSyntax>();
            //GoTo Statements
            List<GoToStatementSyntax> gotoStms = new List<GoToStatementSyntax>();
            //InvokedMethods
            List<CallStatementSyntax> invokedMethods = new List<CallStatementSyntax>();
            List<InvocationExpressionSyntax> invokedMethods2 = new List<InvocationExpressionSyntax>();
            //Returns
            List<ReturnStatementSyntax> returns = new List<ReturnStatementSyntax>();

            foreach (SyntaxNode sn in mbs.Statements)
            {
                if (sn is MultiLineIfBlockSyntax)
                {
                    multiIfStms.Add(sn as MultiLineIfBlockSyntax);
                }
                if (sn is SingleLineIfStatementSyntax)
                {
                    ifStms.Add(sn as SingleLineIfStatementSyntax);
                }
                else if (sn is ElseStatementSyntax)
                {
                    elseStm.Add(sn as ElseStatementSyntax);
                }
                else if (sn is ForEachStatementSyntax)
                {
                    foreachStm.Add(sn as ForEachStatementSyntax);
                }
                else if (sn is ForBlockSyntax)
                {
                    forStm.Add(sn as ForBlockSyntax);
                }
                else if (sn is DoLoopBlockSyntax)
                {
                    doWhileStm.Add(sn as DoLoopBlockSyntax);
                }
                else if (sn is WhileBlockSyntax)
                {
                    whileStm.Add(sn as WhileBlockSyntax);
                }
                else if (sn is SelectBlockSyntax)
                {
                    switchStm.Add(sn as SelectBlockSyntax);
                }
                else if (sn is CatchPartSyntax)
                {
                    catchStmm.Add(sn as CatchPartSyntax);
                }
                else if (sn is LocalDeclarationStatementSyntax)
                {
                    accessVarDefs.Add(sn as LocalDeclarationStatementSyntax);
                }
                else if (sn is AssignmentStatementSyntax)
                {
                    accessVars.Add(sn as AssignmentStatementSyntax);
                }
                else if (sn is LabelStatementSyntax)
                {
                    labelStms.Add(sn as LabelStatementSyntax);
                }
                else if (sn is LabelStatementSyntax)
                {
                    gotoStms.Add(sn as GoToStatementSyntax);
                }
                else if (sn is GoToStatementSyntax)
                {
                    gotoStms.Add(sn as GoToStatementSyntax);
                }
                else if (sn is CallStatementSyntax)
                {
                    invokedMethods.Add(sn as CallStatementSyntax);
                }
                else if (sn is InvocationExpressionSyntax)
                {
                    invokedMethods2.Add(sn as InvocationExpressionSyntax);
                }
                else if (sn is ReturnStatementSyntax)
                {
                    returns.Add(sn as ReturnStatementSyntax);
                }
            }

            foreach (MultiLineIfBlockSyntax mlbs in multiIfStms)
            {
                int exitPoints = retMethod.ExitPoints;
                Decisions tempDecision = AllDecisions(TraverseMultiIfStatement(mlbs, ref exitPoints));
                
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

            foreach (SingleLineIfStatementSyntax iss in ifStms)
            {
                int exitPoints = retMethod.ExitPoints;
                Decisions tempDecision = AllDecisions(TraverseIfStatement(iss, ref exitPoints));
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
            foreach (ElseStatementSyntax ess in elseStm)
            {
                int exitPoints = retMethod.ExitPoints;
                retMethod.Decisions.ElseStatements.Add(TravsereElseStatement(ess, ref exitPoints));
                retMethod.ExitPoints = exitPoints;
            }
            foreach (ForEachStatementSyntax fess in foreachStm)
            {
                int exitPoints = retMethod.ExitPoints;
                retMethod.Decisions.ForEachStatements.Add(TraverseForeachStatement(fess, ref exitPoints));
                retMethod.ExitPoints = exitPoints;
            }
            foreach (ForBlockSyntax fss in forStm)
            {
                int exitPoints = retMethod.ExitPoints;
                Decisions tempDecision = AllDecisions(TraverseForStatement(fss, ref exitPoints));
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
            foreach (DoLoopBlockSyntax dss in doWhileStm)
            {
                int exitPoints = retMethod.ExitPoints;
                retMethod.Decisions.DoWhileLoops.Add(TraverseDoWhileLoop(dss, ref exitPoints));
                retMethod.ExitPoints = exitPoints;
            }
            foreach (WhileBlockSyntax wbs in whileStm)
            {
                int exitPoints = retMethod.ExitPoints;
                retMethod.Decisions.WhileLoops.Add(TraverseWhileLoop(wbs, ref exitPoints));
                retMethod.ExitPoints = exitPoints;
            }
            foreach (SelectBlockSyntax sbs in switchStm)
            {
                int exitPoints = retMethod.ExitPoints;
                retMethod.Decisions.SwitchStatements.Add(TraverseSwitchStatement(sbs, ref exitPoints));
                retMethod.ExitPoints = exitPoints;
            }
            foreach (CatchPartSyntax cps in catchStmm)
            {
                int exitPoints = retMethod.ExitPoints;
                retMethod.Decisions.Catches.Add(TraverseCatchStatement(cps, ref exitPoints));
                retMethod.ExitPoints = exitPoints;
            }

            foreach (LocalDeclarationStatementSyntax vds in accessVarDefs)
            {
                Method tempMethod = TraverseVarDecls(vds);
                retMethod.AccessedVariables.AddRange(tempMethod.AccessedVariables);
                retMethod.InvokedMethods.AddRange(tempMethod.InvokedMethods);
            }

            foreach (AssignmentStatementSyntax vns in accessVars)
            {
                Method tempMethod = TraverseAccessVars(vns);

                retMethod.AccessedVariables.AddRange(tempMethod.AccessedVariables);
                retMethod.InvokedMethods.AddRange(tempMethod.InvokedMethods);
            }

            foreach (LabelStatementSyntax lss in labelStms)
            {
                retMethod.LabelStatements.Add(TraverseLabel(lss));
            }

            foreach (GoToStatementSyntax gtss in gotoStms)
            {
                retMethod.GoToStatements.Add(TraverseGoTo(retMethod.LabelStatements, gtss));
            }

            foreach (CallStatementSyntax mss in invokedMethods)
            {
                retMethod.InvokedMethods.Add(TraverseInvokedMethod(mss));
            }

            foreach (InvocationExpressionSyntax ies in invokedMethods2)
            {
                retMethod.InvokedMethods.Add(TraverseInvokedMethod(ies));
            }

            return retMethod;
        }

        #region Decisions

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

        private Decisions TraverseMultiIfStatement(MultiLineIfBlockSyntax mlib, ref int returnCnt, bool nested = false)
        {
            Decisions retDecisions = new Decisions();

            foreach (SyntaxNode sn in mlib.ChildNodes())
            {
                if (sn is IfPartSyntax)
                {
                    retDecisions.IfStatements.Add(TraverseIfStatement(sn as IfPartSyntax, ref returnCnt, nested));
                }
                else if (sn is ElsePartSyntax)
                {
                    retDecisions.ElseStatements.Add(TraverseElseStatement(sn as ElsePartSyntax, ref returnCnt, nested));
                }
            }

            return retDecisions;
        }

        //TODO: Make sure we recursively go through each decision
        private Decisions TraverseIfStatement(SingleLineIfStatementSyntax sliss, ref int returnCnt, bool nested = false)
        {
            Decisions retDecision = new Decisions();
            IfStatement ifStm = new IfStatement();
            ifStm.IsNested = nested;
            //!!!!!!!!!!!!!!!!!!!!Start Here!!!!!!!!!!!!!!!!!!!
            SingleLineIfPartSyntax ifPart = sliss.IfPart;

            IfStatementSyntax iss = ifPart.Begin;

            BinaryExpressionSyntax bes = iss.Condition as BinaryExpressionSyntax;

            if (bes != null)
            {
                foreach (SyntaxNode sn in bes.DescendantNodesAndSelf())
                {
                    if (sn is BinaryExpressionSyntax)
                    {
                        ifStm.ConditionCount++;
                    }
                    else if (sn is IdentifierNameSyntax)
                    {
                        Variables variable = new Variables();
                        variable.IsReferenced = true;

                        variable.Name = (sn as IdentifierNameSyntax).Identifier.ValueText;
                        ifStm.AccessedVars.Add(variable);
                    }
                }
            }

            foreach (StatementSyntax ss in ifPart.Statements)
            {
                if (ss is AssignmentStatementSyntax)
                {
                    //TODO: need to look at more than just then name!
                    Method tempMethod = TraverseAccessVars(ss as AssignmentStatementSyntax);

                    ifStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    ifStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                else if (ss is LocalDeclarationStatementSyntax)
                {
                    Method tempMethod = TraverseVarDecls(ss as LocalDeclarationStatementSyntax);
                    ifStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    ifStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                else if (ss is SingleLineIfStatementSyntax)
                {
                    Decisions decision = TraverseIfStatement(ss as SingleLineIfStatementSyntax, ref returnCnt, true);
                    ifStm.Nested.AddRange(decision.IfStatements);
                    ifStm.Nested.AddRange(decision.ElseStatements);
                }
                else if (ss is MultiLineIfBlockSyntax)
                {
                    Decisions decisions = TraverseMultiIfStatement(ss as MultiLineIfBlockSyntax, ref returnCnt, true);
                    ifStm.Nested.AddRange(decisions.IfStatements);
                    ifStm.Nested.AddRange(decisions.ElseStatements);
                }
                else if (ss is ElseStatementSyntax)
                {
                    ifStm.Nested.Add(TravsereElseStatement(ss as ElseStatementSyntax, ref returnCnt, true));
                }
                else if (ss is ForBlockSyntax)
                {
                    Decisions tempDecision = TraverseForStatement(ss as ForBlockSyntax, ref returnCnt, true);
                    ifStm.Nested.AddRange(tempDecision.IfStatements);
                    ifStm.Nested.AddRange(tempDecision.ElseStatements);
                    ifStm.Nested.AddRange(tempDecision.ForEachStatements);
                    ifStm.Nested.AddRange(tempDecision.ForStatements);
                    ifStm.Nested.AddRange(tempDecision.WhileLoops);
                    ifStm.Nested.AddRange(tempDecision.DoWhileLoops);
                    ifStm.Nested.AddRange(tempDecision.Catches);
                    ifStm.Nested.AddRange(tempDecision.SwitchStatements);
                }
                else if (ss is SelectBlockSyntax)
                {
                    ifStm.Nested.Add(TraverseSwitchStatement(ss as SelectBlockSyntax, ref returnCnt, true));
                }
                else if (ss is DoLoopBlockSyntax)
                {
                    ifStm.Nested.Add(TraverseDoWhileLoop(ss as DoLoopBlockSyntax, ref returnCnt, true));
                }
                else if (ss is WhileBlockSyntax)
                {
                    ifStm.Nested.Add(TraverseWhileLoop(ss as WhileBlockSyntax, ref returnCnt, true));
                }
                else if (ss is CallStatementSyntax)
                {
                    ifStm.InvokedMethods.Add(TraverseInvokedMethod(ss as CallStatementSyntax));
                }
                else if (ss is ReturnStatementSyntax)
                {
                    Method tempMethod = TraverseReturnStatement(ss as ReturnStatementSyntax);
                    ifStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                    ifStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    returnCnt++;
                }
            }

            retDecision.IfStatements.Add(ifStm);

            if (sliss.ElsePart != null)
            {
                SingleLineElsePartSyntax sleps = sliss.ElsePart;
                ElseStatement elseStm = new ElseStatement();

                foreach (StatementSyntax ss in sleps.Statements)
                {
                    if (ss is AssignmentStatementSyntax)
                    {
                        //TODO: need to look at more than just then name!
                        Method tempMethod = TraverseAccessVars(ss as AssignmentStatementSyntax);

                        elseStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                        elseStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                    }
                    else if (ss is LocalDeclarationStatementSyntax)
                    {
                        Method tempMethod = TraverseVarDecls(ss as LocalDeclarationStatementSyntax);
                        elseStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                        elseStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                    }
                    else if (ss is SingleLineIfStatementSyntax)
                    {
                        Decisions decision = TraverseIfStatement(ss as SingleLineIfStatementSyntax, ref returnCnt, true);
                        elseStm.Nested.AddRange(decision.IfStatements);
                        elseStm.Nested.AddRange(decision.ElseStatements);
                    }
                    else if (ss is MultiLineIfBlockSyntax)
                    {
                        Decisions decisions = TraverseMultiIfStatement(ss as MultiLineIfBlockSyntax, ref returnCnt, true);
                        elseStm.Nested.AddRange(decisions.IfStatements);
                        elseStm.Nested.AddRange(decisions.ElseStatements);
                    }
                    else if (ss is ElseStatementSyntax)
                    {
                        elseStm.Nested.Add(TravsereElseStatement(ss as ElseStatementSyntax, ref returnCnt, true));
                    }
                    else if (ss is ForBlockSyntax)
                    {
                        Decisions tempDecision = TraverseForStatement(ss as ForBlockSyntax, ref returnCnt, true);
                        ifStm.Nested.AddRange(tempDecision.IfStatements);
                        ifStm.Nested.AddRange(tempDecision.ElseStatements);
                        ifStm.Nested.AddRange(tempDecision.ForEachStatements);
                        ifStm.Nested.AddRange(tempDecision.ForStatements);
                        ifStm.Nested.AddRange(tempDecision.WhileLoops);
                        ifStm.Nested.AddRange(tempDecision.DoWhileLoops);
                        ifStm.Nested.AddRange(tempDecision.Catches);
                        ifStm.Nested.AddRange(tempDecision.SwitchStatements);
                    }
                    else if (ss is SelectBlockSyntax)
                    {
                        elseStm.Nested.Add(TraverseSwitchStatement(ss as SelectBlockSyntax, ref returnCnt, true));
                    }
                    else if (ss is DoLoopBlockSyntax)
                    {
                        elseStm.Nested.Add(TraverseDoWhileLoop(ss as DoLoopBlockSyntax, ref returnCnt, true));
                    }
                    else if (ss is WhileBlockSyntax)
                    {
                        elseStm.Nested.Add(TraverseWhileLoop(ss as WhileBlockSyntax, ref returnCnt, true));
                    }
                    else if (ss is CallStatementSyntax)
                    {
                        elseStm.InvokedMethods.Add(TraverseInvokedMethod(ss as CallStatementSyntax));
                    }
                    else if (ss is ReturnStatementSyntax)
                    {
                        Method tempMethod = TraverseReturnStatement(ss as ReturnStatementSyntax);
                        elseStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                        elseStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                        returnCnt++;
                    }
                }
                retDecision.Add(elseStm);
            }

            return retDecision;
        }

        private IfStatement TraverseIfStatement(IfPartSyntax slips, ref int returnCnt, bool nested = false)
        {
            IfStatement ifStm = new IfStatement();
            ifStm.IsNested = nested;
            IfStatementSyntax iss = slips.Begin;

            BinaryExpressionSyntax bes = iss.Condition as BinaryExpressionSyntax;
            if (bes != null)
            {
                foreach (SyntaxNode sn in bes.DescendantNodesAndSelf())
                {
                    if (sn is BinaryExpressionSyntax)
                    {
                        ifStm.ConditionCount++;
                    }
                    else if (sn is IdentifierNameSyntax)
                    {
                        Variables variable = new Variables();
                        variable.IsReferenced = true;

                        variable.Name = (sn as IdentifierNameSyntax).Identifier.ValueText;
                        ifStm.AccessedVars.Add(variable);
                    }
                }
            }

            foreach (StatementSyntax ss in slips.Statements)
            {
                if (ss is AssignmentStatementSyntax)
                {
                    //TODO: need to look at more than just then name!
                    Method tempMethod = TraverseAccessVars(ss as AssignmentStatementSyntax);

                    ifStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    ifStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                else if (ss is LocalDeclarationStatementSyntax)
                {
                    Method tempMethod = TraverseVarDecls(ss as LocalDeclarationStatementSyntax);
                    ifStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    ifStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                else if (ss is SingleLineIfStatementSyntax)
                {
                    Decisions decision = TraverseIfStatement(ss as SingleLineIfStatementSyntax, ref returnCnt, true);
                    ifStm.Nested.AddRange(decision.IfStatements);
                    ifStm.Nested.AddRange(decision.ElseStatements);
                }
                else if (ss is MultiLineIfBlockSyntax)
                {
                    Decisions decisions = TraverseMultiIfStatement(ss as MultiLineIfBlockSyntax, ref returnCnt, true);
                    ifStm.Nested.AddRange(decisions.IfStatements);
                    ifStm.Nested.AddRange(decisions.ElseStatements);
                }
                else if (ss is ForBlockSyntax)
                {
                    Decisions tempDecision = TraverseForStatement(ss as ForBlockSyntax, ref returnCnt, true);
                    ifStm.Nested.AddRange(tempDecision.IfStatements);
                    ifStm.Nested.AddRange(tempDecision.ElseStatements);
                    ifStm.Nested.AddRange(tempDecision.ForEachStatements);
                    ifStm.Nested.AddRange(tempDecision.ForStatements);
                    ifStm.Nested.AddRange(tempDecision.WhileLoops);
                    ifStm.Nested.AddRange(tempDecision.DoWhileLoops);
                    ifStm.Nested.AddRange(tempDecision.Catches);
                    ifStm.Nested.AddRange(tempDecision.SwitchStatements);
                }
                else if (ss is ElseStatementSyntax)
                {
                    ifStm.Nested.Add(TravsereElseStatement(ss as ElseStatementSyntax, ref returnCnt, true));
                }
                else if (ss is SelectBlockSyntax)
                {
                    ifStm.Nested.Add(TraverseSwitchStatement(ss as SelectBlockSyntax, ref returnCnt, true));
                }
                else if (ss is DoLoopBlockSyntax)
                {
                    ifStm.Nested.Add(TraverseDoWhileLoop(ss as DoLoopBlockSyntax, ref returnCnt, true));
                }
                else if (ss is WhileBlockSyntax)
                {
                    ifStm.Nested.Add(TraverseWhileLoop(ss as WhileBlockSyntax, ref returnCnt, true));
                }
                else if (ss is CallStatementSyntax)
                {
                    ifStm.InvokedMethods.Add(TraverseInvokedMethod(ss as CallStatementSyntax));
                }
                else if (ss is ReturnStatementSyntax)
                {
                    Method tempMethod = TraverseReturnStatement(ss as ReturnStatementSyntax);
                    ifStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                    ifStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    returnCnt++;
                }
            }
            //!!!!!!!!!!!!!!!!!!Start Here!!!!!!!!!!!!!!!!!!!!!!!

            return ifStm;
        }

        private ElseStatement TraverseElseStatement(ElsePartSyntax eps, ref int returnCnt, bool nested = false)
        {
            ElseStatement elseStm = new ElseStatement();
            elseStm.IsNested = nested;
            foreach (StatementSyntax ss in eps.Statements)
            {
                if (ss is AssignmentStatementSyntax)
                {
                    //TODO: need to look at more than just then name!
                    Method tempMethod = TraverseAccessVars(ss as AssignmentStatementSyntax);

                    elseStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    elseStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                else if (ss is LocalDeclarationStatementSyntax)
                {
                    Method tempMethod = TraverseVarDecls(ss as LocalDeclarationStatementSyntax);
                    elseStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    elseStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                else if (ss is SingleLineIfStatementSyntax)
                {
                    Decisions decision = TraverseIfStatement(ss as SingleLineIfStatementSyntax, ref returnCnt, true);
                    elseStm.Nested.AddRange(decision.IfStatements);
                    elseStm.Nested.AddRange(decision.ElseStatements);
                }
                else if (ss is MultiLineIfBlockSyntax)
                {
                    Decisions decisions = TraverseMultiIfStatement(ss as MultiLineIfBlockSyntax, ref returnCnt, true);
                    elseStm.Nested.AddRange(decisions.IfStatements);
                    elseStm.Nested.AddRange(decisions.ElseStatements);
                }
                else if (ss is ElseStatementSyntax)
                {
                    elseStm.Nested.Add(TravsereElseStatement(ss as ElseStatementSyntax, ref returnCnt, true));
                }
                else if (ss is ForBlockSyntax)
                {
                    Decisions tempDecision = TraverseForStatement(ss as ForBlockSyntax, ref returnCnt, true);
                    elseStm.Nested.AddRange(tempDecision.IfStatements);
                    elseStm.Nested.AddRange(tempDecision.ElseStatements);
                    elseStm.Nested.AddRange(tempDecision.ForEachStatements);
                    elseStm.Nested.AddRange(tempDecision.ForStatements);
                    elseStm.Nested.AddRange(tempDecision.WhileLoops);
                    elseStm.Nested.AddRange(tempDecision.DoWhileLoops);
                    elseStm.Nested.AddRange(tempDecision.Catches);
                    elseStm.Nested.AddRange(tempDecision.SwitchStatements);
                }
                else if (ss is SelectBlockSyntax)
                {
                    elseStm.Nested.Add(TraverseSwitchStatement(ss as SelectBlockSyntax, ref returnCnt, true));
                }
                else if (ss is DoLoopBlockSyntax)
                {
                    elseStm.Nested.Add(TraverseDoWhileLoop(ss as DoLoopBlockSyntax, ref returnCnt, true));
                }
                else if (ss is WhileBlockSyntax)
                {
                    elseStm.Nested.Add(TraverseWhileLoop(ss as WhileBlockSyntax, ref returnCnt, true));
                }
                else if (ss is CallStatementSyntax)
                {
                    elseStm.InvokedMethods.Add(TraverseInvokedMethod(ss as CallStatementSyntax));
                }
                else if (ss is ReturnStatementSyntax)
                {
                    Method tempMethod = TraverseReturnStatement(ss as ReturnStatementSyntax);
                    elseStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                    elseStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    returnCnt++;
                }
            }

            return elseStm;
        }

        private Decisions TraverseForStatement(ForBlockSyntax fbs, ref int returnCnt, bool nested = false)
        {
            Decisions retDecision = new Decisions();
            ForStatement forStm = new ForStatement();
            forStm.IsNested = nested;
            if (fbs.Begin is ForEachStatementSyntax)
            {
                retDecision.ForEachStatements.Add(TraverseForeachStatement(fbs.Begin as ForEachStatementSyntax, ref returnCnt));
            }
            else
            {
                ForStatementSyntax fss = fbs.Begin as ForStatementSyntax;

                forStm.ConditionCount = 1;
                foreach (SyntaxNode sn in fss.DescendantNodesAndSelf())
                {
                    if (sn is BinaryExpressionSyntax)
                    {
                        forStm.ConditionCount++;
                    }
                    else if (sn is IdentifierNameSyntax)
                    {
                        Variables variable = new Variables();
                        variable.IsReferenced = true;

                        variable.Name = (sn as IdentifierNameSyntax).Identifier.ValueText;
                        forStm.AccessedVars.Add(variable);
                    }
                }

                foreach (StatementSyntax ss in fbs.Statements)
                {
                    if (ss is AssignmentStatementSyntax)
                    {
                        //TODO: need to look at more than just then name!
                        Method tempMethod = TraverseAccessVars(ss as AssignmentStatementSyntax);

                        forStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                        forStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                    }
                    else if (ss is LocalDeclarationStatementSyntax)
                    {
                        Method tempMethod = TraverseVarDecls(ss as LocalDeclarationStatementSyntax);
                        forStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                        forStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                    }
                    else if (ss is SingleLineIfStatementSyntax)
                    {
                        Decisions decision = TraverseIfStatement(ss as SingleLineIfStatementSyntax, ref returnCnt, true);
                        forStm.Nested.AddRange(decision.IfStatements);
                        forStm.Nested.AddRange(decision.ElseStatements);
                    }
                    else if (ss is MultiLineIfBlockSyntax)
                    {
                        Decisions decisions = TraverseMultiIfStatement(ss as MultiLineIfBlockSyntax, ref returnCnt, true);
                        forStm.Nested.AddRange(decisions.IfStatements);
                        forStm.Nested.AddRange(decisions.ElseStatements);
                    }
                    else if (ss is ElseStatementSyntax)
                    {
                        forStm.Nested.Add(TravsereElseStatement(ss as ElseStatementSyntax, ref returnCnt, true));
                    }
                    else if (ss is ForBlockSyntax)
                    {
                        Decisions tempDecision = TraverseForStatement(ss as ForBlockSyntax, ref returnCnt, true);
                        forStm.Nested.AddRange(tempDecision.IfStatements);
                        forStm.Nested.AddRange(tempDecision.ElseStatements);
                        forStm.Nested.AddRange(tempDecision.ForEachStatements);
                        forStm.Nested.AddRange(tempDecision.ForStatements);
                        forStm.Nested.AddRange(tempDecision.WhileLoops);
                        forStm.Nested.AddRange(tempDecision.DoWhileLoops);
                        forStm.Nested.AddRange(tempDecision.Catches);
                        forStm.Nested.AddRange(tempDecision.SwitchStatements);
                    }
                    else if (ss is SelectBlockSyntax)
                    {
                        forStm.Nested.Add(TraverseSwitchStatement(ss as SelectBlockSyntax, ref returnCnt, true));
                    }
                    else if (ss is DoLoopBlockSyntax)
                    {
                        forStm.Nested.Add(TraverseDoWhileLoop(ss as DoLoopBlockSyntax, ref returnCnt, true));
                    }
                    else if (ss is WhileBlockSyntax)
                    {
                        forStm.Nested.Add(TraverseWhileLoop(ss as WhileBlockSyntax, ref returnCnt, true));
                    }
                    else if (ss is CallStatementSyntax)
                    {
                        forStm.InvokedMethods.Add(TraverseInvokedMethod(ss as CallStatementSyntax));
                    }
                    else if (ss is ReturnStatementSyntax)
                    {
                        Method tempMethod = TraverseReturnStatement(ss as ReturnStatementSyntax);
                        forStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                        forStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                        returnCnt++;
                    }
                }
            }
            retDecision.ForStatements.Add(forStm);
            return retDecision;
        }

        private ForEachStatement TraverseForeachStatement(ForEachStatementSyntax fess, ref int returnCnt, bool nested = false)
        {
            ForEachStatement foreachStm = new ForEachStatement();
            foreachStm.IsNested = nested;
            foreachStm.ConditionCount = 1;
            bool skipId = false;
            int skipIds = 0;
            foreach (SyntaxNode sn in fess.ChildNodes())
            {
                if (sn is BinaryExpressionSyntax)
                {
                    foreachStm.ConditionCount++;
                }
                else if (sn is VariableDeclaratorSyntax)
                {
                    foreachStm.AccessedVars.Add(TraverseVariableSyntax(sn as VariableDeclaratorSyntax, null, null));
                    skipId = true;
                }
                else if (sn is InvocationExpressionSyntax)
                {
                    InvokedMethod invokedMethod = TraverseInvokedMethod(sn as InvocationExpressionSyntax);
                    foreachStm.InvokedMethods.Add(invokedMethod);
                    skipId = true;
                    skipIds = invokedMethod.Parameters.Count;
                }
                else if (sn is IdentifierNameSyntax)
                {
                    if (!skipId)
                    {
                        Variables variable = new Variables();
                        variable.IsReferenced = true;

                        variable.Name = (sn as IdentifierNameSyntax).Identifier.ValueText;
                        foreachStm.AccessedVars.Add(variable);
                    }
                    else if (skipIds == 0)
                    {
                        skipId = false;
                    }
                    else
                    {
                        skipIds--;
                    }
                }
                
            }

            ForBlockSyntax fbs = fess.Parent as ForBlockSyntax;

            foreach (StatementSyntax ss in fbs.Statements)
            {
                if (ss is AssignmentStatementSyntax)
                {
                    //TODO: need to look at more than just then name!
                    Method tempMethod = TraverseAccessVars(ss as AssignmentStatementSyntax);

                    foreachStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    foreachStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                else if (ss is LocalDeclarationStatementSyntax)
                {
                    Method tempMethod = TraverseVarDecls(ss as LocalDeclarationStatementSyntax);
                    foreachStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    foreachStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                else if (ss is SingleLineIfStatementSyntax)
                {
                    Decisions decision = TraverseIfStatement(ss as SingleLineIfStatementSyntax, ref returnCnt, true);
                    foreachStm.Nested.AddRange(decision.IfStatements);
                    foreachStm.Nested.AddRange(decision.ElseStatements);
                }
                else if (ss is MultiLineIfBlockSyntax)
                {
                    Decisions decisions = TraverseMultiIfStatement(ss as MultiLineIfBlockSyntax, ref returnCnt, true);
                    foreachStm.Nested.AddRange(decisions.IfStatements);
                    foreachStm.Nested.AddRange(decisions.ElseStatements);
                }
                else if (ss is ForBlockSyntax)
                {
                    Decisions tempDecision = TraverseForStatement(ss as ForBlockSyntax, ref returnCnt, true);
                    foreachStm.Nested.AddRange(tempDecision.IfStatements);
                    foreachStm.Nested.AddRange(tempDecision.ElseStatements);
                    foreachStm.Nested.AddRange(tempDecision.ForEachStatements);
                    foreachStm.Nested.AddRange(tempDecision.ForStatements);
                    foreachStm.Nested.AddRange(tempDecision.WhileLoops);
                    foreachStm.Nested.AddRange(tempDecision.DoWhileLoops);
                    foreachStm.Nested.AddRange(tempDecision.Catches);
                    foreachStm.Nested.AddRange(tempDecision.SwitchStatements);
                }
                else if (ss is ElseStatementSyntax)
                {
                    foreachStm.Nested.Add(TravsereElseStatement(ss as ElseStatementSyntax, ref returnCnt, true));
                }
                else if (ss is SelectBlockSyntax)
                {
                    foreachStm.Nested.Add(TraverseSwitchStatement(ss as SelectBlockSyntax, ref returnCnt, true));
                }
                else if (ss is DoLoopBlockSyntax)
                {
                    foreachStm.Nested.Add(TraverseDoWhileLoop(ss as DoLoopBlockSyntax, ref returnCnt, true));
                }
                else if (ss is WhileBlockSyntax)
                {
                    foreachStm.Nested.Add(TraverseWhileLoop(ss as WhileBlockSyntax, ref returnCnt, true));
                }
                else if (ss is CallStatementSyntax)
                {
                    foreachStm.InvokedMethods.Add(TraverseInvokedMethod(ss as CallStatementSyntax));
                }
                else if (ss is ReturnStatementSyntax)
                {
                    Method tempMethod = TraverseReturnStatement(ss as ReturnStatementSyntax);
                    foreachStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                    foreachStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    returnCnt++;
                }
            }
            return foreachStm;
        }

        private WhileLoop TraverseWhileLoop(WhileBlockSyntax wbs, ref int returnCnt, bool nested = false)
        {
            WhileLoop whileLoop = new WhileLoop();
            whileLoop.IsNested = nested;
            WhileStatementSyntax wss = wbs.WhileStatement;

            foreach (SyntaxNode sn in wss.Condition.DescendantNodesAndSelf())
            {
                if (sn is BinaryExpressionSyntax)
                {
                    whileLoop.ConditionCount++;
                }
                else if (sn is IdentifierNameSyntax)
                {
                    Variables variable = new Variables();
                    variable.IsReferenced = true;

                    variable.Name = (sn as IdentifierNameSyntax).Identifier.ValueText;
                    whileLoop.AccessedVars.Add(variable);
                }
            }

            foreach (StatementSyntax ss in wbs.Statements)
            {
                if (ss is AssignmentStatementSyntax)
                {
                    //TODO: need to look at more than just then name!
                    Method tempMethod = TraverseAccessVars(ss as AssignmentStatementSyntax);

                    whileLoop.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    whileLoop.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                else if (ss is LocalDeclarationStatementSyntax)
                {
                    Method tempMethod = TraverseVarDecls(ss as LocalDeclarationStatementSyntax);
                        whileLoop.AccessedVars.AddRange(tempMethod.AccessedVariables);
                        whileLoop.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                else if (ss is SingleLineIfStatementSyntax)
                {
                    Decisions decision = TraverseIfStatement(ss as SingleLineIfStatementSyntax, ref returnCnt, true);
                    whileLoop.Nested.AddRange(decision.IfStatements);
                    whileLoop.Nested.AddRange(decision.ElseStatements);
                }
                else if (ss is MultiLineIfBlockSyntax)
                {
                    Decisions decisions = TraverseMultiIfStatement(ss as MultiLineIfBlockSyntax, ref returnCnt, true);
                    whileLoop.Nested.AddRange(decisions.IfStatements);
                    whileLoop.Nested.AddRange(decisions.ElseStatements);
                }
                else if (ss is ElseStatementSyntax)
                {
                    whileLoop.Nested.Add(TravsereElseStatement(ss as ElseStatementSyntax, ref returnCnt, true));
                }
                else if (ss is ForBlockSyntax)
                {
                    Decisions tempDecision = TraverseForStatement(ss as ForBlockSyntax, ref returnCnt, true);
                    whileLoop.Nested.AddRange(tempDecision.IfStatements);
                    whileLoop.Nested.AddRange(tempDecision.ElseStatements);
                    whileLoop.Nested.AddRange(tempDecision.ForEachStatements);
                    whileLoop.Nested.AddRange(tempDecision.ForStatements);
                    whileLoop.Nested.AddRange(tempDecision.WhileLoops);
                    whileLoop.Nested.AddRange(tempDecision.DoWhileLoops);
                    whileLoop.Nested.AddRange(tempDecision.Catches);
                    whileLoop.Nested.AddRange(tempDecision.SwitchStatements);
                }
                else if (ss is SelectBlockSyntax)
                {
                    whileLoop.Nested.Add(TraverseSwitchStatement(ss as SelectBlockSyntax, ref returnCnt, true));
                }
                else if (ss is DoLoopBlockSyntax)
                {
                    whileLoop.Nested.Add(TraverseDoWhileLoop(ss as DoLoopBlockSyntax, ref returnCnt, true));
                }
                else if (ss is WhileBlockSyntax)
                {
                    whileLoop.Nested.Add(TraverseWhileLoop(ss as WhileBlockSyntax, ref returnCnt, true));
                }
                else if (ss is CallStatementSyntax)
                {
                    whileLoop.InvokedMethods.Add(TraverseInvokedMethod(ss as CallStatementSyntax));
                }
                else if (ss is ReturnStatementSyntax)
                {
                    Method tempMethod = TraverseReturnStatement(ss as ReturnStatementSyntax);
                    whileLoop.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                    whileLoop.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    returnCnt++;
                }
            }
            return whileLoop;
        }

        private DoWhileLoop TraverseDoWhileLoop(DoLoopBlockSyntax dbs, ref int returnCnt, bool nested = false)
        {
            DoWhileLoop doWhileLoop = new DoWhileLoop();
            DoStatementSyntax dss = dbs.DoStatement;
            doWhileLoop.IsNested = nested;
            foreach (SyntaxNode sn in dss.DescendantNodesAndSelf())
            {
                if (sn is BinaryExpressionSyntax)
                {
                    doWhileLoop.ConditionCount++;
                }
                else if (sn is IdentifierNameSyntax)
                {
                    Variables variable = new Variables();
                    variable.IsReferenced = true;

                    variable.Name = (sn as IdentifierNameSyntax).Identifier.ValueText;
                    doWhileLoop.AccessedVars.Add(variable);
                }
            }

            foreach (StatementSyntax ss in dbs.Statements)
            {
                if (ss is AssignmentStatementSyntax)
                {
                    //TODO: need to look at more than just then name!
                    Method tempMethod = TraverseAccessVars(ss as AssignmentStatementSyntax);

                    doWhileLoop.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    doWhileLoop.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                else if (ss is LocalDeclarationStatementSyntax)
                {
                    Method tempMethod = TraverseVarDecls(ss as LocalDeclarationStatementSyntax);
                    doWhileLoop.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    doWhileLoop.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                else if (ss is SingleLineIfStatementSyntax)
                {
                    Decisions decision = TraverseIfStatement(ss as SingleLineIfStatementSyntax, ref returnCnt, true);
                    doWhileLoop.Nested.AddRange(decision.IfStatements);
                    doWhileLoop.Nested.AddRange(decision.ElseStatements);
                }
                else if (ss is MultiLineIfBlockSyntax)
                {
                    Decisions decisions = TraverseMultiIfStatement(ss as MultiLineIfBlockSyntax, ref returnCnt, true);
                    doWhileLoop.Nested.AddRange(decisions.IfStatements);
                    doWhileLoop.Nested.AddRange(decisions.ElseStatements);
                }
                else if (ss is ElseStatementSyntax)
                {
                    doWhileLoop.Nested.Add(TravsereElseStatement(ss as ElseStatementSyntax, ref returnCnt, true));
                }
                else if (ss is ForBlockSyntax)
                {
                    Decisions tempDecision = TraverseForStatement(ss as ForBlockSyntax, ref returnCnt, true);
                    doWhileLoop.Nested.AddRange(tempDecision.IfStatements);
                    doWhileLoop.Nested.AddRange(tempDecision.ElseStatements);
                    doWhileLoop.Nested.AddRange(tempDecision.ForEachStatements);
                    doWhileLoop.Nested.AddRange(tempDecision.ForStatements);
                    doWhileLoop.Nested.AddRange(tempDecision.WhileLoops);
                    doWhileLoop.Nested.AddRange(tempDecision.DoWhileLoops);
                    doWhileLoop.Nested.AddRange(tempDecision.Catches);
                    doWhileLoop.Nested.AddRange(tempDecision.SwitchStatements);
                }
                else if (ss is SelectBlockSyntax)
                {
                    doWhileLoop.Nested.Add(TraverseSwitchStatement(ss as SelectBlockSyntax, ref returnCnt, true));
                }
                else if (ss is DoLoopBlockSyntax)
                {
                    doWhileLoop.Nested.Add(TraverseDoWhileLoop(ss as DoLoopBlockSyntax, ref returnCnt, true));
                }
                else if (ss is WhileBlockSyntax)
                {
                    doWhileLoop.Nested.Add(TraverseWhileLoop(ss as WhileBlockSyntax, ref returnCnt, true));
                }
                else if (ss is CallStatementSyntax)
                {
                    doWhileLoop.InvokedMethods.Add(TraverseInvokedMethod(ss as CallStatementSyntax));
                }
                else if (ss is ReturnStatementSyntax)
                {
                    Method tempMethod = TraverseReturnStatement(ss as ReturnStatementSyntax);
                    doWhileLoop.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                    doWhileLoop.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    returnCnt++;
                }
            }

            return doWhileLoop;
        }

        private ElseStatement TravsereElseStatement(ElseStatementSyntax ess, ref int returnCnt, bool nested = false)
        {
            ElseStatement elseStm = new ElseStatement();
            elseStm.IsNested = true;

            return elseStm;
        }

        private SwitchStatement TraverseSwitchStatement(SelectBlockSyntax sbs, ref int returnCnt, bool nested = false)
        {
            SwitchStatement switchStm = new SwitchStatement();
            switchStm.IsNested = nested;
            SelectStatementSyntax sss = sbs.SelectStatement;

            foreach (SyntaxNode sn in sss.DescendantNodesAndSelf())
            {
                if (sn is BinaryExpressionSyntax)
                {
                    switchStm.ConditionCount++;
                }
                else if (sn is IdentifierNameSyntax)
                {
                    Variables variable = new Variables();
                    variable.IsReferenced = true;

                    variable.Name = (sn as IdentifierNameSyntax).Identifier.ValueText;
                    switchStm.AccessedVars.Add(variable);
                }
            }

            foreach (CaseBlockSyntax cbb in sbs.CaseBlocks)
            {
                CaseStatement aCase = new CaseStatement();

                foreach (SyntaxNode sn in cbb.Begin.DescendantNodesAndSelf())
                {
                    if (sn is BinaryExpressionSyntax)
                    {
                        switchStm.ConditionCount++;
                    }
                    else if (sn is IdentifierNameSyntax)
                    {
                        Variables variable = new Variables();
                        variable.IsReferenced = true;

                        variable.Name = (sn as IdentifierNameSyntax).Identifier.ValueText;
                        aCase.AccessedVars.Add(variable);
                    }
                }
                foreach (StatementSyntax ss in cbb.Statements)
                {

                    if (ss is AssignmentStatementSyntax)
                    {
                        //TODO: need to look at more than just then name!
                        Method tempMethod = TraverseAccessVars(ss as AssignmentStatementSyntax);

                        aCase.AccessedVars.AddRange(tempMethod.AccessedVariables);
                        aCase.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                    }
                    else if (ss is LocalDeclarationStatementSyntax)
                    {
                        Method tempMethod = TraverseVarDecls(ss as LocalDeclarationStatementSyntax);
                        aCase.AccessedVars.AddRange(tempMethod.AccessedVariables);
                        aCase.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                    }
                    else if (ss is SingleLineIfStatementSyntax)
                    {
                        Decisions decision = TraverseIfStatement(ss as SingleLineIfStatementSyntax, ref returnCnt, true);
                        aCase.Nested.AddRange(decision.IfStatements);
                        aCase.Nested.AddRange(decision.ElseStatements);
                    }
                    else if (ss is MultiLineIfBlockSyntax)
                    {
                        Decisions decisions = TraverseMultiIfStatement(ss as MultiLineIfBlockSyntax, ref returnCnt, true);
                        aCase.Nested.AddRange(decisions.IfStatements);
                        aCase.Nested.AddRange(decisions.ElseStatements);
                    }
                    else if (ss is ElseStatementSyntax)
                    {
                        aCase.Nested.Add(TravsereElseStatement(ss as ElseStatementSyntax, ref returnCnt, true));
                    }
                    else if (ss is ForBlockSyntax)
                    {
                        Decisions tempDecision = TraverseForStatement(ss as ForBlockSyntax, ref returnCnt, true);
                        aCase.Nested.AddRange(tempDecision.IfStatements);
                        aCase.Nested.AddRange(tempDecision.ElseStatements);
                        aCase.Nested.AddRange(tempDecision.ForEachStatements);
                        aCase.Nested.AddRange(tempDecision.ForStatements);
                        aCase.Nested.AddRange(tempDecision.WhileLoops);
                        aCase.Nested.AddRange(tempDecision.DoWhileLoops);
                        aCase.Nested.AddRange(tempDecision.Catches);
                        aCase.Nested.AddRange(tempDecision.SwitchStatements);
                    }
                    else if (ss is SelectBlockSyntax)
                    {
                        aCase.Nested.Add(TraverseSwitchStatement(ss as SelectBlockSyntax, ref returnCnt, true));
                    }
                    else if (ss is DoLoopBlockSyntax)
                    {
                        aCase.Nested.Add(TraverseDoWhileLoop(ss as DoLoopBlockSyntax, ref returnCnt, true));
                    }
                    else if (ss is WhileBlockSyntax)
                    {
                        aCase.Nested.Add(TraverseWhileLoop(ss as WhileBlockSyntax, ref returnCnt, true));
                    }
                    else if (ss is CallStatementSyntax)
                    {
                        aCase.InvokedMethods.Add(TraverseInvokedMethod(ss as CallStatementSyntax));
                    }
                    else if (ss is ReturnStatementSyntax)
                    {
                        Method tempMethod = TraverseReturnStatement(ss as ReturnStatementSyntax);
                        aCase.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                        aCase.AccessedVars.AddRange(tempMethod.AccessedVariables);
                        returnCnt++;
                    }
                }
                switchStm.CaseStatements.Add(aCase);
            }

            return switchStm;
        }

        private CatchStatements TraverseCatchStatement(CatchPartSyntax cps, ref int returnCnt, bool nested = false)
        {
            CatchStatements catchStm = new CatchStatements();
            catchStm.IsNested = nested;
            CatchStatementSyntax css = cps.Begin;

            foreach (SyntaxNode sn in css.DescendantNodesAndSelf())
            {
                if (sn is IdentifierNameSyntax)
                {
                    Variables variable = new Variables();
                    variable.IsReferenced = true;

                    variable.Name = (sn as IdentifierNameSyntax).Identifier.ValueText;
                    catchStm.AccessedVars.Add(variable);
                }
            }

            foreach (StatementSyntax ss in cps.Statements)
            {
                if (ss is AssignmentStatementSyntax)
                {
                    //TODO: need to look at more than just then name!
                    Method tempMethod = TraverseAccessVars(ss as AssignmentStatementSyntax);

                    catchStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    catchStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                else if (ss is LocalDeclarationStatementSyntax)
                {
                    Method tempMethod = TraverseVarDecls(ss as LocalDeclarationStatementSyntax);
                    catchStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    catchStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                else if (ss is SingleLineIfStatementSyntax)
                {
                    Decisions decision = TraverseIfStatement(ss as SingleLineIfStatementSyntax, ref returnCnt, true);
                    catchStm.Nested.AddRange(decision.IfStatements);
                    catchStm.Nested.AddRange(decision.ElseStatements);
                }
                else if (ss is MultiLineIfBlockSyntax)
                {
                    Decisions decisions = TraverseMultiIfStatement(ss as MultiLineIfBlockSyntax, ref returnCnt, true);
                    catchStm.Nested.AddRange(decisions.IfStatements);
                    catchStm.Nested.AddRange(decisions.ElseStatements);
                }
                else if (ss is ElseStatementSyntax)
                {
                    catchStm.Nested.Add(TravsereElseStatement(ss as ElseStatementSyntax, ref returnCnt, true));
                }
                else if (ss is ForBlockSyntax)
                {
                    Decisions tempDecision = TraverseForStatement(ss as ForBlockSyntax, ref returnCnt, true);
                    catchStm.Nested.AddRange(tempDecision.IfStatements);
                    catchStm.Nested.AddRange(tempDecision.ElseStatements);
                    catchStm.Nested.AddRange(tempDecision.ForEachStatements);
                    catchStm.Nested.AddRange(tempDecision.ForStatements);
                    catchStm.Nested.AddRange(tempDecision.WhileLoops);
                    catchStm.Nested.AddRange(tempDecision.DoWhileLoops);
                    catchStm.Nested.AddRange(tempDecision.Catches);
                    catchStm.Nested.AddRange(tempDecision.SwitchStatements);
                }
                else if (ss is SelectBlockSyntax)
                {
                    catchStm.Nested.Add(TraverseSwitchStatement(ss as SelectBlockSyntax, ref returnCnt, true));
                }
                else if (ss is DoLoopBlockSyntax)
                {
                    catchStm.Nested.Add(TraverseDoWhileLoop(ss as DoLoopBlockSyntax, ref returnCnt, true));
                }
                else if (ss is WhileBlockSyntax)
                {
                    catchStm.Nested.Add(TraverseWhileLoop(ss as WhileBlockSyntax, ref returnCnt, true));
                }
                else if (ss is CallStatementSyntax)
                {
                    catchStm.InvokedMethods.Add(TraverseInvokedMethod(ss as CallStatementSyntax));
                }
                else if (ss is ReturnStatementSyntax)
                {
                    Method tempMethod = TraverseReturnStatement(ss as ReturnStatementSyntax);
                    catchStm.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                    catchStm.AccessedVars.AddRange(tempMethod.AccessedVariables);
                    returnCnt++;
                }
            }

            return catchStm;
        }

        #endregion

        private Variables TraverseParameters(ParameterSyntax vds)
        {
            Variables retVar = new Variables();

            retVar.Name = vds.Identifier.ToString();

            retVar.IsReferenced = false;

            //Encapsulation
            foreach (SyntaxToken st in vds.Modifiers)
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

            AsClauseSyntax acs = vds.AsClause;
            TypeSyntax ts = acs.Type();
            Model.Type type = new Model.Type();
            type.Name = ts.ToString();
            type.IsKnownType = SyntaxFacts.IsKeywordKind(ts.VisualBasicKind());
            type.IsNotUserDefined = SyntaxFacts.IsKeywordKind(ts.VisualBasicKind());

            return retVar;
        }

        private Method TraverseVarDecls(LocalDeclarationStatementSyntax ldss)
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

            foreach (SyntaxNode ss in ldss.ChildNodes())
            {
                if (ss is VariableDeclaratorSyntax)
                {
                    Variables retVar = new Variables();
                    retVar = TraverseVariableSyntax(ss as VariableDeclaratorSyntax, accessability, qualifiers);
                    retMethod.AccessedVariables.Add(retVar);
                }
                else if (ss is CallStatementSyntax)
                {
                    retMethod.InvokedMethods.Add(TraverseInvokedMethod(ss as CallStatementSyntax));
                }
            }

            return retMethod;
        }

        private Variables TraverseVariableSyntax(VariableDeclaratorSyntax vds, List<Encapsulation> accessability, List<Qualifiers> qualifiers)
        {
            Variables retVar = new Variables();
            if (accessability != null)
            {
                retVar.Accessibility = accessability;
            }
            if (qualifiers != null)
            {
                retVar.Qualifiers = qualifiers;
            }
            foreach (ModifiedIdentifierSyntax mis in vds.Names)
            {
                retVar.Name = retVar.Name == null ? mis.Identifier.ValueText : retVar.Name + "." + mis.Identifier.ValueText;
            }

            AsClauseSyntax acs = vds.AsClause;
            TypeSyntax ts = acs.Type();
            Model.Type type = new Model.Type();
            type.Name = ts.ToString();
            type.IsKnownType = SyntaxFacts.IsKeywordKind(ts.VisualBasicKind());
            type.IsNotUserDefined = SyntaxFacts.IsKeywordKind(ts.VisualBasicKind());

            return retVar;
        }

        private Method TraverseAccessVars(AssignmentStatementSyntax vnes)
        {
            Method retMethod = new Method();
            if (vnes.Left is IdentifierNameSyntax)
            {
                Variables retVar = new Variables();
                retVar.IsReferenced = true;
                retVar.Name = (vnes.Left as IdentifierNameSyntax).Identifier.ValueText;
                retMethod.AccessedVariables.Add(retVar);
            }
            else if (vnes.Left is MemberAccessExpressionSyntax)
            {
                MemberAccessExpressionSyntax maes = vnes.Left as MemberAccessExpressionSyntax;
                Variables retVar = new Variables();
                retVar.Name = maes.ToString();
                retVar.IsReferenced = true;
                retMethod.AccessedVariables.Add(retVar);
            }
            else
            {
                foreach (SyntaxNode sn in vnes.Left.ChildNodes())
                {
                    if (sn is VariableDeclaratorSyntax)
                    {
                        Variables retVar = new Variables();
                        retVar = TraverseVariableSyntax(sn as VariableDeclaratorSyntax, null, null);
                        retVar.IsReferenced = true;
                        retMethod.AccessedVariables.Add(retVar);
                    }
                    else if (sn is CallStatementSyntax)
                    {
                        retMethod.InvokedMethods.Add(TraverseInvokedMethod(sn as CallStatementSyntax));
                    }
                    else if (sn is MemberAccessExpressionSyntax)
                    {
                        MemberAccessExpressionSyntax maes = sn as MemberAccessExpressionSyntax;
                        Variables retVar = new Variables();
                        retVar.Name = maes.ToString();
                        retVar.IsReferenced = true;
                        retMethod.AccessedVariables.Add(retVar);
                    }
                }
            }
            if (vnes.Right is IdentifierNameSyntax)
            {
                Variables retVar = new Variables();
                retVar.IsReferenced = true;
                retVar.Name = (vnes.Right as IdentifierNameSyntax).Identifier.ValueText;
                retMethod.AccessedVariables.Add(retVar);
            }
            else if (vnes.Right is MemberAccessExpressionSyntax)
            {
                MemberAccessExpressionSyntax maes = vnes.Right as MemberAccessExpressionSyntax;
                Variables retVar = new Variables();
                retVar.Name = maes.ToString();
                retVar.IsReferenced = true;
                retMethod.AccessedVariables.Add(retVar);
            }
            else
            {
                foreach (SyntaxNode sn in vnes.Right.ChildNodes())
                {
                    if (sn is VariableDeclaratorSyntax)
                    {
                        Variables retVar = new Variables();
                        retVar = TraverseVariableSyntax(sn as VariableDeclaratorSyntax, null, null);
                        retVar.IsReferenced = true;
                        retMethod.AccessedVariables.Add(retVar);
                    }
                    else if (sn is CallStatementSyntax)
                    {
                        retMethod.InvokedMethods.Add(TraverseInvokedMethod(sn as CallStatementSyntax));
                    }
                    else if (sn is MemberAccessExpressionSyntax)
                    {
                        MemberAccessExpressionSyntax maes = sn as MemberAccessExpressionSyntax;
                        Variables retVar = new Variables();
                        retVar.Name = maes.ToString();
                        retVar.IsReferenced = true;
                        retMethod.AccessedVariables.Add(retVar);
                    }
                }
            }
            
            return retMethod;
        }

        private LabelStatement TraverseLabel(LabelStatementSyntax lss)
        {
            LabelStatement labelStm = new LabelStatement();

            labelStm.Name = lss.LabelToken.ValueText;

            return labelStm;
        }

        private GoTo TraverseGoTo(List<LabelStatement> labels, GoToStatementSyntax gtss)
        {
            GoTo gotoStm = new GoTo();

            LabelSyntax lss = gtss.Label;

            string lblName = lss.LabelToken.ValueText;

            bool found = false;

            foreach(LabelStatement lblStm in labels){
                if (lblStm.Name == lblName)
                {
                    gotoStm.GoToLabel = lblStm;
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                gotoStm.GoToLabel = new LabelStatement() { Name = lblName };
            }

            return gotoStm;
        }

        private InvokedMethod TraverseInvokedMethod(InvocationExpressionSyntax ies)
        {
            InvokedMethod invokedMethod = new InvokedMethod();

            ExpressionSyntax es = ies.Expression;
            if (es is IdentifierNameSyntax)
            {
                invokedMethod.Name = (es as IdentifierNameSyntax).Identifier.ValueText;
            }
            else if (es is MemberAccessExpressionSyntax)
            {
                MemberAccessExpressionSyntax maes = es as MemberAccessExpressionSyntax;
                invokedMethod.Name = (maes.Name as SimpleNameSyntax).Identifier.ValueText;
                //TODO: What about the expression? Is it a variable? I think so!?f
            }

            if (ies.ArgumentList != null)
            {
                foreach (ArgumentSyntax argSyn in ies.ArgumentList.Arguments)
                {
                    Variables parameter = new Variables();
                    parameter.Name = argSyn.ToString();
                    invokedMethod.Parameters.Add(parameter);
                }
            }

            return invokedMethod;
        }

        private InvokedMethod TraverseInvokedMethod(CallStatementSyntax css)
        {
            InvokedMethod invokedMethod = new InvokedMethod();

            InvocationExpressionSyntax invokeInfo = css.Invocation as InvocationExpressionSyntax;
            if (invokeInfo.ArgumentList != null)
            {
                foreach (ArgumentSyntax argSyn in invokeInfo.ArgumentList.Arguments)
                {
                    Variables parameter = new Variables();
                    parameter.Name = argSyn.ToString();
                    invokedMethod.Parameters.Add(parameter);
                }
            }
            ExpressionSyntax es = invokeInfo.Expression;
            if (es is IdentifierNameSyntax)
            {
                invokedMethod.Name = (es as IdentifierNameSyntax).Identifier.ValueText;
            }
            else if(es is MemberAccessExpressionSyntax)
            {
                MemberAccessExpressionSyntax maes = es as MemberAccessExpressionSyntax;
                invokedMethod.Name = (maes.Name as SimpleNameSyntax).Identifier.ValueText;
                //TODO: What about the expression? Is it a variable? I think so!?
            }

            return invokedMethod;
        }

        private Method TraverseReturnStatement(ReturnStatementSyntax rss)
        {
            Method retMethod = new Method();

            foreach (SyntaxNode sn in rss.ChildNodes())
            {
                if (sn is CallStatementSyntax)
                {
                    retMethod.InvokedMethods.Add(TraverseInvokedMethod(sn as CallStatementSyntax));
                }
                else if (sn is InvocationExpressionSyntax)
                {
                    retMethod.InvokedMethods.Add(TraverseInvokedMethod(sn as InvocationExpressionSyntax));
                }
                else if (sn is LocalDeclarationStatementSyntax)
                {
                    Method tempMethod = TraverseVarDecls(sn as LocalDeclarationStatementSyntax);
                    retMethod.AccessedVariables.AddRange(tempMethod.AccessedVariables);
                    retMethod.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
                else if (sn is AssignmentStatementSyntax)
                {
                    Method tempMethod = TraverseAccessVars(sn as AssignmentStatementSyntax);

                    retMethod.AccessedVariables.AddRange(tempMethod.AccessedVariables);
                    retMethod.InvokedMethods.AddRange(tempMethod.InvokedMethods);
                }
            }

            return retMethod;
        }

        #endregion

        private Variables TraverseField(FieldDeclarationSyntax fds)
        {
            Variables retVar = new Variables();

            //Name
            
            //Encapsulation
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

            return retVar;
        }

        private Property TraverseProperties(PropertyBlockSyntax pbs)
        {
            Property retProperty = new Property();

            return retProperty;

        }

        private Constructor TraverseConstructor(ConstructorBlockSyntax css)
        {
            Constructor retConstructor = new Constructor();


            retConstructor.Name = "New";

            /*
            Preprocessors = new List<Preprocessor>();
            Encapsulation = new List<Encapsulation>();
            Base = new List<InvokedMethod>();
            ReturnType = new Type();
            Qualifiers = new List<Qualifiers>();
            Parameters = new List<Variables>();
            Decisions = new Decisions();
            AccessedVariables = new List<Variables>();
            LabelStatements = new List<LabelStatement>();
            GoToStatements = new List<GoTo>();
            InvokedMethods = new List<InvokedMethod>();
             */



            //Encapsulation
            //TODO: Not sure if Begin is the right thing here...
            foreach (SyntaxToken st in css.Begin.Modifiers)
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

            //TODO: Need to determine what the qualifers are

            //TODO: Qualifiers

            //TODO: Not Sure About This!
            ParameterListSyntax pls = css.Begin.ParameterList;

            //Parameters
            foreach (ParameterSyntax ps in pls.Parameters)
            {
                retConstructor.Parameters.Add(TraverseParameters(ps));
            }

            //Decisions
            List<MultiLineIfBlockSyntax> multiIfStms = new List<MultiLineIfBlockSyntax>();
            List<SingleLineIfStatementSyntax> ifStms = new List<SingleLineIfStatementSyntax>();
            List<ElseStatementSyntax> elseStm = new List<ElseStatementSyntax>();
            List<ForEachStatementSyntax> foreachStm = new List<ForEachStatementSyntax>();
            List<ForBlockSyntax> forStm = new List<ForBlockSyntax>();
            List<DoLoopBlockSyntax> doWhileStm = new List<DoLoopBlockSyntax>();
            List<WhileBlockSyntax> whileStm = new List<WhileBlockSyntax>();
            List<SelectBlockSyntax> switchStm = new List<SelectBlockSyntax>();
            List<CatchPartSyntax> catchStmm = new List<CatchPartSyntax>();
            //Access Variables
            List<LocalDeclarationStatementSyntax> accessVarDefs = new List<LocalDeclarationStatementSyntax>();
            List<AssignmentStatementSyntax> accessVars = new List<AssignmentStatementSyntax>();
            //Label Statements
            List<LabelStatementSyntax> labelStms = new List<LabelStatementSyntax>();
            //GoTo Statements
            List<GoToStatementSyntax> gotoStms = new List<GoToStatementSyntax>();
            //InvokedMethods
            List<CallStatementSyntax> invokedMethods = new List<CallStatementSyntax>();
            List<InvocationExpressionSyntax> invokedMethods2 = new List<InvocationExpressionSyntax>();
            //Returns
            List<ReturnStatementSyntax> returns = new List<ReturnStatementSyntax>();

            //MethodBlockSyntax mbs = css.Parent as MethodBlockSyntax;

            foreach (SyntaxNode sn in css.Statements)
            {
                if (sn is MultiLineIfBlockSyntax)
                {
                    multiIfStms.Add(sn as MultiLineIfBlockSyntax);
                }
                if (sn is SingleLineIfStatementSyntax)
                {
                    ifStms.Add(sn as SingleLineIfStatementSyntax);
                }
                else if (sn is ElseStatementSyntax)
                {
                    elseStm.Add(sn as ElseStatementSyntax);
                }
                else if (sn is ForEachStatementSyntax)
                {
                    foreachStm.Add(sn as ForEachStatementSyntax);
                }
                else if (sn is ForBlockSyntax)
                {
                    forStm.Add(sn as ForBlockSyntax);
                }
                else if (sn is DoLoopBlockSyntax)
                {
                    doWhileStm.Add(sn as DoLoopBlockSyntax);
                }
                else if (sn is WhileBlockSyntax)
                {
                    whileStm.Add(sn as WhileBlockSyntax);
                }
                else if (sn is SelectBlockSyntax)
                {
                    switchStm.Add(sn as SelectBlockSyntax);
                }
                else if (sn is CatchPartSyntax)
                {
                    catchStmm.Add(sn as CatchPartSyntax);
                }
                else if (sn is LocalDeclarationStatementSyntax)
                {
                    accessVarDefs.Add(sn as LocalDeclarationStatementSyntax);
                }
                else if (sn is AssignmentStatementSyntax)
                {
                    accessVars.Add(sn as AssignmentStatementSyntax);
                }
                else if (sn is LabelStatementSyntax)
                {
                    labelStms.Add(sn as LabelStatementSyntax);
                }
                else if (sn is LabelStatementSyntax)
                {
                    gotoStms.Add(sn as GoToStatementSyntax);
                }
                else if (sn is GoToStatementSyntax)
                {
                    gotoStms.Add(sn as GoToStatementSyntax);
                }
                else if (sn is CallStatementSyntax)
                {
                    invokedMethods.Add(sn as CallStatementSyntax);
                }
                else if (sn is InvocationExpressionSyntax)
                {
                    invokedMethods2.Add(sn as InvocationExpressionSyntax);
                }
                else if (sn is ReturnStatementSyntax)
                {
                    returns.Add(sn as ReturnStatementSyntax);
                }
            }

            foreach (MultiLineIfBlockSyntax mlbs in multiIfStms)
            {
                int exitPoints = retConstructor.ExitPoints;
                Decisions tempDecision = TraverseMultiIfStatement(mlbs, ref exitPoints);

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

            foreach (SingleLineIfStatementSyntax iss in ifStms)
            {
                int exitPoints = retConstructor.ExitPoints;
                Decisions tempDecision = TraverseIfStatement(iss, ref exitPoints);
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
            foreach (ElseStatementSyntax ess in elseStm)
            {
                int exitPoints = retConstructor.ExitPoints;
                retConstructor.Decisions.ElseStatements.Add(TravsereElseStatement(ess, ref exitPoints));
                retConstructor.ExitPoints = exitPoints;
            }
            foreach (ForEachStatementSyntax fess in foreachStm)
            {
                int exitPoints = retConstructor.ExitPoints;
                retConstructor.Decisions.ForEachStatements.Add(TraverseForeachStatement(fess, ref exitPoints));
                retConstructor.ExitPoints = exitPoints;
            }
            foreach (ForBlockSyntax fss in forStm)
            {
                int exitPoints = retConstructor.ExitPoints;
                Decisions tempDecision = TraverseForStatement(fss, ref exitPoints);
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
            foreach (DoLoopBlockSyntax dss in doWhileStm)
            {
                int exitPoints = retConstructor.ExitPoints;
                retConstructor.Decisions.DoWhileLoops.Add(TraverseDoWhileLoop(dss, ref exitPoints));
                retConstructor.ExitPoints = exitPoints;
            }
            foreach (WhileBlockSyntax wbs in whileStm)
            {
                int exitPoints = retConstructor.ExitPoints;
                retConstructor.Decisions.WhileLoops.Add(TraverseWhileLoop(wbs, ref exitPoints));
                retConstructor.ExitPoints = exitPoints;
            }
            foreach (SelectBlockSyntax sbs in switchStm)
            {
                int exitPoints = retConstructor.ExitPoints;
                retConstructor.Decisions.SwitchStatements.Add(TraverseSwitchStatement(sbs, ref exitPoints));
                retConstructor.ExitPoints = exitPoints;
            }
            foreach (CatchPartSyntax cps in catchStmm)
            {
                int exitPoints = retConstructor.ExitPoints;
                retConstructor.Decisions.Catches.Add(TraverseCatchStatement(cps, ref exitPoints));
                retConstructor.ExitPoints = exitPoints;
            }

            foreach (LocalDeclarationStatementSyntax vds in accessVarDefs)
            {
                Method tempMethod = TraverseVarDecls(vds);
                retConstructor.AccessedVariables.AddRange(tempMethod.AccessedVariables);
                retConstructor.InvokedMethods.AddRange(tempMethod.InvokedMethods);
            }

            foreach (AssignmentStatementSyntax vns in accessVars)
            {
                Method tempMethod = TraverseAccessVars(vns);

                retConstructor.AccessedVariables.AddRange(tempMethod.AccessedVariables);
                retConstructor.InvokedMethods.AddRange(tempMethod.InvokedMethods);
            }

            foreach (LabelStatementSyntax lss in labelStms)
            {
                retConstructor.LabelStatements.Add(TraverseLabel(lss));
            }

            foreach (GoToStatementSyntax gtss in gotoStms)
            {
                retConstructor.GoToStatements.Add(TraverseGoTo(retConstructor.LabelStatements, gtss));
            }

            foreach (CallStatementSyntax mss in invokedMethods)
            {
                retConstructor.InvokedMethods.Add(TraverseInvokedMethod(mss));
            }

            foreach (InvocationExpressionSyntax ies in invokedMethods2)
            {
                retConstructor.InvokedMethods.Add(TraverseInvokedMethod(ies));
            }

            return retConstructor;
        }
    }
}
