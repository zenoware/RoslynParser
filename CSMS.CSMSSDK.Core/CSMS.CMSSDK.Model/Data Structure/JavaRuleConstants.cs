/********************************************************************/
/* Author: Jason Pugh	and Curt Lawson																*/
/* Date: © 05/18/2011  																							*/
/* Information: The following code is copyrighted. The code cannot  */
/* be distributed without the consent of the author.								*/
/********************************************************************/

namespace CSMS.CSMSSDK.Model
{
	/// <summary>
	/// Holds the enum for Java Rule Constants
	/// </summary>
	public static class JavaRules
	{
		/// <summary>
		/// The Java Rule Constants
		/// </summary>
    public enum JavaRuleConstants : int
    {
      RULE_LITERAL_TRUE = 0, // <Literal> ::= true
      RULE_LITERAL_FALSE = 1, // <Literal> ::= false
      RULE_LITERAL_DECLITERAL = 2, // <Literal> ::= DecLiteral
      RULE_LITERAL_HEXLITERAL = 3, // <Literal> ::= HexLiteral
      RULE_LITERAL_CHARLITERAL = 4, // <Literal> ::= CharLiteral
      RULE_LITERAL_HEXESCAPECHARLITERAL = 5, // <Literal> ::= HexEscapeCharLiteral
      RULE_LITERAL_FLOATINGPOINTLITERAL = 6, // <Literal> ::= FloatingPointLiteral
      RULE_LITERAL_FLOATINGPOINTLITERALEXPONENT = 7, // <Literal> ::= FloatingPointLiteralExponent
      RULE_LITERAL_STRINGLITERAL = 8, // <Literal> ::= StringLiteral
      RULE_LITERAL_NULL = 9, // <Literal> ::= null
      RULE_TYPE = 10, // <Type> ::= <PrimitiveType>
      RULE_TYPE2 = 11, // <Type> ::= <ReferenceType>
      RULE_PRIMITIVETYPE = 12, // <PrimitiveType> ::= <NumericType>
      RULE_PRIMITIVETYPE_BOOLEAN = 13, // <PrimitiveType> ::= boolean
      RULE_NUMERICTYPE = 14, // <NumericType> ::= <IntegralType>
      RULE_NUMERICTYPE2 = 15, // <NumericType> ::= <FloatingPointType>
      RULE_INTEGRALTYPE_BYTE = 16, // <IntegralType> ::= byte
      RULE_INTEGRALTYPE_SHORT = 17, // <IntegralType> ::= short
      RULE_INTEGRALTYPE_INT = 18, // <IntegralType> ::= int
      RULE_INTEGRALTYPE_LONG = 19, // <IntegralType> ::= long
      RULE_INTEGRALTYPE_CHAR = 20, // <IntegralType> ::= char
      RULE_FLOATINGPOINTTYPE_FLOAT = 21, // <FloatingPointType> ::= float
      RULE_FLOATINGPOINTTYPE_DOUBLE = 22, // <FloatingPointType> ::= double
      RULE_REFERENCETYPE = 23, // <ReferenceType> ::= <ClassOrInterfaceType>
      RULE_REFERENCETYPE2 = 24, // <ReferenceType> ::= <ArrayType>
      RULE_INTEGRALTYPE_SBYTE = 25, // <Integral Type> ::= sbyte
      RULE_INTEGRALTYPE_BYTE2 = 26, // <Integral Type> ::= byte
      RULE_INTEGRALTYPE_SHORT2 = 27, // <Integral Type> ::= short
      RULE_INTEGRALTYPE_USHORT = 28, // <Integral Type> ::= ushort
      RULE_INTEGRALTYPE_INT2 = 29, // <Integral Type> ::= int
      RULE_INTEGRALTYPE_UINT = 30, // <Integral Type> ::= uint
      RULE_INTEGRALTYPE_LONG2 = 31, // <Integral Type> ::= long
      RULE_INTEGRALTYPE_ULONG = 32, // <Integral Type> ::= ulong
      RULE_INTEGRALTYPE_CHAR2 = 33, // <Integral Type> ::= char
      RULE_CLASSORINTERFACETYPE = 34, // <ClassOrInterfaceType> ::= <Name>
      RULE_CLASSTYPE = 35, // <ClassType> ::= <ClassOrInterfaceType>
      RULE_INTERFACETYPE = 36, // <InterfaceType> ::= <ClassOrInterfaceType>
      RULE_ARRAYTYPE_LBRACKET_RBRACKET = 37, // <ArrayType> ::= <PrimitiveType> '[' ']'
      RULE_ARRAYTYPE_LBRACKET_RBRACKET2 = 38, // <ArrayType> ::= <Name> '[' ']'
      RULE_ARRAYTYPE_LBRACKET_RBRACKET3 = 39, // <ArrayType> ::= <ArrayType> '[' ']'
      RULE_NAME = 40, // <Name> ::= <SimpleName>
      RULE_NAME2 = 41, // <Name> ::= <QualifiedName>
      RULE_SIMPLENAME_IDENTIFIER = 42, // <SimpleName> ::= Identifier
      RULE_QUALIFIEDNAME_DOT_IDENTIFIER = 43, // <QualifiedName> ::= <Name> '.' Identifier
      RULE_QUALIFIEDNAME_DOTCLASS = 44, // <QualifiedName> ::= <Name> '.class'
      RULE_QUALIFIEDNAME_DOTCLASS_IDENTIFIER = 45, // <QualifiedName> ::= <Name> '.class' Identifier
      RULE_PARAMETERIZEDTYPE_LT_GT = 46, // <Parameterized Type> ::= <QualifiedName> '<' <Name> '>'
      RULE_PARAMETERIZEDTYPE_LT_GT2 = 47, // <Parameterized Type> ::= <QualifiedName> '<' <Type> '>'
      RULE_COMPILATIONUNIT = 48, // <CompilationUnit> ::= <PackageDeclaration> <ImportDeclarations> <TypeDeclarations>
      RULE_COMPILATIONUNIT2 = 49, // <CompilationUnit> ::= <PackageDeclaration> <ImportDeclarations>
      RULE_COMPILATIONUNIT3 = 50, // <CompilationUnit> ::= <PackageDeclaration> <TypeDeclarations>
      RULE_COMPILATIONUNIT4 = 51, // <CompilationUnit> ::= <PackageDeclaration>
      RULE_COMPILATIONUNIT5 = 52, // <CompilationUnit> ::= <ImportDeclarations> <TypeDeclarations>
      RULE_COMPILATIONUNIT6 = 53, // <CompilationUnit> ::= <ImportDeclarations>
      RULE_COMPILATIONUNIT7 = 54, // <CompilationUnit> ::= <TypeDeclarations>
      RULE_COMPILATIONUNIT8 = 55, // <CompilationUnit> ::= 
      RULE_IMPORTDECLARATIONS = 56, // <ImportDeclarations> ::= <ImportDeclaration>
      RULE_IMPORTDECLARATIONS2 = 57, // <ImportDeclarations> ::= <ImportDeclarations> <ImportDeclaration>
      RULE_TYPEDECLARATIONS = 58, // <TypeDeclarations> ::= <TypeDeclaration>
      RULE_TYPEDECLARATIONS2 = 59, // <TypeDeclarations> ::= <TypeDeclarations> <TypeDeclaration>
      RULE_PACKAGEDECLARATION_PACKAGE_SEMI = 60, // <PackageDeclaration> ::= package <Name> ';'
      RULE_IMPORTDECLARATION = 61, // <ImportDeclaration> ::= <SingleTypeImportDeclaration>
      RULE_IMPORTDECLARATION2 = 62, // <ImportDeclaration> ::= <TypeImportOnDemandDeclaration>
      RULE_SINGLETYPEIMPORTDECLARATION_IMPORT_SEMI = 63, // <SingleTypeImportDeclaration> ::= import <Name> ';'
      RULE_TYPEIMPORTONDEMANDDECLARATION_IMPORT_DOT_TIMES_SEMI = 64, // <TypeImportOnDemandDeclaration> ::= import <Name> '.' '*' ';'
      RULE_TYPEDECLARATION = 65, // <TypeDeclaration> ::= <ClassDeclaration>
      RULE_TYPEDECLARATION2 = 66, // <TypeDeclaration> ::= <EnumDeclaration>
      RULE_TYPEDECLARATION3 = 67, // <TypeDeclaration> ::= <InterfaceDeclaration>
      RULE_TYPEDECLARATION_SEMI = 68, // <TypeDeclaration> ::= ';'
      RULE_MODIFIERS = 69, // <Modifiers> ::= <Modifier>
      RULE_MODIFIERS2 = 70, // <Modifiers> ::= <Modifiers> <Modifier>
      RULE_MODIFIER_PUBLIC = 71, // <Modifier> ::= public
      RULE_MODIFIER_PROTECTED = 72, // <Modifier> ::= protected
      RULE_MODIFIER_PRIVATE = 73, // <Modifier> ::= private
      RULE_MODIFIER_STATIC = 74, // <Modifier> ::= static
      RULE_MODIFIER_ABSTRACT = 75, // <Modifier> ::= abstract
      RULE_MODIFIER_FINAL = 76, // <Modifier> ::= final
      RULE_MODIFIER_NATIVE = 77, // <Modifier> ::= native
      RULE_MODIFIER_SYNCHRONIZED = 78, // <Modifier> ::= synchronized
      RULE_MODIFIER_TRANSIENT = 79, // <Modifier> ::= transient
      RULE_MODIFIER_VOLATILE = 80, // <Modifier> ::= volatile
      RULE_CLASSDECLARATION_CLASS_IDENTIFIER = 81, // <ClassDeclaration> ::= <Modifiers> class Identifier <Super> <Interfaces> <ClassBody>
      RULE_CLASSDECLARATION_CLASS_IDENTIFIER2 = 82, // <ClassDeclaration> ::= <Modifiers> class Identifier <Super> <ClassBody>
      RULE_CLASSDECLARATION_CLASS_IDENTIFIER3 = 83, // <ClassDeclaration> ::= <Modifiers> class Identifier <Interfaces> <ClassBody>
      RULE_CLASSDECLARATION_CLASS_IDENTIFIER4 = 84, // <ClassDeclaration> ::= <Modifiers> class Identifier <ClassBody>
      RULE_CLASSDECLARATION_CLASS_IDENTIFIER5 = 85, // <ClassDeclaration> ::= class Identifier <Super> <Interfaces> <ClassBody>
      RULE_CLASSDECLARATION_CLASS_IDENTIFIER6 = 86, // <ClassDeclaration> ::= class Identifier <Super> <ClassBody>
      RULE_CLASSDECLARATION_CLASS_IDENTIFIER7 = 87, // <ClassDeclaration> ::= class Identifier <Interfaces> <ClassBody>
      RULE_CLASSDECLARATION_CLASS_IDENTIFIER8 = 88, // <ClassDeclaration> ::= class Identifier <ClassBody>
      RULE_SUPER_EXTENDS = 89, // <Super> ::= extends <ClassType>
      RULE_INTERFACES_IMPLEMENTS = 90, // <Interfaces> ::= implements <InterfaceTypeList>
      RULE_INTERFACETYPELIST = 91, // <InterfaceTypeList> ::= <InterfaceType>
      RULE_INTERFACETYPELIST_COMMA = 92, // <InterfaceTypeList> ::= <InterfaceTypeList> ',' <InterfaceType>
      RULE_CLASSBODY_LBRACE_RBRACE = 93, // <ClassBody> ::= '{' <ClassBodyDeclarations> '}'
      RULE_CLASSBODY_LBRACE_RBRACE2 = 94, // <ClassBody> ::= '{' '}'
      RULE_CLASSBODYDECLARATIONS = 95, // <ClassBodyDeclarations> ::= <ClassBodyDeclaration>
      RULE_CLASSBODYDECLARATIONS2 = 96, // <ClassBodyDeclarations> ::= <ClassBodyDeclarations> <ClassBodyDeclaration>
      RULE_CLASSBODYDECLARATION = 97, // <ClassBodyDeclaration> ::= <ClassMemberDeclaration>
      RULE_CLASSBODYDECLARATION2 = 98, // <ClassBodyDeclaration> ::= <StaticInitializer>
      RULE_CLASSBODYDECLARATION3 = 99, // <ClassBodyDeclaration> ::= <ConstructorDeclaration>
      RULE_CLASSBODYDECLARATION4 = 100, // <ClassBodyDeclaration> ::= <EnumDeclaration>
      RULE_CLASSBODYDECLARATION5 = 101, // <ClassBodyDeclaration> ::= <ClassDeclaration>
      RULE_CLASSMEMBERDECLARATION = 102, // <ClassMemberDeclaration> ::= <FieldDeclaration>
      RULE_CLASSMEMBERDECLARATION2 = 103, // <ClassMemberDeclaration> ::= <MethodDeclaration>
      RULE_FIELDDECLARATION_SEMI = 104, // <FieldDeclaration> ::= <Modifiers> <Type> <VariableDeclarators> ';'
      RULE_FIELDDECLARATION_SEMI2 = 105, // <FieldDeclaration> ::= <Type> <VariableDeclarators> ';'
      RULE_VARIABLEDECLARATORS = 106, // <VariableDeclarators> ::= <VariableDeclarator>
      RULE_VARIABLEDECLARATORS_COMMA = 107, // <VariableDeclarators> ::= <VariableDeclarators> ',' <VariableDeclarator>
      RULE_VARIABLEDECLARATOR = 108, // <VariableDeclarator> ::= <VariableDeclaratorId>
      RULE_VARIABLEDECLARATOR_EQ = 109, // <VariableDeclarator> ::= <VariableDeclaratorId> '=' <VariableInitializer>
      RULE_VARIABLEDECLARATORID_IDENTIFIER = 110, // <VariableDeclaratorId> ::= Identifier
      RULE_VARIABLEDECLARATORID_LBRACKET_RBRACKET = 111, // <VariableDeclaratorId> ::= <VariableDeclaratorId> '[' ']'
      RULE_VARIABLEINITIALIZER = 112, // <VariableInitializer> ::= <Expression>
      RULE_VARIABLEINITIALIZER2 = 113, // <VariableInitializer> ::= <ArrayInitializer>
      RULE_METHODDECLARATION = 114, // <MethodDeclaration> ::= <MethodHeader> <MethodBody>
      RULE_METHODHEADER = 115, // <MethodHeader> ::= <Modifiers> <Type> <MethodDeclarator> <Throws>
      RULE_METHODHEADER2 = 116, // <MethodHeader> ::= <Modifiers> <Type> <MethodDeclarator>
      RULE_METHODHEADER3 = 117, // <MethodHeader> ::= <Type> <MethodDeclarator> <Throws>
      RULE_METHODHEADER4 = 118, // <MethodHeader> ::= <Type> <MethodDeclarator>
      RULE_METHODHEADER_VOID = 119, // <MethodHeader> ::= <Modifiers> void <MethodDeclarator> <Throws>
      RULE_METHODHEADER_VOID2 = 120, // <MethodHeader> ::= <Modifiers> void <MethodDeclarator>
      RULE_METHODHEADER_VOID3 = 121, // <MethodHeader> ::= void <MethodDeclarator> <Throws>
      RULE_METHODHEADER_VOID4 = 122, // <MethodHeader> ::= void <MethodDeclarator>
      RULE_METHODDECLARATOR_IDENTIFIER_LPARAN_RPARAN = 123, // <MethodDeclarator> ::= Identifier '(' <FormalParameterList> ')'
      RULE_METHODDECLARATOR_IDENTIFIER_LPARAN_RPARAN2 = 124, // <MethodDeclarator> ::= Identifier '(' ')'
      RULE_METHODDECLARATOR_LBRACKET_RBRACKET = 125, // <MethodDeclarator> ::= <MethodDeclarator> '[' ']'
      RULE_FORMALPARAMETERLIST = 126, // <FormalParameterList> ::= <FormalParameter>
      RULE_FORMALPARAMETERLIST_COMMA = 127, // <FormalParameterList> ::= <FormalParameterList> ',' <FormalParameter>
      RULE_FORMALPARAMETER = 128, // <FormalParameter> ::= <Type> <VariableDeclaratorId>
      RULE_THROWS_THROWS = 129, // <Throws> ::= throws <ClassTypeList>
      RULE_CLASSTYPELIST = 130, // <ClassTypeList> ::= <ClassType>
      RULE_CLASSTYPELIST_COMMA = 131, // <ClassTypeList> ::= <ClassTypeList> ',' <ClassType>
      RULE_METHODBODY = 132, // <MethodBody> ::= <Block>
      RULE_METHODBODY_SEMI = 133, // <MethodBody> ::= ';'
      RULE_STATICINITIALIZER_STATIC = 134, // <StaticInitializer> ::= static <Block>
      RULE_CONSTRUCTORDECLARATION = 135, // <ConstructorDeclaration> ::= <Modifiers> <ConstructorDeclarator> <Throws> <ConstructorBody>
      RULE_CONSTRUCTORDECLARATION2 = 136, // <ConstructorDeclaration> ::= <Modifiers> <ConstructorDeclarator> <ConstructorBody>
      RULE_CONSTRUCTORDECLARATION3 = 137, // <ConstructorDeclaration> ::= <ConstructorDeclarator> <Throws> <ConstructorBody>
      RULE_CONSTRUCTORDECLARATION4 = 138, // <ConstructorDeclaration> ::= <ConstructorDeclarator> <ConstructorBody>
      RULE_CONSTRUCTORDECLARATOR_LPARAN_RPARAN = 139, // <ConstructorDeclarator> ::= <SimpleName> '(' <FormalParameterList> ')'
      RULE_CONSTRUCTORDECLARATOR_LPARAN_RPARAN2 = 140, // <ConstructorDeclarator> ::= <SimpleName> '(' ')'
      RULE_CONSTRUCTORBODY_LBRACE_RBRACE = 141, // <ConstructorBody> ::= '{' <ExplicitConstructorInvocation> <BlockStatements> '}'
      RULE_CONSTRUCTORBODY_LBRACE_RBRACE2 = 142, // <ConstructorBody> ::= '{' <ExplicitConstructorInvocation> '}'
      RULE_CONSTRUCTORBODY_LBRACE_RBRACE3 = 143, // <ConstructorBody> ::= '{' <BlockStatements> '}'
      RULE_CONSTRUCTORBODY_LBRACE_RBRACE4 = 144, // <ConstructorBody> ::= '{' '}'
      RULE_EXPLICITCONSTRUCTORINVOCATION_THIS_LPARAN_RPARAN_SEMI = 145, // <ExplicitConstructorInvocation> ::= this '(' <ArgumentList> ')' ';'
      RULE_EXPLICITCONSTRUCTORINVOCATION_THIS_LPARAN_RPARAN_SEMI2 = 146, // <ExplicitConstructorInvocation> ::= this '(' ')' ';'
      RULE_EXPLICITCONSTRUCTORINVOCATION_SUPER_LPARAN_RPARAN_SEMI = 147, // <ExplicitConstructorInvocation> ::= super '(' <ArgumentList> ')' ';'
      RULE_EXPLICITCONSTRUCTORINVOCATION_SUPER_LPARAN_RPARAN_SEMI2 = 148, // <ExplicitConstructorInvocation> ::= super '(' ')' ';'
      RULE_ENUMDECLARATION_ENUM_IDENTIFIER = 149, // <EnumDeclaration> ::= <Modifiers> enum Identifier <Enum Base Opt> <Enum Body>
      RULE_ENUMDECLARATION_ENUM_IDENTIFIER2 = 150, // <EnumDeclaration> ::= enum Identifier <Enum Base Opt> <Enum Body>
      RULE_ENUMBASEOPT = 151, // <Enum Base Opt> ::= <Integral Type>
      RULE_ENUMBASEOPT2 = 152, // <Enum Base Opt> ::= 
      RULE_ENUMBODY_LBRACE_RBRACE = 153, // <Enum Body> ::= '{' <Enum Item Decs> '}'
      RULE_ENUMBODY_LBRACE_COMMA_RBRACE = 154, // <Enum Body> ::= '{' <Enum Item Decs> ',' '}'
      RULE_ENUMITEMDECSOPT = 155, // <Enum Item Decs Opt> ::= <Enum Item Decs>
      RULE_ENUMITEMDECSOPT2 = 156, // <Enum Item Decs Opt> ::= <ConstructorDeclaration>
      RULE_ENUMITEMDECSOPT3 = 157, // <Enum Item Decs Opt> ::= 
      RULE_ENUMITEMDECS = 158, // <Enum Item Decs> ::= <Enum Item Dec>
      RULE_ENUMITEMDECS_COMMA = 159, // <Enum Item Decs> ::= <Enum Item Decs> ',' <Enum Item Dec>
      RULE_ENUMITEMDECS2 = 160, // <Enum Item Decs> ::= 
      RULE_ENUMITEMDEC_IDENTIFIER = 161, // <Enum Item Dec> ::= Identifier
      RULE_ENUMITEMDEC_IDENTIFIER_EQ = 162, // <Enum Item Dec> ::= Identifier '=' <Statement>
      RULE_INTERFACEDECLARATION_INTERFACE_IDENTIFIER = 163, // <InterfaceDeclaration> ::= <Modifiers> interface Identifier <ExtendsInterfaces> <InterfaceBody>
      RULE_INTERFACEDECLARATION_INTERFACE_IDENTIFIER2 = 164, // <InterfaceDeclaration> ::= <Modifiers> interface Identifier <InterfaceBody>
      RULE_INTERFACEDECLARATION_INTERFACE_IDENTIFIER3 = 165, // <InterfaceDeclaration> ::= interface Identifier <ExtendsInterfaces> <InterfaceBody>
      RULE_INTERFACEDECLARATION_INTERFACE_IDENTIFIER4 = 166, // <InterfaceDeclaration> ::= interface Identifier <InterfaceBody>
      RULE_EXTENDSINTERFACES_EXTENDS = 167, // <ExtendsInterfaces> ::= extends <InterfaceType>
      RULE_EXTENDSINTERFACES_COMMA = 168, // <ExtendsInterfaces> ::= <ExtendsInterfaces> ',' <InterfaceType>
      RULE_INTERFACEBODY_LBRACE_RBRACE = 169, // <InterfaceBody> ::= '{' <InterfaceMemberDeclarations> '}'
      RULE_INTERFACEBODY_LBRACE_RBRACE2 = 170, // <InterfaceBody> ::= '{' '}'
      RULE_INTERFACEMEMBERDECLARATIONS = 171, // <InterfaceMemberDeclarations> ::= <InterfaceMemberDeclaration>
      RULE_INTERFACEMEMBERDECLARATIONS2 = 172, // <InterfaceMemberDeclarations> ::= <InterfaceMemberDeclarations> <InterfaceMemberDeclaration>
      RULE_INTERFACEMEMBERDECLARATION = 173, // <InterfaceMemberDeclaration> ::= <ConstantDeclaration>
      RULE_INTERFACEMEMBERDECLARATION2 = 174, // <InterfaceMemberDeclaration> ::= <AbstractMethodDeclaration>
      RULE_CONSTANTDECLARATION = 175, // <ConstantDeclaration> ::= <FieldDeclaration>
      RULE_ABSTRACTMETHODDECLARATION_SEMI = 176, // <AbstractMethodDeclaration> ::= <MethodHeader> ';'
      RULE_ARRAYINITIALIZER_LBRACE_COMMA_RBRACE = 177, // <ArrayInitializer> ::= '{' <VariableInitializers> ',' '}'
      RULE_ARRAYINITIALIZER_LBRACE_RBRACE = 178, // <ArrayInitializer> ::= '{' <VariableInitializers> '}'
      RULE_ARRAYINITIALIZER_LBRACE_COMMA_RBRACE2 = 179, // <ArrayInitializer> ::= '{' ',' '}'
      RULE_ARRAYINITIALIZER_LBRACE_RBRACE2 = 180, // <ArrayInitializer> ::= '{' '}'
      RULE_VARIABLEINITIALIZERS = 181, // <VariableInitializers> ::= <VariableInitializer>
      RULE_VARIABLEINITIALIZERS_COMMA = 182, // <VariableInitializers> ::= <VariableInitializers> ',' <VariableInitializer>
      RULE_BLOCK_LBRACE_RBRACE = 183, // <Block> ::= '{' <BlockStatements> '}'
      RULE_BLOCK_LBRACE_RBRACE2 = 184, // <Block> ::= '{' '}'
      RULE_BLOCKSTATEMENTS = 185, // <BlockStatements> ::= <BlockStatement>
      RULE_BLOCKSTATEMENTS2 = 186, // <BlockStatements> ::= <BlockStatements> <BlockStatement>
      RULE_BLOCKSTATEMENT = 187, // <BlockStatement> ::= <LocalVariableDeclarationStatement>
      RULE_BLOCKSTATEMENT2 = 188, // <BlockStatement> ::= <Statement>
      RULE_LOCALVARIABLEDECLARATIONSTATEMENT_SEMI = 189, // <LocalVariableDeclarationStatement> ::= <LocalVariableDeclaration> ';'
      RULE_LOCALVARIABLEDECLARATION = 190, // <LocalVariableDeclaration> ::= <Type> <VariableDeclarators>
      RULE_LOCALVARIABLEDECLARATION_FINAL = 191, // <LocalVariableDeclaration> ::= final <Type> <VariableDeclarators>
      RULE_STATEMENT = 192, // <Statement> ::= <StatementWithoutTrailingSubstatement>
      RULE_STATEMENT2 = 193, // <Statement> ::= <LabeledStatement>
      RULE_STATEMENT3 = 194, // <Statement> ::= <IfThenStatement>
      RULE_STATEMENT4 = 195, // <Statement> ::= <IfThenElseStatement>
      RULE_STATEMENT5 = 196, // <Statement> ::= <WhileStatement>
      RULE_STATEMENT6 = 197, // <Statement> ::= <ForStatement>
      RULE_STATEMENTNOSHORTIF = 198, // <StatementNoShortIf> ::= <StatementWithoutTrailingSubstatement>
      RULE_STATEMENTNOSHORTIF2 = 199, // <StatementNoShortIf> ::= <LabeledStatementNoShortIf>
      RULE_STATEMENTNOSHORTIF3 = 200, // <StatementNoShortIf> ::= <IfThenElseStatementNoShortIf>
      RULE_STATEMENTNOSHORTIF4 = 201, // <StatementNoShortIf> ::= <WhileStatementNoShortIf>
      RULE_STATEMENTNOSHORTIF5 = 202, // <StatementNoShortIf> ::= <ForStatementNoShortIf>
      RULE_STATEMENTWITHOUTTRAILINGSUBSTATEMENT = 203, // <StatementWithoutTrailingSubstatement> ::= <Block>
      RULE_STATEMENTWITHOUTTRAILINGSUBSTATEMENT2 = 204, // <StatementWithoutTrailingSubstatement> ::= <EmptyStatement>
      RULE_STATEMENTWITHOUTTRAILINGSUBSTATEMENT3 = 205, // <StatementWithoutTrailingSubstatement> ::= <ExpressionStatement>
      RULE_STATEMENTWITHOUTTRAILINGSUBSTATEMENT4 = 206, // <StatementWithoutTrailingSubstatement> ::= <SwitchStatement>
      RULE_STATEMENTWITHOUTTRAILINGSUBSTATEMENT5 = 207, // <StatementWithoutTrailingSubstatement> ::= <DoStatement>
      RULE_STATEMENTWITHOUTTRAILINGSUBSTATEMENT6 = 208, // <StatementWithoutTrailingSubstatement> ::= <BreakStatement>
      RULE_STATEMENTWITHOUTTRAILINGSUBSTATEMENT7 = 209, // <StatementWithoutTrailingSubstatement> ::= <ContinueStatement>
      RULE_STATEMENTWITHOUTTRAILINGSUBSTATEMENT8 = 210, // <StatementWithoutTrailingSubstatement> ::= <ReturnStatement>
      RULE_STATEMENTWITHOUTTRAILINGSUBSTATEMENT9 = 211, // <StatementWithoutTrailingSubstatement> ::= <SynchronizedStatement>
      RULE_STATEMENTWITHOUTTRAILINGSUBSTATEMENT10 = 212, // <StatementWithoutTrailingSubstatement> ::= <ThrowStatement>
      RULE_STATEMENTWITHOUTTRAILINGSUBSTATEMENT11 = 213, // <StatementWithoutTrailingSubstatement> ::= <TryStatement>
      RULE_EMPTYSTATEMENT_SEMI = 214, // <EmptyStatement> ::= ';'
      RULE_LABELEDSTATEMENT_IDENTIFIER_COLON = 215, // <LabeledStatement> ::= Identifier ':' <Statement>
      RULE_LABELEDSTATEMENTNOSHORTIF_IDENTIFIER_COLON = 216, // <LabeledStatementNoShortIf> ::= Identifier ':' <StatementNoShortIf>
      RULE_EXPRESSIONSTATEMENT_SEMI = 217, // <ExpressionStatement> ::= <Expression> ';'
      RULE_IFTHENSTATEMENT_IF_LPARAN_RPARAN = 218, // <IfThenStatement> ::= if '(' <Expression> ')' <Statement>
      RULE_IFTHENELSESTATEMENT_IF_LPARAN_RPARAN_ELSE = 219, // <IfThenElseStatement> ::= if '(' <Expression> ')' <StatementNoShortIf> else <Statement>
      RULE_IFTHENELSESTATEMENTNOSHORTIF_IF_LPARAN_RPARAN_ELSE = 220, // <IfThenElseStatementNoShortIf> ::= if '(' <Expression> ')' <StatementNoShortIf> else <StatementNoShortIf>
      RULE_SWITCHSTATEMENT_SWITCH_LPARAN_RPARAN = 221, // <SwitchStatement> ::= switch '(' <Expression> ')' <SwitchBlock>
      RULE_SWITCHBLOCK_LBRACE_RBRACE = 222, // <SwitchBlock> ::= '{' <SwitchBlockStatementGroups> <SwitchLabels> '}'
      RULE_SWITCHBLOCK_LBRACE_RBRACE2 = 223, // <SwitchBlock> ::= '{' <SwitchBlockStatementGroups> '}'
      RULE_SWITCHBLOCK_LBRACE_RBRACE3 = 224, // <SwitchBlock> ::= '{' <SwitchLabels> '}'
      RULE_SWITCHBLOCK_LBRACE_RBRACE4 = 225, // <SwitchBlock> ::= '{' '}'
      RULE_SWITCHBLOCKSTATEMENTGROUPS = 226, // <SwitchBlockStatementGroups> ::= <SwitchBlockStatementGroup>
      RULE_SWITCHBLOCKSTATEMENTGROUPS2 = 227, // <SwitchBlockStatementGroups> ::= <SwitchBlockStatementGroups> <SwitchBlockStatementGroup>
      RULE_SWITCHBLOCKSTATEMENTGROUP = 228, // <SwitchBlockStatementGroup> ::= <SwitchLabels> <BlockStatements>
      RULE_SWITCHLABELS = 229, // <SwitchLabels> ::= <SwitchLabel>
      RULE_SWITCHLABELS2 = 230, // <SwitchLabels> ::= <SwitchLabels> <SwitchLabel>
      RULE_SWITCHLABEL_CASE_COLON = 231, // <SwitchLabel> ::= case <ConstantExpression> ':'
      RULE_SWITCHLABEL_DEFAULT_COLON = 232, // <SwitchLabel> ::= default ':'
      RULE_WHILESTATEMENT_WHILE_LPARAN_RPARAN = 233, // <WhileStatement> ::= while '(' <Expression> ')' <Statement>
      RULE_WHILESTATEMENTNOSHORTIF_WHILE_LPARAN_RPARAN = 234, // <WhileStatementNoShortIf> ::= while '(' <Expression> ')' <StatementNoShortIf>
      RULE_DOSTATEMENT_DO_WHILE_LPARAN_RPARAN_SEMI = 235, // <DoStatement> ::= do <Statement> while '(' <Expression> ')' ';'
      RULE_FORSTATEMENT_FOR_LPARAN_SEMI_SEMI_RPARAN = 236, // <ForStatement> ::= for '(' <ForInit> ';' <Expression> ';' <ForUpdate> ')' <Statement>
      RULE_FORSTATEMENT_FOR_LPARAN_SEMI_SEMI_RPARAN2 = 237, // <ForStatement> ::= for '(' <ForInit> ';' <Expression> ';' ')' <Statement>
      RULE_FORSTATEMENT_FOR_LPARAN_SEMI_SEMI_RPARAN3 = 238, // <ForStatement> ::= for '(' <ForInit> ';' ';' <ForUpdate> ')' <Statement>
      RULE_FORSTATEMENT_FOR_LPARAN_SEMI_SEMI_RPARAN4 = 239, // <ForStatement> ::= for '(' <ForInit> ';' ';' ')' <Statement>
      RULE_FORSTATEMENT_FOR_LPARAN_SEMI_SEMI_RPARAN5 = 240, // <ForStatement> ::= for '(' ';' <Expression> ';' <ForUpdate> ')' <Statement>
      RULE_FORSTATEMENT_FOR_LPARAN_SEMI_SEMI_RPARAN6 = 241, // <ForStatement> ::= for '(' ';' <Expression> ';' ')' <Statement>
      RULE_FORSTATEMENT_FOR_LPARAN_SEMI_SEMI_RPARAN7 = 242, // <ForStatement> ::= for '(' ';' ';' <ForUpdate> ')' <Statement>
      RULE_FORSTATEMENT_FOR_LPARAN_SEMI_SEMI_RPARAN8 = 243, // <ForStatement> ::= for '(' ';' ';' ')' <Statement>
      RULE_FORSTATEMENTNOSHORTIF_FOR_LPARAN_SEMI_SEMI_RPARAN = 244, // <ForStatementNoShortIf> ::= for '(' <ForInit> ';' <Expression> ';' <ForUpdate> ')' <StatementNoShortIf>
      RULE_FORSTATEMENTNOSHORTIF_FOR_LPARAN_SEMI_SEMI_RPARAN2 = 245, // <ForStatementNoShortIf> ::= for '(' <ForInit> ';' <Expression> ';' ')' <StatementNoShortIf>
      RULE_FORSTATEMENTNOSHORTIF_FOR_LPARAN_SEMI_SEMI_RPARAN3 = 246, // <ForStatementNoShortIf> ::= for '(' <ForInit> ';' ';' <ForUpdate> ')' <StatementNoShortIf>
      RULE_FORSTATEMENTNOSHORTIF_FOR_LPARAN_SEMI_SEMI_RPARAN4 = 247, // <ForStatementNoShortIf> ::= for '(' <ForInit> ';' ';' ')' <StatementNoShortIf>
      RULE_FORSTATEMENTNOSHORTIF_FOR_LPARAN_SEMI_SEMI_RPARAN5 = 248, // <ForStatementNoShortIf> ::= for '(' ';' <Expression> ';' <ForUpdate> ')' <StatementNoShortIf>
      RULE_FORSTATEMENTNOSHORTIF_FOR_LPARAN_SEMI_SEMI_RPARAN6 = 249, // <ForStatementNoShortIf> ::= for '(' ';' <Expression> ';' ')' <StatementNoShortIf>
      RULE_FORSTATEMENTNOSHORTIF_FOR_LPARAN_SEMI_SEMI_RPARAN7 = 250, // <ForStatementNoShortIf> ::= for '(' ';' ';' <ForUpdate> ')' <StatementNoShortIf>
      RULE_FORSTATEMENTNOSHORTIF_FOR_LPARAN_SEMI_SEMI_RPARAN8 = 251, // <ForStatementNoShortIf> ::= for '(' ';' ';' ')' <StatementNoShortIf>
      RULE_FORINIT = 252, // <ForInit> ::= <StatementExpressionList>
      RULE_FORINIT2 = 253, // <ForInit> ::= <LocalVariableDeclaration>
      RULE_FORUPDATE = 254, // <ForUpdate> ::= <StatementExpressionList>
      RULE_STATEMENTEXPRESSIONLIST = 255, // <StatementExpressionList> ::= <Expression>
      RULE_STATEMENTEXPRESSIONLIST_COMMA = 256, // <StatementExpressionList> ::= <StatementExpressionList> ',' <Expression>
      RULE_BREAKSTATEMENT_BREAK_IDENTIFIER_SEMI = 257, // <BreakStatement> ::= break Identifier ';'
      RULE_BREAKSTATEMENT_BREAK_SEMI = 258, // <BreakStatement> ::= break ';'
      RULE_CONTINUESTATEMENT_CONTINUE_IDENTIFIER_SEMI = 259, // <ContinueStatement> ::= continue Identifier ';'
      RULE_CONTINUESTATEMENT_CONTINUE_SEMI = 260, // <ContinueStatement> ::= continue ';'
      RULE_RETURNSTATEMENT_RETURN_SEMI = 261, // <ReturnStatement> ::= return <Expression> ';'
      RULE_RETURNSTATEMENT_RETURN_SEMI2 = 262, // <ReturnStatement> ::= return ';'
      RULE_THROWSTATEMENT_THROW_SEMI = 263, // <ThrowStatement> ::= throw <Expression> ';'
      RULE_SYNCHRONIZEDSTATEMENT_SYNCHRONIZED_LPARAN_RPARAN = 264, // <SynchronizedStatement> ::= synchronized '(' <Expression> ')' <Block>
      RULE_TRYSTATEMENT_TRY = 265, // <TryStatement> ::= try <Block> <Catches>
      RULE_TRYSTATEMENT_TRY2 = 266, // <TryStatement> ::= try <Block> <Catches> <Finally>
      RULE_TRYSTATEMENT_TRY3 = 267, // <TryStatement> ::= try <Block> <Finally>
      RULE_CATCHES = 268, // <Catches> ::= <CatchClause>
      RULE_CATCHES2 = 269, // <Catches> ::= <Catches> <CatchClause>
      RULE_CATCHCLAUSE_CATCH_LPARAN_RPARAN = 270, // <CatchClause> ::= catch '(' <FormalParameter> ')' <Block>
      RULE_FINALLY_FINALLY = 271, // <Finally> ::= finally <Block>
      RULE_PRIMARY = 272, // <Primary> ::= <PrimaryNoNewArray>
      RULE_PRIMARY2 = 273, // <Primary> ::= <ArrayCreationExpression>
      RULE_PRIMARYNONEWARRAY = 274, // <PrimaryNoNewArray> ::= <Literal>
      RULE_PRIMARYNONEWARRAY_THIS = 275, // <PrimaryNoNewArray> ::= this
      RULE_PRIMARYNONEWARRAY_LPARAN_RPARAN = 276, // <PrimaryNoNewArray> ::= '(' <Expression> ')'
      RULE_PRIMARYNONEWARRAY2 = 277, // <PrimaryNoNewArray> ::= <ClassInstanceCreationExpression>
      RULE_PRIMARYNONEWARRAY3 = 278, // <PrimaryNoNewArray> ::= <MethodInvocation>
      RULE_PRIMARYNONEWARRAY4 = 279, // <PrimaryNoNewArray> ::= <FieldAccess>
      RULE_PRIMARYNONEWARRAY5 = 280, // <PrimaryNoNewArray> ::= <ArrayAccess>
      RULE_CLASSINSTANCECREATIONEXPRESSION_NEW_LPARAN_RPARAN = 281, // <ClassInstanceCreationExpression> ::= new <ClassType> '(' <ArgumentList> ')'
      RULE_CLASSINSTANCECREATIONEXPRESSION_NEW_LPARAN_RPARAN2 = 282, // <ClassInstanceCreationExpression> ::= new <ClassType> '(' ')'
      RULE_ARGUMENTLIST = 283, // <ArgumentList> ::= <Expression>
      RULE_ARGUMENTLIST_COMMA = 284, // <ArgumentList> ::= <ArgumentList> ',' <Expression>
      RULE_ARRAYCREATIONEXPRESSION_NEW = 285, // <ArrayCreationExpression> ::= new <PrimitiveType> <DimExprs> <Dims>
      RULE_ARRAYCREATIONEXPRESSION_NEW2 = 286, // <ArrayCreationExpression> ::= new <PrimitiveType> <DimExprs>
      RULE_ARRAYCREATIONEXPRESSION_NEW3 = 287, // <ArrayCreationExpression> ::= new <ClassOrInterfaceType> <DimExprs> <Dims>
      RULE_ARRAYCREATIONEXPRESSION_NEW4 = 288, // <ArrayCreationExpression> ::= new <ClassOrInterfaceType> <DimExprs>
      RULE_DIMEXPRS = 289, // <DimExprs> ::= <DimExpr>
      RULE_DIMEXPRS2 = 290, // <DimExprs> ::= <DimExprs> <DimExpr>
      RULE_DIMEXPR_LBRACKET_RBRACKET = 291, // <DimExpr> ::= '[' <Expression> ']'
      RULE_DIMS_LBRACKET_RBRACKET = 292, // <Dims> ::= '[' ']'
      RULE_DIMS_LBRACKET_RBRACKET2 = 293, // <Dims> ::= <Dims> '[' ']'
      RULE_FIELDACCESS_DOT_IDENTIFIER = 294, // <FieldAccess> ::= <Primary> '.' Identifier
      RULE_FIELDACCESS_SUPER_DOT_IDENTIFIER = 295, // <FieldAccess> ::= super '.' Identifier
      RULE_METHODINVOCATION_LPARAN_RPARAN = 296, // <MethodInvocation> ::= <Name> '(' <ArgumentList> ')'
      RULE_METHODINVOCATION_LPARAN_RPARAN2 = 297, // <MethodInvocation> ::= <Name> '(' ')'
      RULE_METHODINVOCATION_DOT_IDENTIFIER_LPARAN_RPARAN = 298, // <MethodInvocation> ::= <Primary> '.' Identifier '(' <ArgumentList> ')'
      RULE_METHODINVOCATION_DOT_IDENTIFIER_LPARAN_RPARAN2 = 299, // <MethodInvocation> ::= <Primary> '.' Identifier '(' ')'
      RULE_METHODINVOCATION_SUPER_DOT_IDENTIFIER_LPARAN_RPARAN = 300, // <MethodInvocation> ::= super '.' Identifier '(' <ArgumentList> ')'
      RULE_METHODINVOCATION_SUPER_DOT_IDENTIFIER_LPARAN_RPARAN2 = 301, // <MethodInvocation> ::= super '.' Identifier '(' ')'
      RULE_ARRAYACCESS_LBRACKET_RBRACKET = 302, // <ArrayAccess> ::= <Name> '[' <Expression> ']'
      RULE_ARRAYACCESS_LBRACKET_RBRACKET2 = 303, // <ArrayAccess> ::= <PrimaryNoNewArray> '[' <Expression> ']'
      RULE_POSTFIXEXPRESSION = 304, // <PostfixExpression> ::= <Primary>
      RULE_POSTFIXEXPRESSION2 = 305, // <PostfixExpression> ::= <Name>
      RULE_POSTFIXEXPRESSION3 = 306, // <PostfixExpression> ::= <PostIncrementExpression>
      RULE_POSTFIXEXPRESSION4 = 307, // <PostfixExpression> ::= <PostDecrementExpression>
      RULE_POSTINCREMENTEXPRESSION_PLUSPLUS = 308, // <PostIncrementExpression> ::= <PostfixExpression> '++'
      RULE_POSTDECREMENTEXPRESSION_MINUSMINUS = 309, // <PostDecrementExpression> ::= <PostfixExpression> '--'
      RULE_UNARYEXPRESSION = 310, // <UnaryExpression> ::= <PreIncrementExpression>
      RULE_UNARYEXPRESSION2 = 311, // <UnaryExpression> ::= <PreDecrementExpression>
      RULE_UNARYEXPRESSION_PLUS = 312, // <UnaryExpression> ::= '+' <UnaryExpression>
      RULE_UNARYEXPRESSION_MINUS = 313, // <UnaryExpression> ::= '-' <UnaryExpression>
      RULE_UNARYEXPRESSION3 = 314, // <UnaryExpression> ::= <UnaryExpressionNotPlusMinus>
      RULE_PREINCREMENTEXPRESSION_PLUSPLUS = 315, // <PreIncrementExpression> ::= '++' <UnaryExpression>
      RULE_PREDECREMENTEXPRESSION_MINUSMINUS = 316, // <PreDecrementExpression> ::= '--' <UnaryExpression>
      RULE_UNARYEXPRESSIONNOTPLUSMINUS = 317, // <UnaryExpressionNotPlusMinus> ::= <PostfixExpression>
      RULE_UNARYEXPRESSIONNOTPLUSMINUS_TILDE = 318, // <UnaryExpressionNotPlusMinus> ::= '~' <UnaryExpression>
      RULE_UNARYEXPRESSIONNOTPLUSMINUS_EXCLAM = 319, // <UnaryExpressionNotPlusMinus> ::= '!' <UnaryExpression>
      RULE_UNARYEXPRESSIONNOTPLUSMINUS2 = 320, // <UnaryExpressionNotPlusMinus> ::= <CastExpression>
      RULE_CASTEXPRESSION_LPARAN_RPARAN = 321, // <CastExpression> ::= '(' <PrimitiveType> <Dims> ')' <UnaryExpression>
      RULE_CASTEXPRESSION_LPARAN_RPARAN2 = 322, // <CastExpression> ::= '(' <PrimitiveType> ')' <UnaryExpression>
      RULE_CASTEXPRESSION_LPARAN_RPARAN3 = 323, // <CastExpression> ::= '(' <Expression> ')' <UnaryExpressionNotPlusMinus>
      RULE_CASTEXPRESSION_LPARAN_RPARAN4 = 324, // <CastExpression> ::= '(' <Name> <Dims> ')' <UnaryExpressionNotPlusMinus>
      RULE_MULTIPLICATIVEEXPRESSION = 325, // <MultiplicativeExpression> ::= <UnaryExpression>
      RULE_MULTIPLICATIVEEXPRESSION_TIMES = 326, // <MultiplicativeExpression> ::= <MultiplicativeExpression> '*' <UnaryExpression>
      RULE_MULTIPLICATIVEEXPRESSION_DIV = 327, // <MultiplicativeExpression> ::= <MultiplicativeExpression> '/' <UnaryExpression>
      RULE_MULTIPLICATIVEEXPRESSION_PERCENT = 328, // <MultiplicativeExpression> ::= <MultiplicativeExpression> '%' <UnaryExpression>
      RULE_ADDITIVEEXPRESSION = 329, // <AdditiveExpression> ::= <MultiplicativeExpression>
      RULE_ADDITIVEEXPRESSION_PLUS = 330, // <AdditiveExpression> ::= <AdditiveExpression> '+' <MultiplicativeExpression>
      RULE_ADDITIVEEXPRESSION_MINUS = 331, // <AdditiveExpression> ::= <AdditiveExpression> '-' <MultiplicativeExpression>
      RULE_SHIFTEXPRESSION = 332, // <ShiftExpression> ::= <AdditiveExpression>
      RULE_SHIFTEXPRESSION_LTLT = 333, // <ShiftExpression> ::= <ShiftExpression> '<<' <AdditiveExpression>
      RULE_SHIFTEXPRESSION_GTGT = 334, // <ShiftExpression> ::= <ShiftExpression> '>>' <AdditiveExpression>
      RULE_SHIFTEXPRESSION_GTGTGT = 335, // <ShiftExpression> ::= <ShiftExpression> '>>>' <AdditiveExpression>
      RULE_RELATIONALEXPRESSION = 336, // <RelationalExpression> ::= <ShiftExpression>
      RULE_RELATIONALEXPRESSION_LT = 337, // <RelationalExpression> ::= <RelationalExpression> '<' <ShiftExpression>
      RULE_RELATIONALEXPRESSION_GT = 338, // <RelationalExpression> ::= <RelationalExpression> '>' <ShiftExpression>
      RULE_RELATIONALEXPRESSION_LTEQ = 339, // <RelationalExpression> ::= <RelationalExpression> '<=' <ShiftExpression>
      RULE_RELATIONALEXPRESSION_GTEQ = 340, // <RelationalExpression> ::= <RelationalExpression> '>=' <ShiftExpression>
      RULE_RELATIONALEXPRESSION_INSTANCEOF = 341, // <RelationalExpression> ::= <RelationalExpression> instanceof <ReferenceType>
      RULE_EQUALITYEXPRESSION = 342, // <EqualityExpression> ::= <RelationalExpression>
      RULE_EQUALITYEXPRESSION_EQEQ = 343, // <EqualityExpression> ::= <EqualityExpression> '==' <RelationalExpression>
      RULE_EQUALITYEXPRESSION_EXCLAMEQ = 344, // <EqualityExpression> ::= <EqualityExpression> '!=' <RelationalExpression>
      RULE_ANDEXPRESSION = 345, // <AndExpression> ::= <EqualityExpression>
      RULE_ANDEXPRESSION_AMP = 346, // <AndExpression> ::= <AndExpression> '&' <EqualityExpression>
      RULE_EXCLUSIVEOREXPRESSION = 347, // <ExclusiveOrExpression> ::= <AndExpression>
      RULE_EXCLUSIVEOREXPRESSION_CARET = 348, // <ExclusiveOrExpression> ::= <ExclusiveOrExpression> '^' <AndExpression>
      RULE_INCLUSIVEOREXPRESSION = 349, // <InclusiveOrExpression> ::= <ExclusiveOrExpression>
      RULE_INCLUSIVEOREXPRESSION_PIPE = 350, // <InclusiveOrExpression> ::= <InclusiveOrExpression> '|' <ExclusiveOrExpression>
      RULE_CONDITIONALANDEXPRESSION = 351, // <ConditionalAndExpression> ::= <InclusiveOrExpression>
      RULE_CONDITIONALANDEXPRESSION_AMPAMP = 352, // <ConditionalAndExpression> ::= <ConditionalAndExpression> '&&' <InclusiveOrExpression>
      RULE_CONDITIONALOREXPRESSION = 353, // <ConditionalOrExpression> ::= <ConditionalAndExpression>
      RULE_CONDITIONALOREXPRESSION_PIPEPIPE = 354, // <ConditionalOrExpression> ::= <ConditionalOrExpression> '||' <ConditionalAndExpression>
      RULE_CONDITIONALEXPRESSION = 355, // <ConditionalExpression> ::= <ConditionalOrExpression>
      RULE_CONDITIONALEXPRESSION_QUESTION_COLON = 356, // <ConditionalExpression> ::= <ConditionalOrExpression> '?' <Expression> ':' <ConditionalExpression>
      RULE_EXPRESSION_EQ = 357, // <Expression> ::= <ConditionalExpression> '=' <Expression>
      RULE_EXPRESSION_PLUSEQ = 358, // <Expression> ::= <ConditionalExpression> '+=' <Expression>
      RULE_EXPRESSION_MINUSEQ = 359, // <Expression> ::= <ConditionalExpression> '-=' <Expression>
      RULE_EXPRESSION_TIMESEQ = 360, // <Expression> ::= <ConditionalExpression> '*=' <Expression>
      RULE_EXPRESSION_DIVEQ = 361, // <Expression> ::= <ConditionalExpression> '/=' <Expression>
      RULE_EXPRESSION_CARETEQ = 362, // <Expression> ::= <ConditionalExpression> '^=' <Expression>
      RULE_EXPRESSION_AMPEQ = 363, // <Expression> ::= <ConditionalExpression> '&=' <Expression>
      RULE_EXPRESSION_PIPEEQ = 364, // <Expression> ::= <ConditionalExpression> '|=' <Expression>
      RULE_EXPRESSION_PERCENTEQ = 365, // <Expression> ::= <ConditionalExpression> '%=' <Expression>
      RULE_EXPRESSION_LTLTEQ = 366, // <Expression> ::= <ConditionalExpression> '<<=' <Expression>
      RULE_EXPRESSION_GTGTEQ = 367, // <Expression> ::= <ConditionalExpression> '>>=' <Expression>
      RULE_EXPRESSION_GTGTGTEQ = 368, // <Expression> ::= <ConditionalExpression> '>>>=' <Expression>
      RULE_EXPRESSION = 369, // <Expression> ::= <ConditionalExpression>
      RULE_CONSTANTEXPRESSION = 370  // <ConstantExpression> ::= <Expression>
    };
	}
}