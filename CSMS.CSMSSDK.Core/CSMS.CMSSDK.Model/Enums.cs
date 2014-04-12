/********************************************************************/
/* Author: Jason Pugh											    */
/* Date: © 3/13/2013  												*/
/* Information: The following code is copyrighted. The code cannot  */
/* be distributed without the consent of the author.			    */
/********************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSMS.CSMSSDK.Model
{
    public class Enums
    {
        public enum SourceType
        {
            CSharp = 0,
            Java = 1,
            CPP = 2,
            VB = 3
        };

        public enum Nagivation
        {
            Sources = 0,
            MetricsProperties = 1,
            MetricsView = 2,
            Help = 3,
            About = 4
        };

        public enum CSharpRules
        {
            Identifier = 87,
            FormalParam = 206,
            UsingList = 273,
            UsingDirective = 272,
            QualifiedID = 252,
            ValidID = 274,
            MemberList = 227,
            CompilationItems = 173,
            CompilationItem = 172,
            NamespaceDec = 235,
            AttribOpt = 157,
            NamespaceItems = 273,
            NamespaceItem = 236,
            TypeDecl = 270,
            ClassDecl = 168,
            Header = 209,
            AccessOpt = 146,
            ModifierListOpt = 233,
            ClassBaseOpt = 167,
            ClassItemDecsOpt = 170,
            ClassItem = 169,
            FieldDec = 199,
            Type = 269,
            NonArrayType = 239,
            BaseType = 161,
            OtherType = 244,
            VariableDecs = 276,
            VariableDeclarator = 275,
            VariableInitializer = 277,
            Expression = 196,
            ConditionalExp = 175,
            OrExp = 243,
            AndExp = 149,
            StructDecl = 263,
            EnumBody = 188, 
            EnumItemDec = 190,
            EnumDecl = 189,
            LogicalOrExp = 225,
            LogicalXorExp = 226,
            LogicalAndExp = 224,
            EqualityExp = 193,
            CompareExp = 171,
            ShiftExp = 258,
            AddExp = 148,
            MultExp = 234,
            UnaryExp = 271,
            ObjectExp = 241,
            MethodExp = 230,
            PrimaryExp = 250,
            Primary = 248,
            Literal = 222,
            ConstructorDec = 179,
            ConstructorDeclarator = 189,
            ForamParamListOpt = 208,
            ConstructorInitOpt = 182,
            BlockorSemi = 163,
            Block = 162,
            DelegateDecl = 184,
            PropertyDec = 251,
            IntegralType = 211,
            AccessorDec = 147,
            StmList = 262,
            Statement = 259,
            SemicolonOpt = 257,
            MethodDec = 229,
            MemberName = 97,
            NormalStm = 240,
            LocalVarDecl = 223,
        };
        public enum JavaRules
        {
            PackageDeclaration = 216,
            ClassDeclaration = 139,
            ImportDeclaration = 187,
            EnumDeclaration = 166,
            ClassBodyDeclaration = 136,
            MethodDeclarator = 208,
            MethodBlock = 206,
            SimpleName = 230,
            QualifiedName = 225,
            Name = 213,			//??
            SingleTypeImportDeclaration = 231,
            EnumBody = 162,
            EnumItemDec = 163,
            Type = 249,
            VariableDeclarator = 255,
            VariableDeclaratorId = 256,
            Expression = 170,		//Probably need to add a new item to list when we get this
            Modifier = 211,			//This occured as the only item in the ruleID list when static was used
            FormalParameter = 179,
            Identifier = 76,
            Block = 123,
            MethodBody = 194,
            BlockEnd = 128,
            ClassBody = 136
        };
        public enum CPPRules
        {
            SingleTypeImportDeclaration = 223,
            SemicolonOpt = 100,
            ClosingBracket = 142,
            SimpleName = 222,
            Name = 205,
            PackageDeclaration = 208,
            TypeDeclaration = 249,
            ClassDeclaration = 134,
            Modifier = 203,
            MethodDeclarator = 199,
            MethodDeclaration = 0
        };
    }
}
