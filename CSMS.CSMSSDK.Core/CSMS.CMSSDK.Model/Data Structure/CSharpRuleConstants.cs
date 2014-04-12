/********************************************************************/
/* Author: Jason Pugh	and Curt Lawson																*/
/* Date: © 05/18/2011  																							*/
/* Description: Generated via Gold Parser														*/
/* Information: The following code is copyrighted. The code cannot  */
/* be distributed without the consent of the author.								*/
/********************************************************************/
namespace CSMS.CSMSSDK.Model
{
  public enum CSSymbolConstants : int
  {
    /// <c> (EOF) </c>
    SYMBOL_EOF = 0,
    /// <c> (Error) </c>
    SYMBOL_ERROR = 1,
    /// <c> (Whitespace) </c>
    SYMBOL_WHITESPACE = 2,
    /// <c> (Comment End) </c>
    SYMBOL_COMMENTEND = 3,
    /// <c> (Comment Line) </c>
    SYMBOL_COMMENTLINE = 4,
    /// <c> (Comment Start) </c>
    SYMBOL_COMMENTSTART = 5,
    /// <c> '-' </c>
    SYMBOL_MINUS = 6,
    /// <c> -- </c>
    SYMBOL_MINUSMINUS = 7,
    /// <c> '!' </c>
    SYMBOL_EXCLAM = 8,
    /// <c> '!=' </c>
    SYMBOL_EXCLAMEQ = 9,
    /// <c> '%' </c>
    SYMBOL_PERCENT = 10,
    /// <c> '%=' </c>
    SYMBOL_PERCENTEQ = 11,
    /// <c> '&amp;' </c>
    SYMBOL_AMP = 12,
    /// <c> '&amp;&amp;' </c>
    SYMBOL_AMPAMP = 13,
    /// <c> '&amp;=' </c>
    SYMBOL_AMPEQ = 14,
    /// <c> '(' </c>
    SYMBOL_LPARAN = 15,
    /// <c> ')' </c>
    SYMBOL_RPARAN = 16,
    /// <c> '*' </c>
    SYMBOL_TIMES = 17,
    /// <c> '*=' </c>
    SYMBOL_TIMESEQ = 18,
    /// <c> ',' </c>
    SYMBOL_COMMA = 19,
    /// <c> '/' </c>
    SYMBOL_DIV = 20,
    /// <c> '/=' </c>
    SYMBOL_DIVEQ = 21,
    /// <c> ':' </c>
    SYMBOL_COLON = 22,
    /// <c> '::' </c>
    SYMBOL_COLONCOLON = 23,
    /// <c> ';' </c>
    SYMBOL_SEMI = 24,
    /// <c> '?' </c>
    SYMBOL_QUESTION = 25,
    /// <c> '[' </c>
    SYMBOL_LBRACKET = 26,
    /// <c> ']' </c>
    SYMBOL_RBRACKET = 27,
    /// <c> '^' </c>
    SYMBOL_CARET = 28,
    /// <c> '^=' </c>
    SYMBOL_CARETEQ = 29,
    /// <c> '{' </c>
    SYMBOL_LBRACE = 30,
    /// <c> '|' </c>
    SYMBOL_PIPE = 31,
    /// <c> '||' </c>
    SYMBOL_PIPEPIPE = 32,
    /// <c> '|=' </c>
    SYMBOL_PIPEEQ = 33,
    /// <c> '}' </c>
    SYMBOL_RBRACE = 34,
    /// <c> '~' </c>
    SYMBOL_TILDE = 35,
    /// <c> '+' </c>
    SYMBOL_PLUS = 36,
    /// <c> '++' </c>
    SYMBOL_PLUSPLUS = 37,
    /// <c> '+=' </c>
    SYMBOL_PLUSEQ = 38,
    /// <c> '&lt;' </c>
    SYMBOL_LT = 39,
    /// <c> '&lt;&lt;' </c>
    SYMBOL_LTLT = 40,
    /// <c> '&lt;&lt;=' </c>
    SYMBOL_LTLTEQ = 41,
    /// <c> '&lt;=' </c>
    SYMBOL_LTEQ = 42,
    /// <c> '=' </c>
    SYMBOL_EQ = 43,
    /// <c> '-=' </c>
    SYMBOL_MINUSEQ = 44,
    /// <c> '==' </c>
    SYMBOL_EQEQ = 45,
    /// <c> '=&gt;' </c>
    SYMBOL_EQGT = 46,
    /// <c> '&gt;' </c>
    SYMBOL_GT = 47,
    /// <c> '-&gt;' </c>
    SYMBOL_MINUSGT = 48,
    /// <c> '&gt;=' </c>
    SYMBOL_GTEQ = 49,
    /// <c> '&gt;&gt;' </c>
    SYMBOL_GTGT = 50,
    /// <c> '&gt;&gt;=' </c>
    SYMBOL_GTGTEQ = 51,
    /// <c> abstract </c>
    SYMBOL_ABSTRACT = 52,
    /// <c> add </c>
    SYMBOL_ADD = 53,
    /// <c> as </c>
    SYMBOL_AS = 54,
    /// <c> ascending </c>
    SYMBOL_ASCENDING = 55,
    /// <c> assembly </c>
    SYMBOL_ASSEMBLY = 56,
    /// <c> base </c>
    SYMBOL_BASE = 57,
    /// <c> bool </c>
    SYMBOL_BOOL = 58,
    /// <c> break </c>
    SYMBOL_BREAK = 59,
    /// <c> by </c>
    SYMBOL_BY = 60,
    /// <c> byte </c>
    SYMBOL_BYTE = 61,
    /// <c> case </c>
    SYMBOL_CASE = 62,
    /// <c> catch </c>
    SYMBOL_CATCH = 63,
    /// <c> char </c>
    SYMBOL_CHAR = 64,
    /// <c> CharLiteral </c>
    SYMBOL_CHARLITERAL = 65,
    /// <c> checked </c>
    SYMBOL_CHECKED = 66,
    /// <c> class </c>
    SYMBOL_CLASS = 67,
    /// <c> const </c>
    SYMBOL_CONST = 68,
    /// <c> continue </c>
    SYMBOL_CONTINUE = 69,
    /// <c> decimal </c>
    SYMBOL_DECIMAL = 70,
    /// <c> DecLiteral </c>
    SYMBOL_DECLITERAL = 71,
    /// <c> default </c>
    SYMBOL_DEFAULT = 72,
    /// <c> delegate </c>
    SYMBOL_DELEGATE = 73,
    /// <c> descending </c>
    SYMBOL_DESCENDING = 74,
    /// <c> do </c>
    SYMBOL_DO = 75,
    /// <c> double </c>
    SYMBOL_DOUBLE = 76,
    /// <c> else </c>
    SYMBOL_ELSE = 77,
    /// <c> enum </c>
    SYMBOL_ENUM = 78,
    /// <c> equals </c>
    SYMBOL_EQUALS = 79,
    /// <c> event </c>
    SYMBOL_EVENT = 80,
    /// <c> explicit </c>
    SYMBOL_EXPLICIT = 81,
    /// <c> extern </c>
    SYMBOL_EXTERN = 82,
    /// <c> false </c>
    SYMBOL_FALSE = 83,
    /// <c> field </c>
    SYMBOL_FIELD = 84,
    /// <c> finally </c>
    SYMBOL_FINALLY = 85,
    /// <c> fixed </c>
    SYMBOL_FIXED = 86,
    /// <c> float </c>
    SYMBOL_FLOAT = 87,
    /// <c> for </c>
    SYMBOL_FOR = 88,
    /// <c> foreach </c>
    SYMBOL_FOREACH = 89,
    /// <c> from </c>
    SYMBOL_FROM = 90,
    /// <c> get </c>
    SYMBOL_GET = 91,
    /// <c> global </c>
    SYMBOL_GLOBAL = 92,
    /// <c> goto </c>
    SYMBOL_GOTO = 93,
    /// <c> group </c>
    SYMBOL_GROUP = 94,
    /// <c> HexLiteral </c>
    SYMBOL_HEXLITERAL = 95,
    /// <c> Identifier </c>
    SYMBOL_IDENTIFIER = 96,
    /// <c> if </c>
    SYMBOL_IF = 97,
    /// <c> implicit </c>
    SYMBOL_IMPLICIT = 98,
    /// <c> in </c>
    SYMBOL_IN = 99,
    /// <c> int </c>
    SYMBOL_INT = 100,
    /// <c> interface </c>
    SYMBOL_INTERFACE = 101,
    /// <c> internal </c>
    SYMBOL_INTERNAL = 102,
    /// <c> into </c>
    SYMBOL_INTO = 103,
    /// <c> is </c>
    SYMBOL_IS = 104,
    /// <c> join </c>
    SYMBOL_JOIN = 105,
    /// <c> let </c>
    SYMBOL_LET = 106,
    /// <c> lock </c>
    SYMBOL_LOCK = 107,
    /// <c> long </c>
    SYMBOL_LONG = 108,
    /// <c> MemberName </c>
    SYMBOL_MEMBERNAME = 109,
    /// <c> method </c>
    SYMBOL_METHOD = 110,
    /// <c> module </c>
    SYMBOL_MODULE = 111,
    /// <c> namespace </c>
    SYMBOL_NAMESPACE = 112,
    /// <c> new </c>
    SYMBOL_NEW = 113,
    /// <c> null </c>
    SYMBOL_NULL = 114,
    /// <c> Nullable </c>
    SYMBOL_NULLABLE = 115,
    /// <c> object </c>
    SYMBOL_OBJECT = 116,
    /// <c> on </c>
    SYMBOL_ON = 117,
    /// <c> operator </c>
    SYMBOL_OPERATOR = 118,
    /// <c> orderby </c>
    SYMBOL_ORDERBY = 119,
    /// <c> out </c>
    SYMBOL_OUT = 120,
    /// <c> override </c>
    SYMBOL_OVERRIDE = 121,
    /// <c> param </c>
    SYMBOL_PARAM = 122,
    /// <c> params </c>
    SYMBOL_PARAMS = 123,
    /// <c> partial </c>
    SYMBOL_PARTIAL = 124,
    /// <c> private </c>
    SYMBOL_PRIVATE = 125,
    /// <c> property </c>
    SYMBOL_PROPERTY = 126,
    /// <c> protected </c>
    SYMBOL_PROTECTED = 127,
    /// <c> public </c>
    SYMBOL_PUBLIC = 128,
    /// <c> readonly </c>
    SYMBOL_READONLY = 129,
    /// <c> RealLiteral </c>
    SYMBOL_REALLITERAL = 130,
    /// <c> ref </c>
    SYMBOL_REF = 131,
    /// <c> remove </c>
    SYMBOL_REMOVE = 132,
    /// <c> return </c>
    SYMBOL_RETURN = 133,
    /// <c> sbyte </c>
    SYMBOL_SBYTE = 134,
    /// <c> sealed </c>
    SYMBOL_SEALED = 135,
    /// <c> select </c>
    SYMBOL_SELECT = 136,
    /// <c> set </c>
    SYMBOL_SET = 137,
    /// <c> short </c>
    SYMBOL_SHORT = 138,
    /// <c> sizeof </c>
    SYMBOL_SIZEOF = 139,
    /// <c> stackalloc </c>
    SYMBOL_STACKALLOC = 140,
    /// <c> static </c>
    SYMBOL_STATIC = 141,
    /// <c> string </c>
    SYMBOL_STRING = 142,
    /// <c> StringLiteral </c>
    SYMBOL_STRINGLITERAL = 143,
    /// <c> struct </c>
    SYMBOL_STRUCT = 144,
    /// <c> switch </c>
    SYMBOL_SWITCH = 145,
    /// <c> Template </c>
    SYMBOL_TEMPLATE = 146,
    /// <c> this </c>
    SYMBOL_THIS = 147,
    /// <c> throw </c>
    SYMBOL_THROW = 148,
    /// <c> true </c>
    SYMBOL_TRUE = 149,
    /// <c> try </c>
    SYMBOL_TRY = 150,
    /// <c> type </c>
    SYMBOL_TYPE = 151,
    /// <c> typeof </c>
    SYMBOL_TYPEOF = 152,
    /// <c> uint </c>
    SYMBOL_UINT = 153,
    /// <c> ulong </c>
    SYMBOL_ULONG = 154,
    /// <c> unchecked </c>
    SYMBOL_UNCHECKED = 155,
    /// <c> unsafe </c>
    SYMBOL_UNSAFE = 156,
    /// <c> ushort </c>
    SYMBOL_USHORT = 157,
    /// <c> using </c>
    SYMBOL_USING = 158,
    /// <c> virtual </c>
    SYMBOL_VIRTUAL = 159,
    /// <c> void </c>
    SYMBOL_VOID = 160,
    /// <c> volatile </c>
    SYMBOL_VOLATILE = 161,
    /// <c> where </c>
    SYMBOL_WHERE = 162,
    /// <c> while </c>
    SYMBOL_WHILE = 163,
    /// <c> &lt;Access Opt&gt; </c>
    SYMBOL_ACCESSOPT = 164,
    /// <c> &lt;Accessor Dec&gt; </c>
    SYMBOL_ACCESSORDEC = 165,
    /// <c> &lt;Add Exp&gt; </c>
    SYMBOL_ADDEXP = 166,
    /// <c> &lt;And Exp&gt; </c>
    SYMBOL_ANDEXP = 167,
    /// <c> &lt;anonymous_function_body&gt; </c>
    SYMBOL_ANONYMOUS_FUNCTION_BODY = 168,
    /// <c> &lt;Arg List&gt; </c>
    SYMBOL_ARGLIST = 169,
    /// <c> &lt;Arg List Opt&gt; </c>
    SYMBOL_ARGLISTOPT = 170,
    /// <c> &lt;Argument&gt; </c>
    SYMBOL_ARGUMENT = 171,
    /// <c> &lt;Array Initializer&gt; </c>
    SYMBOL_ARRAYINITIALIZER = 172,
    /// <c> &lt;Array Initializer Opt&gt; </c>
    SYMBOL_ARRAYINITIALIZEROPT = 173,
    /// <c> &lt;Assign Tail&gt; </c>
    SYMBOL_ASSIGNTAIL = 174,
    /// <c> &lt;Assign Tail Opt&gt; </c>
    SYMBOL_ASSIGNTAILOPT = 175,
    /// <c> &lt;Attrib List&gt; </c>
    SYMBOL_ATTRIBLIST = 176,
    /// <c> &lt;Attrib Opt&gt; </c>
    SYMBOL_ATTRIBOPT = 177,
    /// <c> &lt;Attrib Section&gt; </c>
    SYMBOL_ATTRIBSECTION = 178,
    /// <c> &lt;Attrib Target Spec Opt&gt; </c>
    SYMBOL_ATTRIBTARGETSPECOPT = 179,
    /// <c> &lt;Attribute&gt; </c>
    SYMBOL_ATTRIBUTE = 180,
    /// <c> &lt;Base Type&gt; </c>
    SYMBOL_BASETYPE = 181,
    /// <c> &lt;Block&gt; </c>
    SYMBOL_BLOCK = 182,
    /// <c> &lt;Block or Semi&gt; </c>
    SYMBOL_BLOCKORSEMI = 183,
    /// <c> &lt;Catch Clause&gt; </c>
    SYMBOL_CATCHCLAUSE = 184,
    /// <c> &lt;Catch Clauses&gt; </c>
    SYMBOL_CATCHCLAUSES = 185,
    /// <c> &lt;Class Base List&gt; </c>
    SYMBOL_CLASSBASELIST = 186,
    /// <c> &lt;Class Base Opt&gt; </c>
    SYMBOL_CLASSBASEOPT = 187,
    /// <c> &lt;Class Decl&gt; </c>
    SYMBOL_CLASSDECL = 188,
    /// <c> &lt;Class Item&gt; </c>
    SYMBOL_CLASSITEM = 189,
    /// <c> &lt;Class Item Decs Opt&gt; </c>
    SYMBOL_CLASSITEMDECSOPT = 190,
    /// <c> &lt;Compare Exp&gt; </c>
    SYMBOL_COMPAREEXP = 191,
    /// <c> &lt;Compilation Item&gt; </c>
    SYMBOL_COMPILATIONITEM = 192,
    /// <c> &lt;Compilation Items&gt; </c>
    SYMBOL_COMPILATIONITEMS = 193,
    /// <c> &lt;Compilation Unit&gt; </c>
    SYMBOL_COMPILATIONUNIT = 194,
    /// <c> &lt;Conditional Exp&gt; </c>
    SYMBOL_CONDITIONALEXP = 195,
    /// <c> &lt;Constant Dec&gt; </c>
    SYMBOL_CONSTANTDEC = 196,
    /// <c> &lt;Constant Declarator&gt; </c>
    SYMBOL_CONSTANTDECLARATOR = 197,
    /// <c> &lt;Constant Declarators&gt; </c>
    SYMBOL_CONSTANTDECLARATORS = 198,
    /// <c> &lt;Constructor Dec&gt; </c>
    SYMBOL_CONSTRUCTORDEC = 199,
    /// <c> &lt;Constructor Declarator&gt; </c>
    SYMBOL_CONSTRUCTORDECLARATOR = 200,
    /// <c> &lt;Constructor Init&gt; </c>
    SYMBOL_CONSTRUCTORINIT = 201,
    /// <c> &lt;Constructor Init Opt&gt; </c>
    SYMBOL_CONSTRUCTORINITOPT = 202,
    /// <c> &lt;Conversion Operator Decl&gt; </c>
    SYMBOL_CONVERSIONOPERATORDECL = 203,
    /// <c> &lt;Delegate Decl&gt; </c>
    SYMBOL_DELEGATEDECL = 204,
    /// <c> &lt;Destructor Dec&gt; </c>
    SYMBOL_DESTRUCTORDEC = 205,
    /// <c> &lt;Dim Separators&gt; </c>
    SYMBOL_DIMSEPARATORS = 206,
    /// <c> &lt;Enum Base Opt&gt; </c>
    SYMBOL_ENUMBASEOPT = 207,
    /// <c> &lt;Enum Body&gt; </c>
    SYMBOL_ENUMBODY = 208,
    /// <c> &lt;Enum Decl&gt; </c>
    SYMBOL_ENUMDECL = 209,
    /// <c> &lt;Enum Item Dec&gt; </c>
    SYMBOL_ENUMITEMDEC = 210,
    /// <c> &lt;Enum Item Decs&gt; </c>
    SYMBOL_ENUMITEMDECS = 211,
    /// <c> &lt;Enum Item Decs Opt&gt; </c>
    SYMBOL_ENUMITEMDECSOPT = 212,
    /// <c> &lt;Equality Exp&gt; </c>
    SYMBOL_EQUALITYEXP = 213,
    /// <c> &lt;Event Accessor Decs&gt; </c>
    SYMBOL_EVENTACCESSORDECS = 214,
    /// <c> &lt;Event Dec&gt; </c>
    SYMBOL_EVENTDEC = 215,
    /// <c> &lt;Expression&gt; </c>
    SYMBOL_EXPRESSION = 216,
    /// <c> &lt;Expression List&gt; </c>
    SYMBOL_EXPRESSIONLIST = 217,
    /// <c> &lt;Expression Opt&gt; </c>
    SYMBOL_EXPRESSIONOPT = 218,
    /// <c> &lt;Field Dec&gt; </c>
    SYMBOL_FIELDDEC = 219,
    /// <c> &lt;Finally Clause Opt&gt; </c>
    SYMBOL_FINALLYCLAUSEOPT = 220,
    /// <c> &lt;Fixed Ptr Dec&gt; </c>
    SYMBOL_FIXEDPTRDEC = 221,
    /// <c> &lt;Fixed Ptr Decs&gt; </c>
    SYMBOL_FIXEDPTRDECS = 222,
    /// <c> &lt;For Condition Opt&gt; </c>
    SYMBOL_FORCONDITIONOPT = 223,
    /// <c> &lt;For Init Opt&gt; </c>
    SYMBOL_FORINITOPT = 224,
    /// <c> &lt;For Iterator Opt&gt; </c>
    SYMBOL_FORITERATOROPT = 225,
    /// <c> &lt;Formal Param&gt; </c>
    SYMBOL_FORMALPARAM = 226,
    /// <c> &lt;Formal Param List&gt; </c>
    SYMBOL_FORMALPARAMLIST = 227,
    /// <c> &lt;Formal Param List Opt&gt; </c>
    SYMBOL_FORMALPARAMLISTOPT = 228,
    /// <c> &lt;from_clause&gt; </c>
    SYMBOL_FROM_CLAUSE = 229,
    /// <c> &lt;group_clause&gt; </c>
    SYMBOL_GROUP_CLAUSE = 230,
    /// <c> &lt;Header&gt; </c>
    SYMBOL_HEADER = 231,
    /// <c> &lt;Indexer Dec&gt; </c>
    SYMBOL_INDEXERDEC = 232,
    /// <c> &lt;Integral Type&gt; </c>
    SYMBOL_INTEGRALTYPE = 233,
    /// <c> &lt;Interface Accessors&gt; </c>
    SYMBOL_INTERFACEACCESSORS = 234,
    /// <c> &lt;Interface Base Opt&gt; </c>
    SYMBOL_INTERFACEBASEOPT = 235,
    /// <c> &lt;Interface Decl&gt; </c>
    SYMBOL_INTERFACEDECL = 236,
    /// <c> &lt;Interface Empty Body&gt; </c>
    SYMBOL_INTERFACEEMPTYBODY = 237,
    /// <c> &lt;Interface Event Dec&gt; </c>
    SYMBOL_INTERFACEEVENTDEC = 238,
    /// <c> &lt;Interface Indexer Dec&gt; </c>
    SYMBOL_INTERFACEINDEXERDEC = 239,
    /// <c> &lt;Interface Item Dec&gt; </c>
    SYMBOL_INTERFACEITEMDEC = 240,
    /// <c> &lt;Interface Item Decs Opt&gt; </c>
    SYMBOL_INTERFACEITEMDECSOPT = 241,
    /// <c> &lt;Interface Method Dec&gt; </c>
    SYMBOL_INTERFACEMETHODDEC = 242,
    /// <c> &lt;Interface Property Dec&gt; </c>
    SYMBOL_INTERFACEPROPERTYDEC = 243,
    /// <c> &lt;join_clause&gt; </c>
    SYMBOL_JOIN_CLAUSE = 244,
    /// <c> &lt;join_into_clause&gt; </c>
    SYMBOL_JOIN_INTO_CLAUSE = 245,
    /// <c> &lt;lambda_expression&gt; </c>
    SYMBOL_LAMBDA_EXPRESSION = 246,
    /// <c> &lt;let_clause&gt; </c>
    SYMBOL_LET_CLAUSE = 247,
    /// <c> &lt;Literal&gt; </c>
    SYMBOL_LITERAL = 248,
    /// <c> &lt;Local Var Decl&gt; </c>
    SYMBOL_LOCALVARDECL = 249,
    /// <c> &lt;Logical And Exp&gt; </c>
    SYMBOL_LOGICALANDEXP = 250,
    /// <c> &lt;Logical Or Exp&gt; </c>
    SYMBOL_LOGICALOREXP = 251,
    /// <c> &lt;Logical Xor Exp&gt; </c>
    SYMBOL_LOGICALXOREXP = 252,
    /// <c> &lt;Member List&gt; </c>
    SYMBOL_MEMBERLIST = 253,
    /// <c> &lt;Method&gt; </c>
    SYMBOL_METHOD2 = 254,
    /// <c> &lt;Method Dec&gt; </c>
    SYMBOL_METHODDEC = 255,
    /// <c> &lt;Method Exp&gt; </c>
    SYMBOL_METHODEXP = 256,
    /// <c> &lt;Method Req&gt; </c>
    SYMBOL_METHODREQ = 257,
    /// <c> &lt;Methods&gt; </c>
    SYMBOL_METHODS = 258,
    /// <c> &lt;Methods Opt&gt; </c>
    SYMBOL_METHODSOPT = 259,
    /// <c> &lt;Modifier&gt; </c>
    SYMBOL_MODIFIER = 260,
    /// <c> &lt;Modifier List&gt; </c>
    SYMBOL_MODIFIERLIST = 261,
    /// <c> &lt;Modifier List Opt&gt; </c>
    SYMBOL_MODIFIERLISTOPT = 262,
    /// <c> &lt;Mult Exp&gt; </c>
    SYMBOL_MULTEXP = 263,
    /// <c> &lt;Namespace Dec&gt; </c>
    SYMBOL_NAMESPACEDEC = 264,
    /// <c> &lt;Namespace Item&gt; </c>
    SYMBOL_NAMESPACEITEM = 265,
    /// <c> &lt;Namespace Items&gt; </c>
    SYMBOL_NAMESPACEITEMS = 266,
    /// <c> &lt;New Opt&gt; </c>
    SYMBOL_NEWOPT = 267,
    /// <c> &lt;Non Array Type&gt; </c>
    SYMBOL_NONARRAYTYPE = 268,
    /// <c> &lt;Normal Stm&gt; </c>
    SYMBOL_NORMALSTM = 269,
    /// <c> &lt;Nullable Type Opt&gt; </c>
    SYMBOL_NULLABLETYPEOPT = 270,
    /// <c> &lt;Object Exp&gt; </c>
    SYMBOL_OBJECTEXP = 271,
    /// <c> &lt;Operator Dec&gt; </c>
    SYMBOL_OPERATORDEC = 272,
    /// <c> &lt;Or Exp&gt; </c>
    SYMBOL_OREXP = 273,
    /// <c> &lt;orderby_clause&gt; </c>
    SYMBOL_ORDERBY_CLAUSE = 274,
    /// <c> &lt;ordering&gt; </c>
    SYMBOL_ORDERING = 275,
    /// <c> &lt;ordering_direction&gt; </c>
    SYMBOL_ORDERING_DIRECTION = 276,
    /// <c> &lt;orderings&gt; </c>
    SYMBOL_ORDERINGS = 277,
    /// <c> &lt;Other Type&gt; </c>
    SYMBOL_OTHERTYPE = 278,
    /// <c> &lt;Overload Op&gt; </c>
    SYMBOL_OVERLOADOP = 279,
    /// <c> &lt;Overload Operator Decl&gt; </c>
    SYMBOL_OVERLOADOPERATORDECL = 280,
    /// <c> &lt;Pointer Opt&gt; </c>
    SYMBOL_POINTEROPT = 281,
    /// <c> &lt;Primary&gt; </c>
    SYMBOL_PRIMARY = 282,
    /// <c> &lt;Primary Array Creation Exp&gt; </c>
    SYMBOL_PRIMARYARRAYCREATIONEXP = 283,
    /// <c> &lt;Primary Exp&gt; </c>
    SYMBOL_PRIMARYEXP = 284,
    /// <c> &lt;Property Dec&gt; </c>
    SYMBOL_PROPERTYDEC = 285,
    /// <c> &lt;Qualified ID&gt; </c>
    SYMBOL_QUALIFIEDID = 286,
    /// <c> &lt;query_body&gt; </c>
    SYMBOL_QUERY_BODY = 287,
    /// <c> &lt;query_body_clause&gt; </c>
    SYMBOL_QUERY_BODY_CLAUSE = 288,
    /// <c> &lt;query_body_clauses&gt; </c>
    SYMBOL_QUERY_BODY_CLAUSES = 289,
    /// <c> &lt;query_continuation&gt; </c>
    SYMBOL_QUERY_CONTINUATION = 290,
    /// <c> &lt;query_expression&gt; </c>
    SYMBOL_QUERY_EXPRESSION = 291,
    /// <c> &lt;Rank Specifier&gt; </c>
    SYMBOL_RANKSPECIFIER = 292,
    /// <c> &lt;Rank Specifiers&gt; </c>
    SYMBOL_RANKSPECIFIERS = 293,
    /// <c> &lt;Rank Specifiers Opt&gt; </c>
    SYMBOL_RANKSPECIFIERSOPT = 294,
    /// <c> &lt;Resource&gt; </c>
    SYMBOL_RESOURCE = 295,
    /// <c> &lt;select_clause&gt; </c>
    SYMBOL_SELECT_CLAUSE = 296,
    /// <c> &lt;select_or_group_clause&gt; </c>
    SYMBOL_SELECT_OR_GROUP_CLAUSE = 297,
    /// <c> &lt;Semicolon Opt&gt; </c>
    SYMBOL_SEMICOLONOPT = 298,
    /// <c> &lt;Set Block&gt; </c>
    SYMBOL_SETBLOCK = 299,
    /// <c> &lt;Set Block Opt&gt; </c>
    SYMBOL_SETBLOCKOPT = 300,
    /// <c> &lt;Shift Exp&gt; </c>
    SYMBOL_SHIFTEXP = 301,
    /// <c> &lt;Statement&gt; </c>
    SYMBOL_STATEMENT = 302,
    /// <c> &lt;Statement Exp&gt; </c>
    SYMBOL_STATEMENTEXP = 303,
    /// <c> &lt;Statement Exp List&gt; </c>
    SYMBOL_STATEMENTEXPLIST = 304,
    /// <c> &lt;Stm List&gt; </c>
    SYMBOL_STMLIST = 305,
    /// <c> &lt;Struct Decl&gt; </c>
    SYMBOL_STRUCTDECL = 306,
    /// <c> &lt;Switch Label&gt; </c>
    SYMBOL_SWITCHLABEL = 307,
    /// <c> &lt;Switch Labels&gt; </c>
    SYMBOL_SWITCHLABELS = 308,
    /// <c> &lt;Switch Section&gt; </c>
    SYMBOL_SWITCHSECTION = 309,
    /// <c> &lt;Switch Sections Opt&gt; </c>
    SYMBOL_SWITCHSECTIONSOPT = 310,
    /// <c> &lt;Then Stm&gt; </c>
    SYMBOL_THENSTM = 311,
    /// <c> &lt;Type&gt; </c>
    SYMBOL_TYPE2 = 312,
    /// <c> &lt;Type Decl&gt; </c>
    SYMBOL_TYPEDECL = 313,
    /// <c> &lt;Unary Exp&gt; </c>
    SYMBOL_UNARYEXP = 314,
    /// <c> &lt;Using Directive&gt; </c>
    SYMBOL_USINGDIRECTIVE = 315,
    /// <c> &lt;Using List&gt; </c>
    SYMBOL_USINGLIST = 316,
    /// <c> &lt;Valid ID&gt; </c>
    SYMBOL_VALIDID = 317,
    /// <c> &lt;Variable Declarator&gt; </c>
    SYMBOL_VARIABLEDECLARATOR = 318,
    /// <c> &lt;Variable Decs&gt; </c>
    SYMBOL_VARIABLEDECS = 319,
    /// <c> &lt;Variable Initializer&gt; </c>
    SYMBOL_VARIABLEINITIALIZER = 320,
    /// <c> &lt;Variable Initializer List&gt; </c>
    SYMBOL_VARIABLEINITIALIZERLIST = 321,
    /// <c> &lt;Variable Initializer List Opt&gt; </c>
    SYMBOL_VARIABLEINITIALIZERLISTOPT = 322,
    /// <c> &lt;where_clause&gt; </c>
    SYMBOL_WHERE_CLAUSE = 323
  };

  public enum CSRuleConstants : int
  {
    /// <c> &lt;Block or Semi&gt; ::= &lt;Block&gt; </c>
    RULE_BLOCKORSEMI = 0,
    /// <c> &lt;Block or Semi&gt; ::= ';' </c>
    RULE_BLOCKORSEMI_SEMI = 1,
    /// <c> &lt;Valid ID&gt; ::= Identifier </c>
    RULE_VALIDID_IDENTIFIER = 2,
    /// <c> &lt;Valid ID&gt; ::= this </c>
    RULE_VALIDID_THIS = 3,
    /// <c> &lt;Valid ID&gt; ::= base </c>
    RULE_VALIDID_BASE = 4,
    /// <c> &lt;Valid ID&gt; ::= &lt;Base Type&gt; </c>
    RULE_VALIDID = 5,
    /// <c> &lt;Valid ID&gt; ::= &lt;Base Type&gt; '?' </c>
    RULE_VALIDID_QUESTION = 6,
    /// <c> &lt;Qualified ID&gt; ::= &lt;Valid ID&gt; &lt;Member List&gt; </c>
    RULE_QUALIFIEDID = 7,
    /// <c> &lt;Qualified ID&gt; ::= &lt;Valid ID&gt; &lt;Member List&gt; Template &lt;Member List&gt; </c>
    RULE_QUALIFIEDID_TEMPLATE = 8,
    /// <c> &lt;Qualified ID&gt; ::= global '::' &lt;Valid ID&gt; &lt;Member List&gt; </c>
    RULE_QUALIFIEDID_GLOBAL_COLONCOLON = 9,
    /// <c> &lt;Member List&gt; ::= &lt;Member List&gt; MemberName </c>
    RULE_MEMBERLIST_MEMBERNAME = 10,
    /// <c> &lt;Member List&gt; ::=  </c>
    RULE_MEMBERLIST = 11,
    /// <c> &lt;Semicolon Opt&gt; ::= ';' </c>
    RULE_SEMICOLONOPT_SEMI = 12,
    /// <c> &lt;Semicolon Opt&gt; ::=  </c>
    RULE_SEMICOLONOPT = 13,
    /// <c> &lt;Literal&gt; ::= true </c>
    RULE_LITERAL_TRUE = 14,
    /// <c> &lt;Literal&gt; ::= false </c>
    RULE_LITERAL_FALSE = 15,
    /// <c> &lt;Literal&gt; ::= DecLiteral </c>
    RULE_LITERAL_DECLITERAL = 16,
    /// <c> &lt;Literal&gt; ::= HexLiteral </c>
    RULE_LITERAL_HEXLITERAL = 17,
    /// <c> &lt;Literal&gt; ::= RealLiteral </c>
    RULE_LITERAL_REALLITERAL = 18,
    /// <c> &lt;Literal&gt; ::= CharLiteral </c>
    RULE_LITERAL_CHARLITERAL = 19,
    /// <c> &lt;Literal&gt; ::= StringLiteral </c>
    RULE_LITERAL_STRINGLITERAL = 20,
    /// <c> &lt;Literal&gt; ::= null </c>
    RULE_LITERAL_NULL = 21,
    /// <c> &lt;Type&gt; ::= &lt;Non Array Type&gt; </c>
    RULE_TYPE = 22,
    /// <c> &lt;Type&gt; ::= &lt;Non Array Type&gt; '*' </c>
    RULE_TYPE_TIMES = 23,
    /// <c> &lt;Type&gt; ::= &lt;Non Array Type&gt; &lt;Rank Specifiers&gt; </c>
    RULE_TYPE2 = 24,
    /// <c> &lt;Type&gt; ::= &lt;Non Array Type&gt; &lt;Rank Specifiers&gt; '*' </c>
    RULE_TYPE_TIMES2 = 25,
    /// <c> &lt;Pointer Opt&gt; ::= '*' </c>
    RULE_POINTEROPT_TIMES = 26,
    /// <c> &lt;Pointer Opt&gt; ::=  </c>
    RULE_POINTEROPT = 27,
    /// <c> &lt;Non Array Type&gt; ::= &lt;Qualified ID&gt; &lt;Nullable Type Opt&gt; </c>
    RULE_NONARRAYTYPE = 28,
    /// <c> &lt;Nullable Type Opt&gt; ::= '?' </c>
    RULE_NULLABLETYPEOPT_QUESTION = 29,
    /// <c> &lt;Nullable Type Opt&gt; ::=  </c>
    RULE_NULLABLETYPEOPT = 30,
    /// <c> &lt;Base Type&gt; ::= &lt;Other Type&gt; </c>
    RULE_BASETYPE = 31,
    /// <c> &lt;Base Type&gt; ::= &lt;Integral Type&gt; </c>
    RULE_BASETYPE2 = 32,
    /// <c> &lt;Other Type&gt; ::= float </c>
    RULE_OTHERTYPE_FLOAT = 33,
    /// <c> &lt;Other Type&gt; ::= double </c>
    RULE_OTHERTYPE_DOUBLE = 34,
    /// <c> &lt;Other Type&gt; ::= decimal </c>
    RULE_OTHERTYPE_DECIMAL = 35,
    /// <c> &lt;Other Type&gt; ::= bool </c>
    RULE_OTHERTYPE_BOOL = 36,
    /// <c> &lt;Other Type&gt; ::= void </c>
    RULE_OTHERTYPE_VOID = 37,
    /// <c> &lt;Other Type&gt; ::= object </c>
    RULE_OTHERTYPE_OBJECT = 38,
    /// <c> &lt;Other Type&gt; ::= string </c>
    RULE_OTHERTYPE_STRING = 39,
    /// <c> &lt;Integral Type&gt; ::= sbyte </c>
    RULE_INTEGRALTYPE_SBYTE = 40,
    /// <c> &lt;Integral Type&gt; ::= byte </c>
    RULE_INTEGRALTYPE_BYTE = 41,
    /// <c> &lt;Integral Type&gt; ::= short </c>
    RULE_INTEGRALTYPE_SHORT = 42,
    /// <c> &lt;Integral Type&gt; ::= ushort </c>
    RULE_INTEGRALTYPE_USHORT = 43,
    /// <c> &lt;Integral Type&gt; ::= int </c>
    RULE_INTEGRALTYPE_INT = 44,
    /// <c> &lt;Integral Type&gt; ::= uint </c>
    RULE_INTEGRALTYPE_UINT = 45,
    /// <c> &lt;Integral Type&gt; ::= long </c>
    RULE_INTEGRALTYPE_LONG = 46,
    /// <c> &lt;Integral Type&gt; ::= ulong </c>
    RULE_INTEGRALTYPE_ULONG = 47,
    /// <c> &lt;Integral Type&gt; ::= char </c>
    RULE_INTEGRALTYPE_CHAR = 48,
    /// <c> &lt;Rank Specifiers Opt&gt; ::= &lt;Rank Specifiers Opt&gt; &lt;Rank Specifier&gt; </c>
    RULE_RANKSPECIFIERSOPT = 49,
    /// <c> &lt;Rank Specifiers Opt&gt; ::=  </c>
    RULE_RANKSPECIFIERSOPT2 = 50,
    /// <c> &lt;Rank Specifiers&gt; ::= &lt;Rank Specifiers&gt; &lt;Rank Specifier&gt; </c>
    RULE_RANKSPECIFIERS = 51,
    /// <c> &lt;Rank Specifiers&gt; ::= &lt;Rank Specifier&gt; </c>
    RULE_RANKSPECIFIERS2 = 52,
    /// <c> &lt;Rank Specifier&gt; ::= '[' &lt;Dim Separators&gt; ']' </c>
    RULE_RANKSPECIFIER_LBRACKET_RBRACKET = 53,
    /// <c> &lt;Dim Separators&gt; ::= &lt;Dim Separators&gt; ',' </c>
    RULE_DIMSEPARATORS_COMMA = 54,
    /// <c> &lt;Dim Separators&gt; ::=  </c>
    RULE_DIMSEPARATORS = 55,
    /// <c> &lt;lambda_expression&gt; ::= '(' &lt;Expression List&gt; ')' '=&gt;' &lt;anonymous_function_body&gt; </c>
    RULE_LAMBDA_EXPRESSION_LPARAN_RPARAN_EQGT = 56,
    /// <c> &lt;lambda_expression&gt; ::= '(' ')' '=&gt;' &lt;anonymous_function_body&gt; </c>
    RULE_LAMBDA_EXPRESSION_LPARAN_RPARAN_EQGT2 = 57,
    /// <c> &lt;lambda_expression&gt; ::= &lt;Expression&gt; '=&gt;' &lt;anonymous_function_body&gt; </c>
    RULE_LAMBDA_EXPRESSION_EQGT = 58,
    /// <c> &lt;anonymous_function_body&gt; ::= '(' &lt;Expression List&gt; ')' </c>
    RULE_ANONYMOUS_FUNCTION_BODY_LPARAN_RPARAN = 59,
    /// <c> &lt;anonymous_function_body&gt; ::= &lt;Expression List&gt; </c>
    RULE_ANONYMOUS_FUNCTION_BODY = 60,
    /// <c> &lt;anonymous_function_body&gt; ::= &lt;Block&gt; </c>
    RULE_ANONYMOUS_FUNCTION_BODY2 = 61,
    /// <c> &lt;query_expression&gt; ::= &lt;from_clause&gt; &lt;query_body&gt; </c>
    RULE_QUERY_EXPRESSION = 62,
    /// <c> &lt;from_clause&gt; ::= from &lt;Type&gt; Identifier in &lt;Expression&gt; </c>
    RULE_FROM_CLAUSE_FROM_IDENTIFIER_IN = 63,
    /// <c> &lt;from_clause&gt; ::= from Identifier in &lt;Expression&gt; </c>
    RULE_FROM_CLAUSE_FROM_IDENTIFIER_IN2 = 64,
    /// <c> &lt;query_body&gt; ::= &lt;query_body_clauses&gt; &lt;select_or_group_clause&gt; &lt;query_continuation&gt; </c>
    RULE_QUERY_BODY = 65,
    /// <c> &lt;query_body&gt; ::= &lt;query_body_clauses&gt; &lt;select_or_group_clause&gt; </c>
    RULE_QUERY_BODY2 = 66,
    /// <c> &lt;query_body&gt; ::= &lt;select_or_group_clause&gt; &lt;query_continuation&gt; </c>
    RULE_QUERY_BODY3 = 67,
    /// <c> &lt;query_body&gt; ::= &lt;select_or_group_clause&gt; </c>
    RULE_QUERY_BODY4 = 68,
    /// <c> &lt;query_body_clauses&gt; ::= &lt;query_body_clause&gt; </c>
    RULE_QUERY_BODY_CLAUSES = 69,
    /// <c> &lt;query_body_clauses&gt; ::= &lt;query_body_clauses&gt; &lt;query_body_clause&gt; </c>
    RULE_QUERY_BODY_CLAUSES2 = 70,
    /// <c> &lt;query_body_clause&gt; ::= &lt;from_clause&gt; </c>
    RULE_QUERY_BODY_CLAUSE = 71,
    /// <c> &lt;query_body_clause&gt; ::= &lt;let_clause&gt; </c>
    RULE_QUERY_BODY_CLAUSE2 = 72,
    /// <c> &lt;query_body_clause&gt; ::= &lt;where_clause&gt; </c>
    RULE_QUERY_BODY_CLAUSE3 = 73,
    /// <c> &lt;query_body_clause&gt; ::= &lt;join_clause&gt; </c>
    RULE_QUERY_BODY_CLAUSE4 = 74,
    /// <c> &lt;query_body_clause&gt; ::= &lt;join_into_clause&gt; </c>
    RULE_QUERY_BODY_CLAUSE5 = 75,
    /// <c> &lt;query_body_clause&gt; ::= &lt;orderby_clause&gt; </c>
    RULE_QUERY_BODY_CLAUSE6 = 76,
    /// <c> &lt;let_clause&gt; ::= let Identifier '=' &lt;Expression&gt; </c>
    RULE_LET_CLAUSE_LET_IDENTIFIER_EQ = 77,
    /// <c> &lt;where_clause&gt; ::= where &lt;Expression&gt; </c>
    RULE_WHERE_CLAUSE_WHERE = 78,
    /// <c> &lt;join_clause&gt; ::= join &lt;Qualified ID&gt; in &lt;Expression&gt; on &lt;Expression&gt; equals &lt;Expression&gt; </c>
    RULE_JOIN_CLAUSE_JOIN_IN_ON_EQUALS = 79,
    /// <c> &lt;join_clause&gt; ::= join Identifier in &lt;Expression&gt; on &lt;Expression&gt; equals &lt;Expression&gt; </c>
    RULE_JOIN_CLAUSE_JOIN_IDENTIFIER_IN_ON_EQUALS = 80,
    /// <c> &lt;join_into_clause&gt; ::= join &lt;Qualified ID&gt; Identifier in &lt;Expression&gt; on &lt;Expression&gt; equals &lt;Expression&gt; into Identifier </c>
    RULE_JOIN_INTO_CLAUSE_JOIN_IDENTIFIER_IN_ON_EQUALS_INTO_IDENTIFIER = 81,
    /// <c> &lt;join_into_clause&gt; ::= join Identifier in &lt;Expression&gt; on &lt;Expression&gt; equals &lt;Expression&gt; into Identifier </c>
    RULE_JOIN_INTO_CLAUSE_JOIN_IDENTIFIER_IN_ON_EQUALS_INTO_IDENTIFIER2 = 82,
    /// <c> &lt;orderby_clause&gt; ::= orderby &lt;orderings&gt; </c>
    RULE_ORDERBY_CLAUSE_ORDERBY = 83,
    /// <c> &lt;orderings&gt; ::= &lt;ordering&gt; </c>
    RULE_ORDERINGS = 84,
    /// <c> &lt;orderings&gt; ::= &lt;orderings&gt; ',' &lt;ordering&gt; </c>
    RULE_ORDERINGS_COMMA = 85,
    /// <c> &lt;ordering&gt; ::= &lt;Expression&gt; &lt;ordering_direction&gt; </c>
    RULE_ORDERING = 86,
    /// <c> &lt;ordering&gt; ::= &lt;Expression&gt; </c>
    RULE_ORDERING2 = 87,
    /// <c> &lt;ordering_direction&gt; ::= ascending </c>
    RULE_ORDERING_DIRECTION_ASCENDING = 88,
    /// <c> &lt;ordering_direction&gt; ::= descending </c>
    RULE_ORDERING_DIRECTION_DESCENDING = 89,
    /// <c> &lt;select_or_group_clause&gt; ::= &lt;select_clause&gt; </c>
    RULE_SELECT_OR_GROUP_CLAUSE = 90,
    /// <c> &lt;select_or_group_clause&gt; ::= &lt;group_clause&gt; </c>
    RULE_SELECT_OR_GROUP_CLAUSE2 = 91,
    /// <c> &lt;select_clause&gt; ::= select &lt;Expression&gt; </c>
    RULE_SELECT_CLAUSE_SELECT = 92,
    /// <c> &lt;group_clause&gt; ::= group &lt;Expression&gt; by &lt;Expression&gt; </c>
    RULE_GROUP_CLAUSE_GROUP_BY = 93,
    /// <c> &lt;query_continuation&gt; ::= into Identifier &lt;query_body&gt; </c>
    RULE_QUERY_CONTINUATION_INTO_IDENTIFIER = 94,
    /// <c> &lt;Expression Opt&gt; ::= &lt;Expression&gt; </c>
    RULE_EXPRESSIONOPT = 95,
    /// <c> &lt;Expression Opt&gt; ::=  </c>
    RULE_EXPRESSIONOPT2 = 96,
    /// <c> &lt;Expression List&gt; ::= &lt;Expression&gt; </c>
    RULE_EXPRESSIONLIST = 97,
    /// <c> &lt;Expression List&gt; ::= &lt;Expression&gt; ',' &lt;Expression List&gt; </c>
    RULE_EXPRESSIONLIST_COMMA = 98,
    /// <c> &lt;Expression&gt; ::= &lt;query_expression&gt; </c>
    RULE_EXPRESSION = 99,
    /// <c> &lt;Expression&gt; ::= &lt;lambda_expression&gt; </c>
    RULE_EXPRESSION2 = 100,
    /// <c> &lt;Expression&gt; ::= &lt;Conditional Exp&gt; '=' &lt;Expression&gt; </c>
    RULE_EXPRESSION_EQ = 101,
    /// <c> &lt;Expression&gt; ::= &lt;Conditional Exp&gt; '+=' &lt;Expression&gt; </c>
    RULE_EXPRESSION_PLUSEQ = 102,
    /// <c> &lt;Expression&gt; ::= &lt;Conditional Exp&gt; '-=' &lt;Expression&gt; </c>
    RULE_EXPRESSION_MINUSEQ = 103,
    /// <c> &lt;Expression&gt; ::= &lt;Conditional Exp&gt; '*=' &lt;Expression&gt; </c>
    RULE_EXPRESSION_TIMESEQ = 104,
    /// <c> &lt;Expression&gt; ::= &lt;Conditional Exp&gt; '/=' &lt;Expression&gt; </c>
    RULE_EXPRESSION_DIVEQ = 105,
    /// <c> &lt;Expression&gt; ::= &lt;Conditional Exp&gt; '^=' &lt;Expression&gt; </c>
    RULE_EXPRESSION_CARETEQ = 106,
    /// <c> &lt;Expression&gt; ::= &lt;Conditional Exp&gt; '&amp;=' &lt;Expression&gt; </c>
    RULE_EXPRESSION_AMPEQ = 107,
    /// <c> &lt;Expression&gt; ::= &lt;Conditional Exp&gt; '|=' &lt;Expression&gt; </c>
    RULE_EXPRESSION_PIPEEQ = 108,
    /// <c> &lt;Expression&gt; ::= &lt;Conditional Exp&gt; '%=' &lt;Expression&gt; </c>
    RULE_EXPRESSION_PERCENTEQ = 109,
    /// <c> &lt;Expression&gt; ::= &lt;Conditional Exp&gt; '&lt;&lt;=' &lt;Expression&gt; </c>
    RULE_EXPRESSION_LTLTEQ = 110,
    /// <c> &lt;Expression&gt; ::= &lt;Conditional Exp&gt; '&gt;&gt;=' &lt;Expression&gt; </c>
    RULE_EXPRESSION_GTGTEQ = 111,
    /// <c> &lt;Expression&gt; ::= &lt;Conditional Exp&gt; </c>
    RULE_EXPRESSION3 = 112,
    /// <c> &lt;Conditional Exp&gt; ::= &lt;Or Exp&gt; '?' &lt;Or Exp&gt; ':' &lt;Conditional Exp&gt; </c>
    RULE_CONDITIONALEXP_QUESTION_COLON = 113,
    /// <c> &lt;Conditional Exp&gt; ::= &lt;Or Exp&gt; </c>
    RULE_CONDITIONALEXP = 114,
    /// <c> &lt;Or Exp&gt; ::= &lt;Or Exp&gt; '||' &lt;And Exp&gt; </c>
    RULE_OREXP_PIPEPIPE = 115,
    /// <c> &lt;Or Exp&gt; ::= &lt;And Exp&gt; </c>
    RULE_OREXP = 116,
    /// <c> &lt;And Exp&gt; ::= &lt;And Exp&gt; '&amp;&amp;' &lt;Logical Or Exp&gt; </c>
    RULE_ANDEXP_AMPAMP = 117,
    /// <c> &lt;And Exp&gt; ::= &lt;Logical Or Exp&gt; </c>
    RULE_ANDEXP = 118,
    /// <c> &lt;Logical Or Exp&gt; ::= &lt;Logical Or Exp&gt; '|' &lt;Logical Xor Exp&gt; </c>
    RULE_LOGICALOREXP_PIPE = 119,
    /// <c> &lt;Logical Or Exp&gt; ::= &lt;Logical Xor Exp&gt; </c>
    RULE_LOGICALOREXP = 120,
    /// <c> &lt;Logical Xor Exp&gt; ::= &lt;Logical Xor Exp&gt; '^' &lt;Logical And Exp&gt; </c>
    RULE_LOGICALXOREXP_CARET = 121,
    /// <c> &lt;Logical Xor Exp&gt; ::= &lt;Logical And Exp&gt; </c>
    RULE_LOGICALXOREXP = 122,
    /// <c> &lt;Logical And Exp&gt; ::= &lt;Logical And Exp&gt; '&amp;' &lt;Equality Exp&gt; </c>
    RULE_LOGICALANDEXP_AMP = 123,
    /// <c> &lt;Logical And Exp&gt; ::= &lt;Equality Exp&gt; </c>
    RULE_LOGICALANDEXP = 124,
    /// <c> &lt;Equality Exp&gt; ::= &lt;Equality Exp&gt; '==' &lt;Compare Exp&gt; </c>
    RULE_EQUALITYEXP_EQEQ = 125,
    /// <c> &lt;Equality Exp&gt; ::= &lt;Equality Exp&gt; '!=' &lt;Compare Exp&gt; </c>
    RULE_EQUALITYEXP_EXCLAMEQ = 126,
    /// <c> &lt;Equality Exp&gt; ::= &lt;Compare Exp&gt; </c>
    RULE_EQUALITYEXP = 127,
    /// <c> &lt;Compare Exp&gt; ::= &lt;Compare Exp&gt; '&lt;' &lt;Shift Exp&gt; </c>
    RULE_COMPAREEXP_LT = 128,
    /// <c> &lt;Compare Exp&gt; ::= &lt;Compare Exp&gt; '&gt;' &lt;Shift Exp&gt; </c>
    RULE_COMPAREEXP_GT = 129,
    /// <c> &lt;Compare Exp&gt; ::= &lt;Compare Exp&gt; '&lt;=' &lt;Shift Exp&gt; </c>
    RULE_COMPAREEXP_LTEQ = 130,
    /// <c> &lt;Compare Exp&gt; ::= &lt;Compare Exp&gt; '&gt;=' &lt;Shift Exp&gt; </c>
    RULE_COMPAREEXP_GTEQ = 131,
    /// <c> &lt;Compare Exp&gt; ::= &lt;Compare Exp&gt; is &lt;Type&gt; </c>
    RULE_COMPAREEXP_IS = 132,
    /// <c> &lt;Compare Exp&gt; ::= &lt;Compare Exp&gt; as &lt;Type&gt; </c>
    RULE_COMPAREEXP_AS = 133,
    /// <c> &lt;Compare Exp&gt; ::= &lt;Shift Exp&gt; </c>
    RULE_COMPAREEXP = 134,
    /// <c> &lt;Shift Exp&gt; ::= &lt;Shift Exp&gt; '&lt;&lt;' &lt;Add Exp&gt; </c>
    RULE_SHIFTEXP_LTLT = 135,
    /// <c> &lt;Shift Exp&gt; ::= &lt;Shift Exp&gt; '&gt;&gt;' &lt;Add Exp&gt; </c>
    RULE_SHIFTEXP_GTGT = 136,
    /// <c> &lt;Shift Exp&gt; ::= &lt;Add Exp&gt; </c>
    RULE_SHIFTEXP = 137,
    /// <c> &lt;Add Exp&gt; ::= &lt;Add Exp&gt; '+' &lt;Mult Exp&gt; </c>
    RULE_ADDEXP_PLUS = 138,
    /// <c> &lt;Add Exp&gt; ::= &lt;Add Exp&gt; '-' &lt;Mult Exp&gt; </c>
    RULE_ADDEXP_MINUS = 139,
    /// <c> &lt;Add Exp&gt; ::= &lt;Mult Exp&gt; </c>
    RULE_ADDEXP = 140,
    /// <c> &lt;Mult Exp&gt; ::= &lt;Mult Exp&gt; '*' &lt;Unary Exp&gt; </c>
    RULE_MULTEXP_TIMES = 141,
    /// <c> &lt;Mult Exp&gt; ::= &lt;Mult Exp&gt; '/' &lt;Unary Exp&gt; </c>
    RULE_MULTEXP_DIV = 142,
    /// <c> &lt;Mult Exp&gt; ::= &lt;Mult Exp&gt; '%' &lt;Unary Exp&gt; </c>
    RULE_MULTEXP_PERCENT = 143,
    /// <c> &lt;Mult Exp&gt; ::= &lt;Unary Exp&gt; </c>
    RULE_MULTEXP = 144,
    /// <c> &lt;Unary Exp&gt; ::= '!' &lt;Unary Exp&gt; </c>
    RULE_UNARYEXP_EXCLAM = 145,
    /// <c> &lt;Unary Exp&gt; ::= '~' &lt;Unary Exp&gt; </c>
    RULE_UNARYEXP_TILDE = 146,
    /// <c> &lt;Unary Exp&gt; ::= '-' &lt;Unary Exp&gt; </c>
    RULE_UNARYEXP_MINUS = 147,
    /// <c> &lt;Unary Exp&gt; ::= '++' &lt;Unary Exp&gt; </c>
    RULE_UNARYEXP_PLUSPLUS = 148,
    /// <c> &lt;Unary Exp&gt; ::= -- &lt;Unary Exp&gt; </c>
    RULE_UNARYEXP_MINUSMINUS = 149,
    /// <c> &lt;Unary Exp&gt; ::= '(' &lt;Expression&gt; ')' &lt;Object Exp&gt; </c>
    RULE_UNARYEXP_LPARAN_RPARAN = 150,
    /// <c> &lt;Unary Exp&gt; ::= '(' &lt;Qualified ID&gt; Nullable &lt;Object Exp&gt; </c>
    RULE_UNARYEXP_LPARAN_NULLABLE = 151,
    /// <c> &lt;Unary Exp&gt; ::= &lt;Object Exp&gt; </c>
    RULE_UNARYEXP = 152,
    /// <c> &lt;Object Exp&gt; ::= delegate '(' &lt;Formal Param List Opt&gt; ')' &lt;Block&gt; </c>
    RULE_OBJECTEXP_DELEGATE_LPARAN_RPARAN = 153,
    /// <c> &lt;Object Exp&gt; ::= &lt;Primary Array Creation Exp&gt; </c>
    RULE_OBJECTEXP = 154,
    /// <c> &lt;Object Exp&gt; ::= &lt;Method Exp&gt; </c>
    RULE_OBJECTEXP2 = 155,
    /// <c> &lt;Primary Array Creation Exp&gt; ::= new &lt;Non Array Type&gt; '[' &lt;Expression List&gt; ']' &lt;Rank Specifiers Opt&gt; &lt;Array Initializer Opt&gt; </c>
    RULE_PRIMARYARRAYCREATIONEXP_NEW_LBRACKET_RBRACKET = 156,
    /// <c> &lt;Primary Array Creation Exp&gt; ::= new &lt;Non Array Type&gt; &lt;Rank Specifiers&gt; &lt;Array Initializer&gt; </c>
    RULE_PRIMARYARRAYCREATIONEXP_NEW = 157,
    /// <c> &lt;Method Exp&gt; ::= &lt;Method Exp&gt; &lt;Method&gt; </c>
    RULE_METHODEXP = 158,
    /// <c> &lt;Method Exp&gt; ::= &lt;Primary Exp&gt; </c>
    RULE_METHODEXP2 = 159,
    /// <c> &lt;Primary Exp&gt; ::= typeof '(' &lt;Type&gt; ')' </c>
    RULE_PRIMARYEXP_TYPEOF_LPARAN_RPARAN = 160,
    /// <c> &lt;Primary Exp&gt; ::= sizeof '(' &lt;Type&gt; ')' </c>
    RULE_PRIMARYEXP_SIZEOF_LPARAN_RPARAN = 161,
    /// <c> &lt;Primary Exp&gt; ::= checked '(' &lt;Expression&gt; ')' </c>
    RULE_PRIMARYEXP_CHECKED_LPARAN_RPARAN = 162,
    /// <c> &lt;Primary Exp&gt; ::= unchecked '(' &lt;Expression&gt; ')' </c>
    RULE_PRIMARYEXP_UNCHECKED_LPARAN_RPARAN = 163,
    /// <c> &lt;Primary Exp&gt; ::= typeof '(' &lt;Type&gt; Nullable </c>
    RULE_PRIMARYEXP_TYPEOF_LPARAN_NULLABLE = 164,
    /// <c> &lt;Primary Exp&gt; ::= sizeof '(' &lt;Type&gt; Nullable </c>
    RULE_PRIMARYEXP_SIZEOF_LPARAN_NULLABLE = 165,
    /// <c> &lt;Primary Exp&gt; ::= checked '(' &lt;Expression&gt; Nullable </c>
    RULE_PRIMARYEXP_CHECKED_LPARAN_NULLABLE = 166,
    /// <c> &lt;Primary Exp&gt; ::= unchecked '(' &lt;Expression&gt; Nullable </c>
    RULE_PRIMARYEXP_UNCHECKED_LPARAN_NULLABLE = 167,
    /// <c> &lt;Primary Exp&gt; ::= new &lt;Non Array Type&gt; '(' &lt;Arg List Opt&gt; ')' &lt;Set Block Opt&gt; </c>
    RULE_PRIMARYEXP_NEW_LPARAN_RPARAN = 168,
    /// <c> &lt;Primary Exp&gt; ::= new &lt;Non Array Type&gt; &lt;Set Block&gt; </c>
    RULE_PRIMARYEXP_NEW = 169,
    /// <c> &lt;Primary Exp&gt; ::= new &lt;Set Block&gt; </c>
    RULE_PRIMARYEXP_NEW2 = 170,
    /// <c> &lt;Primary Exp&gt; ::= &lt;Primary&gt; </c>
    RULE_PRIMARYEXP = 171,
    /// <c> &lt;Primary Exp&gt; ::= '(' &lt;Expression&gt; ')' </c>
    RULE_PRIMARYEXP_LPARAN_RPARAN = 172,
    /// <c> &lt;Set Block Opt&gt; ::= &lt;Set Block&gt; </c>
    RULE_SETBLOCKOPT = 173,
    /// <c> &lt;Set Block Opt&gt; ::=  </c>
    RULE_SETBLOCKOPT2 = 174,
    /// <c> &lt;Set Block&gt; ::= '{' &lt;Variable Decs&gt; '}' </c>
    RULE_SETBLOCK_LBRACE_RBRACE = 175,
    /// <c> &lt;Set Block&gt; ::= '{' &lt;Statement Exp List&gt; '}' </c>
    RULE_SETBLOCK_LBRACE_RBRACE2 = 176,
    /// <c> &lt;Primary&gt; ::= &lt;Qualified ID&gt; </c>
    RULE_PRIMARY = 177,
    /// <c> &lt;Primary&gt; ::= &lt;Qualified ID&gt; '(' &lt;Arg List Opt&gt; ')' </c>
    RULE_PRIMARY_LPARAN_RPARAN = 178,
    /// <c> &lt;Primary&gt; ::= &lt;Literal&gt; </c>
    RULE_PRIMARY2 = 179,
    /// <c> &lt;Arg List Opt&gt; ::= &lt;Arg List&gt; </c>
    RULE_ARGLISTOPT = 180,
    /// <c> &lt;Arg List Opt&gt; ::=  </c>
    RULE_ARGLISTOPT2 = 181,
    /// <c> &lt;Arg List&gt; ::= &lt;Arg List&gt; ',' &lt;Argument&gt; </c>
    RULE_ARGLIST_COMMA = 182,
    /// <c> &lt;Arg List&gt; ::= &lt;Argument&gt; </c>
    RULE_ARGLIST = 183,
    /// <c> &lt;Argument&gt; ::= &lt;Expression&gt; </c>
    RULE_ARGUMENT = 184,
    /// <c> &lt;Argument&gt; ::= ref &lt;Expression&gt; </c>
    RULE_ARGUMENT_REF = 185,
    /// <c> &lt;Argument&gt; ::= out &lt;Expression&gt; </c>
    RULE_ARGUMENT_OUT = 186,
    /// <c> &lt;Stm List&gt; ::= &lt;Stm List&gt; &lt;Statement&gt; </c>
    RULE_STMLIST = 187,
    /// <c> &lt;Stm List&gt; ::= &lt;Statement&gt; </c>
    RULE_STMLIST2 = 188,
    /// <c> &lt;Statement&gt; ::= Identifier ':' </c>
    RULE_STATEMENT_IDENTIFIER_COLON = 189,
    /// <c> &lt;Statement&gt; ::= &lt;Local Var Decl&gt; ';' </c>
    RULE_STATEMENT_SEMI = 190,
    /// <c> &lt;Statement&gt; ::= if '(' &lt;Expression&gt; ')' &lt;Statement&gt; </c>
    RULE_STATEMENT_IF_LPARAN_RPARAN = 191,
    /// <c> &lt;Statement&gt; ::= if '(' &lt;Expression&gt; ')' &lt;Then Stm&gt; else &lt;Statement&gt; </c>
    RULE_STATEMENT_IF_LPARAN_RPARAN_ELSE = 192,
    /// <c> &lt;Statement&gt; ::= for '(' &lt;For Init Opt&gt; ';' &lt;For Condition Opt&gt; ';' &lt;For Iterator Opt&gt; ')' &lt;Statement&gt; </c>
    RULE_STATEMENT_FOR_LPARAN_SEMI_SEMI_RPARAN = 193,
    /// <c> &lt;Statement&gt; ::= foreach '(' &lt;Type&gt; Identifier in &lt;Expression&gt; ')' &lt;Statement&gt; </c>
    RULE_STATEMENT_FOREACH_LPARAN_IDENTIFIER_IN_RPARAN = 194,
    /// <c> &lt;Statement&gt; ::= while '(' &lt;Expression&gt; ')' &lt;Statement&gt; </c>
    RULE_STATEMENT_WHILE_LPARAN_RPARAN = 195,
    /// <c> &lt;Statement&gt; ::= lock '(' &lt;Expression&gt; ')' &lt;Statement&gt; </c>
    RULE_STATEMENT_LOCK_LPARAN_RPARAN = 196,
    /// <c> &lt;Statement&gt; ::= using '(' &lt;Resource&gt; ')' &lt;Statement&gt; </c>
    RULE_STATEMENT_USING_LPARAN_RPARAN = 197,
    /// <c> &lt;Statement&gt; ::= fixed '(' &lt;Type&gt; &lt;Fixed Ptr Decs&gt; ')' &lt;Statement&gt; </c>
    RULE_STATEMENT_FIXED_LPARAN_RPARAN = 198,
    /// <c> &lt;Statement&gt; ::= delegate '(' &lt;Formal Param List Opt&gt; ')' &lt;Statement&gt; </c>
    RULE_STATEMENT_DELEGATE_LPARAN_RPARAN = 199,
    /// <c> &lt;Statement&gt; ::= &lt;Normal Stm&gt; </c>
    RULE_STATEMENT = 200,
    /// <c> &lt;Then Stm&gt; ::= if '(' &lt;Expression&gt; ')' &lt;Then Stm&gt; else &lt;Then Stm&gt; </c>
    RULE_THENSTM_IF_LPARAN_RPARAN_ELSE = 201,
    /// <c> &lt;Then Stm&gt; ::= for '(' &lt;For Init Opt&gt; ';' &lt;For Condition Opt&gt; ';' &lt;For Iterator Opt&gt; ')' &lt;Then Stm&gt; </c>
    RULE_THENSTM_FOR_LPARAN_SEMI_SEMI_RPARAN = 202,
    /// <c> &lt;Then Stm&gt; ::= foreach '(' &lt;Type&gt; Identifier in &lt;Expression&gt; ')' &lt;Then Stm&gt; </c>
    RULE_THENSTM_FOREACH_LPARAN_IDENTIFIER_IN_RPARAN = 203,
    /// <c> &lt;Then Stm&gt; ::= while '(' &lt;Expression&gt; ')' &lt;Then Stm&gt; </c>
    RULE_THENSTM_WHILE_LPARAN_RPARAN = 204,
    /// <c> &lt;Then Stm&gt; ::= lock '(' &lt;Expression&gt; ')' &lt;Then Stm&gt; </c>
    RULE_THENSTM_LOCK_LPARAN_RPARAN = 205,
    /// <c> &lt;Then Stm&gt; ::= using '(' &lt;Resource&gt; ')' &lt;Then Stm&gt; </c>
    RULE_THENSTM_USING_LPARAN_RPARAN = 206,
    /// <c> &lt;Then Stm&gt; ::= fixed '(' &lt;Type&gt; &lt;Fixed Ptr Decs&gt; ')' &lt;Then Stm&gt; </c>
    RULE_THENSTM_FIXED_LPARAN_RPARAN = 207,
    /// <c> &lt;Then Stm&gt; ::= delegate '(' &lt;Formal Param List Opt&gt; ')' &lt;Then Stm&gt; </c>
    RULE_THENSTM_DELEGATE_LPARAN_RPARAN = 208,
    /// <c> &lt;Then Stm&gt; ::= &lt;Normal Stm&gt; </c>
    RULE_THENSTM = 209,
    /// <c> &lt;Normal Stm&gt; ::= switch '(' &lt;Expression&gt; ')' '{' &lt;Switch Sections Opt&gt; '}' </c>
    RULE_NORMALSTM_SWITCH_LPARAN_RPARAN_LBRACE_RBRACE = 210,
    /// <c> &lt;Normal Stm&gt; ::= do &lt;Normal Stm&gt; while '(' &lt;Expression&gt; ')' ';' </c>
    RULE_NORMALSTM_DO_WHILE_LPARAN_RPARAN_SEMI = 211,
    /// <c> &lt;Normal Stm&gt; ::= try &lt;Block&gt; &lt;Catch Clauses&gt; &lt;Finally Clause Opt&gt; </c>
    RULE_NORMALSTM_TRY = 212,
    /// <c> &lt;Normal Stm&gt; ::= checked &lt;Block&gt; </c>
    RULE_NORMALSTM_CHECKED = 213,
    /// <c> &lt;Normal Stm&gt; ::= unchecked &lt;Block&gt; </c>
    RULE_NORMALSTM_UNCHECKED = 214,
    /// <c> &lt;Normal Stm&gt; ::= unsafe &lt;Block&gt; </c>
    RULE_NORMALSTM_UNSAFE = 215,
    /// <c> &lt;Normal Stm&gt; ::= break ';' </c>
    RULE_NORMALSTM_BREAK_SEMI = 216,
    /// <c> &lt;Normal Stm&gt; ::= continue ';' </c>
    RULE_NORMALSTM_CONTINUE_SEMI = 217,
    /// <c> &lt;Normal Stm&gt; ::= goto Identifier ';' </c>
    RULE_NORMALSTM_GOTO_IDENTIFIER_SEMI = 218,
    /// <c> &lt;Normal Stm&gt; ::= goto case &lt;Expression&gt; ';' </c>
    RULE_NORMALSTM_GOTO_CASE_SEMI = 219,
    /// <c> &lt;Normal Stm&gt; ::= goto default ';' </c>
    RULE_NORMALSTM_GOTO_DEFAULT_SEMI = 220,
    /// <c> &lt;Normal Stm&gt; ::= return &lt;Expression Opt&gt; ';' </c>
    RULE_NORMALSTM_RETURN_SEMI = 221,
    /// <c> &lt;Normal Stm&gt; ::= throw &lt;Expression Opt&gt; ';' </c>
    RULE_NORMALSTM_THROW_SEMI = 222,
    /// <c> &lt;Normal Stm&gt; ::= &lt;Statement Exp&gt; ';' </c>
    RULE_NORMALSTM_SEMI = 223,
    /// <c> &lt;Normal Stm&gt; ::= &lt;Constant Dec&gt; </c>
    RULE_NORMALSTM = 224,
    /// <c> &lt;Normal Stm&gt; ::= ';' </c>
    RULE_NORMALSTM_SEMI2 = 225,
    /// <c> &lt;Normal Stm&gt; ::= &lt;Block&gt; </c>
    RULE_NORMALSTM2 = 226,
    /// <c> &lt;Block&gt; ::= '{' &lt;Stm List&gt; '}' </c>
    RULE_BLOCK_LBRACE_RBRACE = 227,
    /// <c> &lt;Block&gt; ::= '{' '}' </c>
    RULE_BLOCK_LBRACE_RBRACE2 = 228,
    /// <c> &lt;Variable Decs&gt; ::= &lt;Variable Declarator&gt; </c>
    RULE_VARIABLEDECS = 229,
    /// <c> &lt;Variable Decs&gt; ::= &lt;Variable Decs&gt; ',' &lt;Variable Declarator&gt; </c>
    RULE_VARIABLEDECS_COMMA = 230,
    /// <c> &lt;Variable Declarator&gt; ::= Identifier </c>
    RULE_VARIABLEDECLARATOR_IDENTIFIER = 231,
    /// <c> &lt;Variable Declarator&gt; ::= Identifier '=' &lt;Variable Initializer&gt; </c>
    RULE_VARIABLEDECLARATOR_IDENTIFIER_EQ = 232,
    /// <c> &lt;Variable Declarator&gt; ::= &lt;Non Array Type&gt; '[' &lt;Expression List&gt; ']' </c>
    RULE_VARIABLEDECLARATOR_LBRACKET_RBRACKET = 233,
    /// <c> &lt;Variable Declarator&gt; ::= &lt;Literal&gt; </c>
    RULE_VARIABLEDECLARATOR = 234,
    /// <c> &lt;Variable Initializer&gt; ::= &lt;Expression&gt; </c>
    RULE_VARIABLEINITIALIZER = 235,
    /// <c> &lt;Variable Initializer&gt; ::= &lt;Array Initializer&gt; </c>
    RULE_VARIABLEINITIALIZER2 = 236,
    /// <c> &lt;Variable Initializer&gt; ::= stackalloc &lt;Non Array Type&gt; '[' &lt;Non Array Type&gt; ']' </c>
    RULE_VARIABLEINITIALIZER_STACKALLOC_LBRACKET_RBRACKET = 237,
    /// <c> &lt;Constant Declarators&gt; ::= &lt;Constant Declarator&gt; </c>
    RULE_CONSTANTDECLARATORS = 238,
    /// <c> &lt;Constant Declarators&gt; ::= &lt;Constant Declarators&gt; ',' &lt;Constant Declarator&gt; </c>
    RULE_CONSTANTDECLARATORS_COMMA = 239,
    /// <c> &lt;Constant Declarator&gt; ::= Identifier '=' &lt;Expression&gt; </c>
    RULE_CONSTANTDECLARATOR_IDENTIFIER_EQ = 240,
    /// <c> &lt;Switch Sections Opt&gt; ::= &lt;Switch Sections Opt&gt; &lt;Switch Section&gt; </c>
    RULE_SWITCHSECTIONSOPT = 241,
    /// <c> &lt;Switch Sections Opt&gt; ::=  </c>
    RULE_SWITCHSECTIONSOPT2 = 242,
    /// <c> &lt;Switch Section&gt; ::= &lt;Switch Labels&gt; &lt;Stm List&gt; </c>
    RULE_SWITCHSECTION = 243,
    /// <c> &lt;Switch Labels&gt; ::= &lt;Switch Label&gt; </c>
    RULE_SWITCHLABELS = 244,
    /// <c> &lt;Switch Labels&gt; ::= &lt;Switch Labels&gt; &lt;Switch Label&gt; </c>
    RULE_SWITCHLABELS2 = 245,
    /// <c> &lt;Switch Label&gt; ::= case &lt;Expression&gt; ':' </c>
    RULE_SWITCHLABEL_CASE_COLON = 246,
    /// <c> &lt;Switch Label&gt; ::= default ':' </c>
    RULE_SWITCHLABEL_DEFAULT_COLON = 247,
    /// <c> &lt;For Init Opt&gt; ::= &lt;Local Var Decl&gt; </c>
    RULE_FORINITOPT = 248,
    /// <c> &lt;For Init Opt&gt; ::= &lt;Statement Exp List&gt; </c>
    RULE_FORINITOPT2 = 249,
    /// <c> &lt;For Init Opt&gt; ::=  </c>
    RULE_FORINITOPT3 = 250,
    /// <c> &lt;For Iterator Opt&gt; ::= &lt;Statement Exp List&gt; </c>
    RULE_FORITERATOROPT = 251,
    /// <c> &lt;For Iterator Opt&gt; ::=  </c>
    RULE_FORITERATOROPT2 = 252,
    /// <c> &lt;For Condition Opt&gt; ::= &lt;Expression&gt; </c>
    RULE_FORCONDITIONOPT = 253,
    /// <c> &lt;For Condition Opt&gt; ::=  </c>
    RULE_FORCONDITIONOPT2 = 254,
    /// <c> &lt;Statement Exp List&gt; ::= &lt;Statement Exp List&gt; ',' &lt;Statement Exp&gt; </c>
    RULE_STATEMENTEXPLIST_COMMA = 255,
    /// <c> &lt;Statement Exp List&gt; ::= &lt;Statement Exp&gt; </c>
    RULE_STATEMENTEXPLIST = 256,
    /// <c> &lt;Catch Clauses&gt; ::= &lt;Catch Clause&gt; &lt;Catch Clauses&gt; </c>
    RULE_CATCHCLAUSES = 257,
    /// <c> &lt;Catch Clauses&gt; ::=  </c>
    RULE_CATCHCLAUSES2 = 258,
    /// <c> &lt;Catch Clause&gt; ::= catch '(' &lt;Qualified ID&gt; Identifier ')' &lt;Block&gt; </c>
    RULE_CATCHCLAUSE_CATCH_LPARAN_IDENTIFIER_RPARAN = 259,
    /// <c> &lt;Catch Clause&gt; ::= catch '(' &lt;Qualified ID&gt; ')' &lt;Block&gt; </c>
    RULE_CATCHCLAUSE_CATCH_LPARAN_RPARAN = 260,
    /// <c> &lt;Catch Clause&gt; ::= catch &lt;Block&gt; </c>
    RULE_CATCHCLAUSE_CATCH = 261,
    /// <c> &lt;Finally Clause Opt&gt; ::= finally &lt;Block&gt; </c>
    RULE_FINALLYCLAUSEOPT_FINALLY = 262,
    /// <c> &lt;Finally Clause Opt&gt; ::=  </c>
    RULE_FINALLYCLAUSEOPT = 263,
    /// <c> &lt;Resource&gt; ::= &lt;Local Var Decl&gt; </c>
    RULE_RESOURCE = 264,
    /// <c> &lt;Resource&gt; ::= &lt;Statement Exp&gt; </c>
    RULE_RESOURCE2 = 265,
    /// <c> &lt;Fixed Ptr Decs&gt; ::= &lt;Fixed Ptr Dec&gt; </c>
    RULE_FIXEDPTRDECS = 266,
    /// <c> &lt;Fixed Ptr Decs&gt; ::= &lt;Fixed Ptr Decs&gt; ',' &lt;Fixed Ptr Dec&gt; </c>
    RULE_FIXEDPTRDECS_COMMA = 267,
    /// <c> &lt;Fixed Ptr Dec&gt; ::= Identifier '=' &lt;Expression&gt; </c>
    RULE_FIXEDPTRDEC_IDENTIFIER_EQ = 268,
    /// <c> &lt;Local Var Decl&gt; ::= &lt;Qualified ID&gt; &lt;Rank Specifiers&gt; &lt;Pointer Opt&gt; &lt;Variable Decs&gt; </c>
    RULE_LOCALVARDECL = 269,
    /// <c> &lt;Local Var Decl&gt; ::= &lt;Qualified ID&gt; &lt;Nullable Type Opt&gt; &lt;Pointer Opt&gt; &lt;Variable Decs&gt; </c>
    RULE_LOCALVARDECL2 = 270,
    /// <c> &lt;Statement Exp&gt; ::= &lt;Qualified ID&gt; '(' &lt;Arg List Opt&gt; ')' &lt;Set Block Opt&gt; </c>
    RULE_STATEMENTEXP_LPARAN_RPARAN = 271,
    /// <c> &lt;Statement Exp&gt; ::= new &lt;Qualified ID&gt; '(' &lt;Arg List Opt&gt; ')' &lt;Set Block Opt&gt; </c>
    RULE_STATEMENTEXP_NEW_LPARAN_RPARAN = 272,
    /// <c> &lt;Statement Exp&gt; ::= &lt;Qualified ID&gt; '(' &lt;Arg List Opt&gt; ')' &lt;Methods&gt; &lt;Set Block Opt&gt; </c>
    RULE_STATEMENTEXP_LPARAN_RPARAN2 = 273,
    /// <c> &lt;Statement Exp&gt; ::= new &lt;Qualified ID&gt; '(' &lt;Arg List Opt&gt; ')' &lt;Methods&gt; &lt;Set Block Opt&gt; </c>
    RULE_STATEMENTEXP_NEW_LPARAN_RPARAN2 = 274,
    /// <c> &lt;Statement Exp&gt; ::= &lt;Qualified ID&gt; '(' &lt;Arg List Opt&gt; ')' &lt;Methods Opt&gt; &lt;Assign Tail&gt; </c>
    RULE_STATEMENTEXP_LPARAN_RPARAN3 = 275,
    /// <c> &lt;Statement Exp&gt; ::= '(' '(' &lt;Qualified ID&gt; ')' &lt;Qualified ID&gt; ')' &lt;Methods Opt&gt; &lt;Assign Tail&gt; </c>
    RULE_STATEMENTEXP_LPARAN_LPARAN_RPARAN_RPARAN = 276,
    /// <c> &lt;Statement Exp&gt; ::= '(' '(' &lt;Qualified ID&gt; ')' '(' &lt;Qualified ID&gt; ')' ')' &lt;Methods Opt&gt; &lt;Assign Tail&gt; </c>
    RULE_STATEMENTEXP_LPARAN_LPARAN_RPARAN_LPARAN_RPARAN_RPARAN = 277,
    /// <c> &lt;Statement Exp&gt; ::= '(' '(' &lt;Qualified ID&gt; ')' &lt;Qualified ID&gt; ')' &lt;Methods&gt; &lt;Assign Tail Opt&gt; </c>
    RULE_STATEMENTEXP_LPARAN_LPARAN_RPARAN_RPARAN2 = 278,
    /// <c> &lt;Statement Exp&gt; ::= '(' '(' &lt;Qualified ID&gt; ')' '(' &lt;Qualified ID&gt; ')' ')' &lt;Methods&gt; &lt;Assign Tail Opt&gt; </c>
    RULE_STATEMENTEXP_LPARAN_LPARAN_RPARAN_LPARAN_RPARAN_RPARAN2 = 279,
    /// <c> &lt;Statement Exp&gt; ::= &lt;Qualified ID&gt; '[' &lt;Expression List&gt; ']' &lt;Methods Opt&gt; &lt;Assign Tail&gt; </c>
    RULE_STATEMENTEXP_LBRACKET_RBRACKET = 280,
    /// <c> &lt;Statement Exp&gt; ::= &lt;Qualified ID&gt; '[' &lt;Expression List&gt; ']' &lt;Methods&gt; &lt;Assign Tail Opt&gt; </c>
    RULE_STATEMENTEXP_LBRACKET_RBRACKET2 = 281,
    /// <c> &lt;Statement Exp&gt; ::= &lt;Qualified ID&gt; '-&gt;' Identifier &lt;Methods Opt&gt; &lt;Assign Tail&gt; </c>
    RULE_STATEMENTEXP_MINUSGT_IDENTIFIER = 282,
    /// <c> &lt;Statement Exp&gt; ::= &lt;Qualified ID&gt; '++' &lt;Methods Opt&gt; &lt;Assign Tail&gt; </c>
    RULE_STATEMENTEXP_PLUSPLUS = 283,
    /// <c> &lt;Statement Exp&gt; ::= &lt;Qualified ID&gt; -- &lt;Methods Opt&gt; &lt;Assign Tail&gt; </c>
    RULE_STATEMENTEXP_MINUSMINUS = 284,
    /// <c> &lt;Statement Exp&gt; ::= &lt;Qualified ID&gt; &lt;Assign Tail&gt; </c>
    RULE_STATEMENTEXP = 285,
    /// <c> &lt;Statement Exp&gt; ::= &lt;Assign Tail&gt; &lt;Qualified ID&gt; </c>
    RULE_STATEMENTEXP2 = 286,
    /// <c> &lt;Statement Exp&gt; ::= &lt;Qualified ID&gt; '[' &lt;Expression List&gt; ']' </c>
    RULE_STATEMENTEXP_LBRACKET_RBRACKET3 = 287,
    /// <c> &lt;Assign Tail Opt&gt; ::= &lt;Assign Tail&gt; </c>
    RULE_ASSIGNTAILOPT = 288,
    /// <c> &lt;Assign Tail Opt&gt; ::=  </c>
    RULE_ASSIGNTAILOPT2 = 289,
    /// <c> &lt;Assign Tail&gt; ::= '++' </c>
    RULE_ASSIGNTAIL_PLUSPLUS = 290,
    /// <c> &lt;Assign Tail&gt; ::= -- </c>
    RULE_ASSIGNTAIL_MINUSMINUS = 291,
    /// <c> &lt;Assign Tail&gt; ::= '=' &lt;Expression&gt; </c>
    RULE_ASSIGNTAIL_EQ = 292,
    /// <c> &lt;Assign Tail&gt; ::= '+=' &lt;Expression&gt; </c>
    RULE_ASSIGNTAIL_PLUSEQ = 293,
    /// <c> &lt;Assign Tail&gt; ::= '-=' &lt;Expression&gt; </c>
    RULE_ASSIGNTAIL_MINUSEQ = 294,
    /// <c> &lt;Assign Tail&gt; ::= '*=' &lt;Expression&gt; </c>
    RULE_ASSIGNTAIL_TIMESEQ = 295,
    /// <c> &lt;Assign Tail&gt; ::= '/=' &lt;Expression&gt; </c>
    RULE_ASSIGNTAIL_DIVEQ = 296,
    /// <c> &lt;Assign Tail&gt; ::= '^=' &lt;Expression&gt; </c>
    RULE_ASSIGNTAIL_CARETEQ = 297,
    /// <c> &lt;Assign Tail&gt; ::= '&amp;=' &lt;Expression&gt; </c>
    RULE_ASSIGNTAIL_AMPEQ = 298,
    /// <c> &lt;Assign Tail&gt; ::= '|=' &lt;Expression&gt; </c>
    RULE_ASSIGNTAIL_PIPEEQ = 299,
    /// <c> &lt;Assign Tail&gt; ::= '%=' &lt;Expression&gt; </c>
    RULE_ASSIGNTAIL_PERCENTEQ = 300,
    /// <c> &lt;Assign Tail&gt; ::= '&lt;&lt;=' &lt;Expression&gt; </c>
    RULE_ASSIGNTAIL_LTLTEQ = 301,
    /// <c> &lt;Assign Tail&gt; ::= '&gt;&gt;=' &lt;Expression&gt; </c>
    RULE_ASSIGNTAIL_GTGTEQ = 302,
    /// <c> &lt;Methods&gt; ::= &lt;Methods&gt; &lt;Method Req&gt; </c>
    RULE_METHODS = 303,
    /// <c> &lt;Methods&gt; ::= &lt;Method Req&gt; </c>
    RULE_METHODS2 = 304,
    /// <c> &lt;Method Req&gt; ::= MemberName </c>
    RULE_METHODREQ_MEMBERNAME = 305,
    /// <c> &lt;Method Req&gt; ::= MemberName '(' &lt;Arg List Opt&gt; ')' </c>
    RULE_METHODREQ_MEMBERNAME_LPARAN_RPARAN = 306,
    /// <c> &lt;Method Req&gt; ::= MemberName '[' &lt;Expression List&gt; ']' </c>
    RULE_METHODREQ_MEMBERNAME_LBRACKET_RBRACKET = 307,
    /// <c> &lt;Method Req&gt; ::= '[' &lt;Expression List&gt; ']' </c>
    RULE_METHODREQ_LBRACKET_RBRACKET = 308,
    /// <c> &lt;Method Req&gt; ::= '-&gt;' Identifier </c>
    RULE_METHODREQ_MINUSGT_IDENTIFIER = 309,
    /// <c> &lt;Methods Opt&gt; ::= &lt;Methods Opt&gt; &lt;Method&gt; </c>
    RULE_METHODSOPT = 310,
    /// <c> &lt;Methods Opt&gt; ::=  </c>
    RULE_METHODSOPT2 = 311,
    /// <c> &lt;Method&gt; ::= MemberName </c>
    RULE_METHOD_MEMBERNAME = 312,
    /// <c> &lt;Method&gt; ::= MemberName '(' &lt;Arg List Opt&gt; ')' </c>
    RULE_METHOD_MEMBERNAME_LPARAN_RPARAN = 313,
    /// <c> &lt;Method&gt; ::= MemberName '[' &lt;Expression List&gt; ']' </c>
    RULE_METHOD_MEMBERNAME_LBRACKET_RBRACKET = 314,
    /// <c> &lt;Method&gt; ::= '[' &lt;Expression List&gt; ']' </c>
    RULE_METHOD_LBRACKET_RBRACKET = 315,
    /// <c> &lt;Method&gt; ::= '-&gt;' Identifier </c>
    RULE_METHOD_MINUSGT_IDENTIFIER = 316,
    /// <c> &lt;Method&gt; ::= '++' </c>
    RULE_METHOD_PLUSPLUS = 317,
    /// <c> &lt;Method&gt; ::= -- </c>
    RULE_METHOD_MINUSMINUS = 318,
    /// <c> &lt;Compilation Unit&gt; ::= &lt;Using List&gt; &lt;Compilation Items&gt; </c>
    RULE_COMPILATIONUNIT = 319,
    /// <c> &lt;Using List&gt; ::= &lt;Using List&gt; &lt;Using Directive&gt; </c>
    RULE_USINGLIST = 320,
    /// <c> &lt;Using List&gt; ::=  </c>
    RULE_USINGLIST2 = 321,
    /// <c> &lt;Using Directive&gt; ::= using Identifier '=' &lt;Qualified ID&gt; ';' </c>
    RULE_USINGDIRECTIVE_USING_IDENTIFIER_EQ_SEMI = 322,
    /// <c> &lt;Using Directive&gt; ::= using &lt;Qualified ID&gt; ';' </c>
    RULE_USINGDIRECTIVE_USING_SEMI = 323,
    /// <c> &lt;Compilation Items&gt; ::= &lt;Compilation Items&gt; &lt;Compilation Item&gt; </c>
    RULE_COMPILATIONITEMS = 324,
    /// <c> &lt;Compilation Items&gt; ::=  </c>
    RULE_COMPILATIONITEMS2 = 325,
    /// <c> &lt;Compilation Item&gt; ::= &lt;Namespace Dec&gt; </c>
    RULE_COMPILATIONITEM = 326,
    /// <c> &lt;Compilation Item&gt; ::= &lt;Namespace Item&gt; </c>
    RULE_COMPILATIONITEM2 = 327,
    /// <c> &lt;Namespace Dec&gt; ::= &lt;Attrib Opt&gt; namespace &lt;Qualified ID&gt; '{' &lt;Using List&gt; &lt;Namespace Items&gt; '}' &lt;Semicolon Opt&gt; </c>
    RULE_NAMESPACEDEC_NAMESPACE_LBRACE_RBRACE = 328,
    /// <c> &lt;Namespace Items&gt; ::= &lt;Namespace Items&gt; &lt;Namespace Item&gt; </c>
    RULE_NAMESPACEITEMS = 329,
    /// <c> &lt;Namespace Items&gt; ::= &lt;Namespace Items&gt; &lt;Namespace Dec&gt; &lt;Namespace Item&gt; </c>
    RULE_NAMESPACEITEMS2 = 330,
    /// <c> &lt;Namespace Items&gt; ::=  </c>
    RULE_NAMESPACEITEMS3 = 331,
    /// <c> &lt;Namespace Item&gt; ::= &lt;Type Decl&gt; </c>
    RULE_NAMESPACEITEM = 332,
    /// <c> &lt;Type Decl&gt; ::= &lt;Class Decl&gt; </c>
    RULE_TYPEDECL = 333,
    /// <c> &lt;Type Decl&gt; ::= &lt;Struct Decl&gt; </c>
    RULE_TYPEDECL2 = 334,
    /// <c> &lt;Type Decl&gt; ::= &lt;Interface Decl&gt; </c>
    RULE_TYPEDECL3 = 335,
    /// <c> &lt;Type Decl&gt; ::= &lt;Enum Decl&gt; </c>
    RULE_TYPEDECL4 = 336,
    /// <c> &lt;Type Decl&gt; ::= &lt;Delegate Decl&gt; </c>
    RULE_TYPEDECL5 = 337,
    /// <c> &lt;Header&gt; ::= &lt;Attrib Opt&gt; &lt;Access Opt&gt; &lt;Modifier List Opt&gt; </c>
    RULE_HEADER = 338,
    /// <c> &lt;Header&gt; ::= &lt;Attrib Opt&gt; &lt;Modifier List&gt; &lt;Access Opt&gt; </c>
    RULE_HEADER2 = 339,
    /// <c> &lt;Access Opt&gt; ::= private </c>
    RULE_ACCESSOPT_PRIVATE = 340,
    /// <c> &lt;Access Opt&gt; ::= protected </c>
    RULE_ACCESSOPT_PROTECTED = 341,
    /// <c> &lt;Access Opt&gt; ::= public </c>
    RULE_ACCESSOPT_PUBLIC = 342,
    /// <c> &lt;Access Opt&gt; ::= internal </c>
    RULE_ACCESSOPT_INTERNAL = 343,
    /// <c> &lt;Access Opt&gt; ::=  </c>
    RULE_ACCESSOPT = 344,
    /// <c> &lt;Modifier List Opt&gt; ::= &lt;Modifier List Opt&gt; &lt;Modifier&gt; </c>
    RULE_MODIFIERLISTOPT = 345,
    /// <c> &lt;Modifier List Opt&gt; ::=  </c>
    RULE_MODIFIERLISTOPT2 = 346,
    /// <c> &lt;Modifier List&gt; ::= &lt;Modifier List&gt; &lt;Modifier&gt; </c>
    RULE_MODIFIERLIST = 347,
    /// <c> &lt;Modifier List&gt; ::= &lt;Modifier&gt; </c>
    RULE_MODIFIERLIST2 = 348,
    /// <c> &lt;Modifier&gt; ::= abstract </c>
    RULE_MODIFIER_ABSTRACT = 349,
    /// <c> &lt;Modifier&gt; ::= extern </c>
    RULE_MODIFIER_EXTERN = 350,
    /// <c> &lt;Modifier&gt; ::= new </c>
    RULE_MODIFIER_NEW = 351,
    /// <c> &lt;Modifier&gt; ::= override </c>
    RULE_MODIFIER_OVERRIDE = 352,
    /// <c> &lt;Modifier&gt; ::= partial </c>
    RULE_MODIFIER_PARTIAL = 353,
    /// <c> &lt;Modifier&gt; ::= readonly </c>
    RULE_MODIFIER_READONLY = 354,
    /// <c> &lt;Modifier&gt; ::= sealed </c>
    RULE_MODIFIER_SEALED = 355,
    /// <c> &lt;Modifier&gt; ::= static </c>
    RULE_MODIFIER_STATIC = 356,
    /// <c> &lt;Modifier&gt; ::= unsafe </c>
    RULE_MODIFIER_UNSAFE = 357,
    /// <c> &lt;Modifier&gt; ::= virtual </c>
    RULE_MODIFIER_VIRTUAL = 358,
    /// <c> &lt;Modifier&gt; ::= volatile </c>
    RULE_MODIFIER_VOLATILE = 359,
    /// <c> &lt;Class Decl&gt; ::= &lt;Header&gt; class Identifier &lt;Class Base Opt&gt; '{' &lt;Class Item Decs Opt&gt; '}' &lt;Semicolon Opt&gt; </c>
    RULE_CLASSDECL_CLASS_IDENTIFIER_LBRACE_RBRACE = 360,
    /// <c> &lt;Class Base Opt&gt; ::= ':' &lt;Class Base List&gt; </c>
    RULE_CLASSBASEOPT_COLON = 361,
    /// <c> &lt;Class Base Opt&gt; ::=  </c>
    RULE_CLASSBASEOPT = 362,
    /// <c> &lt;Class Base List&gt; ::= &lt;Class Base List&gt; ',' &lt;Non Array Type&gt; </c>
    RULE_CLASSBASELIST_COMMA = 363,
    /// <c> &lt;Class Base List&gt; ::= &lt;Non Array Type&gt; </c>
    RULE_CLASSBASELIST = 364,
    /// <c> &lt;Class Item Decs Opt&gt; ::= &lt;Class Item Decs Opt&gt; &lt;Class Item&gt; </c>
    RULE_CLASSITEMDECSOPT = 365,
    /// <c> &lt;Class Item Decs Opt&gt; ::=  </c>
    RULE_CLASSITEMDECSOPT2 = 366,
    /// <c> &lt;Class Item&gt; ::= &lt;Constant Dec&gt; </c>
    RULE_CLASSITEM = 367,
    /// <c> &lt;Class Item&gt; ::= &lt;Field Dec&gt; </c>
    RULE_CLASSITEM2 = 368,
    /// <c> &lt;Class Item&gt; ::= &lt;Method Dec&gt; </c>
    RULE_CLASSITEM3 = 369,
    /// <c> &lt;Class Item&gt; ::= &lt;Property Dec&gt; </c>
    RULE_CLASSITEM4 = 370,
    /// <c> &lt;Class Item&gt; ::= &lt;Event Dec&gt; </c>
    RULE_CLASSITEM5 = 371,
    /// <c> &lt;Class Item&gt; ::= &lt;Indexer Dec&gt; </c>
    RULE_CLASSITEM6 = 372,
    /// <c> &lt;Class Item&gt; ::= &lt;Operator Dec&gt; </c>
    RULE_CLASSITEM7 = 373,
    /// <c> &lt;Class Item&gt; ::= &lt;Constructor Dec&gt; </c>
    RULE_CLASSITEM8 = 374,
    /// <c> &lt;Class Item&gt; ::= &lt;Destructor Dec&gt; </c>
    RULE_CLASSITEM9 = 375,
    /// <c> &lt;Class Item&gt; ::= &lt;Type Decl&gt; </c>
    RULE_CLASSITEM10 = 376,
    /// <c> &lt;Constant Dec&gt; ::= &lt;Header&gt; const &lt;Type&gt; &lt;Constant Declarators&gt; ';' </c>
    RULE_CONSTANTDEC_CONST_SEMI = 377,
    /// <c> &lt;Constant Dec&gt; ::= &lt;Header&gt; &lt;Type&gt; const &lt;Constant Declarators&gt; ';' </c>
    RULE_CONSTANTDEC_CONST_SEMI2 = 378,
    /// <c> &lt;Field Dec&gt; ::= &lt;Header&gt; &lt;Type&gt; &lt;Variable Decs&gt; ';' </c>
    RULE_FIELDDEC_SEMI = 379,
    /// <c> &lt;Method Dec&gt; ::= &lt;Header&gt; &lt;Type&gt; &lt;Qualified ID&gt; '(' &lt;Formal Param List Opt&gt; ')' &lt;Block or Semi&gt; </c>
    RULE_METHODDEC_LPARAN_RPARAN = 380,
    /// <c> &lt;Formal Param List Opt&gt; ::= &lt;Formal Param List&gt; </c>
    RULE_FORMALPARAMLISTOPT = 381,
    /// <c> &lt;Formal Param List Opt&gt; ::=  </c>
    RULE_FORMALPARAMLISTOPT2 = 382,
    /// <c> &lt;Formal Param List&gt; ::= &lt;Formal Param&gt; </c>
    RULE_FORMALPARAMLIST = 383,
    /// <c> &lt;Formal Param List&gt; ::= &lt;Formal Param List&gt; ',' &lt;Formal Param&gt; </c>
    RULE_FORMALPARAMLIST_COMMA = 384,
    /// <c> &lt;Formal Param&gt; ::= &lt;Attrib Opt&gt; &lt;Type&gt; Identifier </c>
    RULE_FORMALPARAM_IDENTIFIER = 385,
    /// <c> &lt;Formal Param&gt; ::= &lt;Attrib Opt&gt; ref &lt;Type&gt; Identifier </c>
    RULE_FORMALPARAM_REF_IDENTIFIER = 386,
    /// <c> &lt;Formal Param&gt; ::= &lt;Attrib Opt&gt; out &lt;Type&gt; Identifier </c>
    RULE_FORMALPARAM_OUT_IDENTIFIER = 387,
    /// <c> &lt;Formal Param&gt; ::= &lt;Attrib Opt&gt; params &lt;Type&gt; Identifier </c>
    RULE_FORMALPARAM_PARAMS_IDENTIFIER = 388,
    /// <c> &lt;Property Dec&gt; ::= &lt;Header&gt; &lt;Type&gt; &lt;Qualified ID&gt; '{' &lt;Accessor Dec&gt; '}' </c>
    RULE_PROPERTYDEC_LBRACE_RBRACE = 389,
    /// <c> &lt;Accessor Dec&gt; ::= &lt;Access Opt&gt; get &lt;Block or Semi&gt; </c>
    RULE_ACCESSORDEC_GET = 390,
    /// <c> &lt;Accessor Dec&gt; ::= &lt;Access Opt&gt; get &lt;Block or Semi&gt; &lt;Access Opt&gt; set &lt;Block or Semi&gt; </c>
    RULE_ACCESSORDEC_GET_SET = 391,
    /// <c> &lt;Accessor Dec&gt; ::= &lt;Access Opt&gt; set &lt;Block or Semi&gt; </c>
    RULE_ACCESSORDEC_SET = 392,
    /// <c> &lt;Accessor Dec&gt; ::= &lt;Access Opt&gt; set &lt;Block or Semi&gt; &lt;Access Opt&gt; get &lt;Block or Semi&gt; </c>
    RULE_ACCESSORDEC_SET_GET = 393,
    /// <c> &lt;Event Dec&gt; ::= &lt;Header&gt; event &lt;Type&gt; &lt;Variable Decs&gt; ';' </c>
    RULE_EVENTDEC_EVENT_SEMI = 394,
    /// <c> &lt;Event Dec&gt; ::= &lt;Header&gt; event &lt;Type&gt; &lt;Qualified ID&gt; '{' &lt;Event Accessor Decs&gt; '}' </c>
    RULE_EVENTDEC_EVENT_LBRACE_RBRACE = 395,
    /// <c> &lt;Event Accessor Decs&gt; ::= add &lt;Block or Semi&gt; </c>
    RULE_EVENTACCESSORDECS_ADD = 396,
    /// <c> &lt;Event Accessor Decs&gt; ::= add &lt;Block or Semi&gt; remove &lt;Block or Semi&gt; </c>
    RULE_EVENTACCESSORDECS_ADD_REMOVE = 397,
    /// <c> &lt;Event Accessor Decs&gt; ::= remove &lt;Block or Semi&gt; </c>
    RULE_EVENTACCESSORDECS_REMOVE = 398,
    /// <c> &lt;Event Accessor Decs&gt; ::= remove &lt;Block or Semi&gt; add &lt;Block or Semi&gt; </c>
    RULE_EVENTACCESSORDECS_REMOVE_ADD = 399,
    /// <c> &lt;Indexer Dec&gt; ::= &lt;Header&gt; &lt;Type&gt; &lt;Qualified ID&gt; '[' &lt;Formal Param List&gt; ']' '{' &lt;Accessor Dec&gt; '}' </c>
    RULE_INDEXERDEC_LBRACKET_RBRACKET_LBRACE_RBRACE = 400,
    /// <c> &lt;Operator Dec&gt; ::= &lt;Header&gt; &lt;Overload Operator Decl&gt; &lt;Block or Semi&gt; </c>
    RULE_OPERATORDEC = 401,
    /// <c> &lt;Operator Dec&gt; ::= &lt;Header&gt; &lt;Conversion Operator Decl&gt; &lt;Block or Semi&gt; </c>
    RULE_OPERATORDEC2 = 402,
    /// <c> &lt;Overload Operator Decl&gt; ::= &lt;Type&gt; operator &lt;Overload Op&gt; '(' &lt;Type&gt; Identifier ')' </c>
    RULE_OVERLOADOPERATORDECL_OPERATOR_LPARAN_IDENTIFIER_RPARAN = 403,
    /// <c> &lt;Overload Operator Decl&gt; ::= &lt;Type&gt; operator &lt;Overload Op&gt; '(' &lt;Type&gt; Identifier ',' &lt;Type&gt; Identifier ')' </c>
    RULE_OVERLOADOPERATORDECL_OPERATOR_LPARAN_IDENTIFIER_COMMA_IDENTIFIER_RPARAN = 404,
    /// <c> &lt;Conversion Operator Decl&gt; ::= implicit operator &lt;Type&gt; '(' &lt;Type&gt; Identifier ')' </c>
    RULE_CONVERSIONOPERATORDECL_IMPLICIT_OPERATOR_LPARAN_IDENTIFIER_RPARAN = 405,
    /// <c> &lt;Conversion Operator Decl&gt; ::= explicit operator &lt;Type&gt; '(' &lt;Type&gt; Identifier ')' </c>
    RULE_CONVERSIONOPERATORDECL_EXPLICIT_OPERATOR_LPARAN_IDENTIFIER_RPARAN = 406,
    /// <c> &lt;Overload Op&gt; ::= '+' </c>
    RULE_OVERLOADOP_PLUS = 407,
    /// <c> &lt;Overload Op&gt; ::= '-' </c>
    RULE_OVERLOADOP_MINUS = 408,
    /// <c> &lt;Overload Op&gt; ::= '!' </c>
    RULE_OVERLOADOP_EXCLAM = 409,
    /// <c> &lt;Overload Op&gt; ::= '~' </c>
    RULE_OVERLOADOP_TILDE = 410,
    /// <c> &lt;Overload Op&gt; ::= '++' </c>
    RULE_OVERLOADOP_PLUSPLUS = 411,
    /// <c> &lt;Overload Op&gt; ::= -- </c>
    RULE_OVERLOADOP_MINUSMINUS = 412,
    /// <c> &lt;Overload Op&gt; ::= true </c>
    RULE_OVERLOADOP_TRUE = 413,
    /// <c> &lt;Overload Op&gt; ::= false </c>
    RULE_OVERLOADOP_FALSE = 414,
    /// <c> &lt;Overload Op&gt; ::= '*' </c>
    RULE_OVERLOADOP_TIMES = 415,
    /// <c> &lt;Overload Op&gt; ::= '/' </c>
    RULE_OVERLOADOP_DIV = 416,
    /// <c> &lt;Overload Op&gt; ::= '%' </c>
    RULE_OVERLOADOP_PERCENT = 417,
    /// <c> &lt;Overload Op&gt; ::= '&amp;' </c>
    RULE_OVERLOADOP_AMP = 418,
    /// <c> &lt;Overload Op&gt; ::= '|' </c>
    RULE_OVERLOADOP_PIPE = 419,
    /// <c> &lt;Overload Op&gt; ::= '^' </c>
    RULE_OVERLOADOP_CARET = 420,
    /// <c> &lt;Overload Op&gt; ::= '&lt;&lt;' </c>
    RULE_OVERLOADOP_LTLT = 421,
    /// <c> &lt;Overload Op&gt; ::= '&gt;&gt;' </c>
    RULE_OVERLOADOP_GTGT = 422,
    /// <c> &lt;Overload Op&gt; ::= '==' </c>
    RULE_OVERLOADOP_EQEQ = 423,
    /// <c> &lt;Overload Op&gt; ::= '!=' </c>
    RULE_OVERLOADOP_EXCLAMEQ = 424,
    /// <c> &lt;Overload Op&gt; ::= '&gt;' </c>
    RULE_OVERLOADOP_GT = 425,
    /// <c> &lt;Overload Op&gt; ::= '&lt;' </c>
    RULE_OVERLOADOP_LT = 426,
    /// <c> &lt;Overload Op&gt; ::= '&gt;=' </c>
    RULE_OVERLOADOP_GTEQ = 427,
    /// <c> &lt;Overload Op&gt; ::= '&lt;=' </c>
    RULE_OVERLOADOP_LTEQ = 428,
    /// <c> &lt;Constructor Dec&gt; ::= &lt;Header&gt; &lt;Constructor Declarator&gt; &lt;Block or Semi&gt; </c>
    RULE_CONSTRUCTORDEC = 429,
    /// <c> &lt;Constructor Declarator&gt; ::= Identifier '(' &lt;Formal Param List Opt&gt; ')' &lt;Constructor Init Opt&gt; </c>
    RULE_CONSTRUCTORDECLARATOR_IDENTIFIER_LPARAN_RPARAN = 430,
    /// <c> &lt;Constructor Init Opt&gt; ::= &lt;Constructor Init&gt; </c>
    RULE_CONSTRUCTORINITOPT = 431,
    /// <c> &lt;Constructor Init Opt&gt; ::=  </c>
    RULE_CONSTRUCTORINITOPT2 = 432,
    /// <c> &lt;Constructor Init&gt; ::= ':' base '(' &lt;Arg List Opt&gt; ')' </c>
    RULE_CONSTRUCTORINIT_COLON_BASE_LPARAN_RPARAN = 433,
    /// <c> &lt;Constructor Init&gt; ::= ':' this '(' &lt;Arg List Opt&gt; ')' </c>
    RULE_CONSTRUCTORINIT_COLON_THIS_LPARAN_RPARAN = 434,
    /// <c> &lt;Destructor Dec&gt; ::= &lt;Header&gt; '~' Identifier '(' ')' &lt;Block&gt; </c>
    RULE_DESTRUCTORDEC_TILDE_IDENTIFIER_LPARAN_RPARAN = 435,
    /// <c> &lt;Struct Decl&gt; ::= &lt;Header&gt; struct Identifier &lt;Class Base Opt&gt; '{' &lt;Class Item Decs Opt&gt; '}' &lt;Semicolon Opt&gt; </c>
    RULE_STRUCTDECL_STRUCT_IDENTIFIER_LBRACE_RBRACE = 436,
    /// <c> &lt;Array Initializer Opt&gt; ::= &lt;Array Initializer&gt; </c>
    RULE_ARRAYINITIALIZEROPT = 437,
    /// <c> &lt;Array Initializer Opt&gt; ::=  </c>
    RULE_ARRAYINITIALIZEROPT2 = 438,
    /// <c> &lt;Array Initializer&gt; ::= '{' &lt;Variable Initializer List Opt&gt; '}' </c>
    RULE_ARRAYINITIALIZER_LBRACE_RBRACE = 439,
    /// <c> &lt;Array Initializer&gt; ::= '{' &lt;Variable Initializer List&gt; ',' '}' </c>
    RULE_ARRAYINITIALIZER_LBRACE_COMMA_RBRACE = 440,
    /// <c> &lt;Variable Initializer List Opt&gt; ::= &lt;Variable Initializer List&gt; </c>
    RULE_VARIABLEINITIALIZERLISTOPT = 441,
    /// <c> &lt;Variable Initializer List Opt&gt; ::=  </c>
    RULE_VARIABLEINITIALIZERLISTOPT2 = 442,
    /// <c> &lt;Variable Initializer List&gt; ::= &lt;Variable Initializer&gt; </c>
    RULE_VARIABLEINITIALIZERLIST = 443,
    /// <c> &lt;Variable Initializer List&gt; ::= &lt;Variable Initializer List&gt; ',' &lt;Variable Initializer&gt; </c>
    RULE_VARIABLEINITIALIZERLIST_COMMA = 444,
    /// <c> &lt;Interface Decl&gt; ::= &lt;Header&gt; interface Identifier &lt;Interface Base Opt&gt; '{' &lt;Interface Item Decs Opt&gt; '}' &lt;Semicolon Opt&gt; </c>
    RULE_INTERFACEDECL_INTERFACE_IDENTIFIER_LBRACE_RBRACE = 445,
    /// <c> &lt;Interface Base Opt&gt; ::= ':' &lt;Class Base List&gt; </c>
    RULE_INTERFACEBASEOPT_COLON = 446,
    /// <c> &lt;Interface Base Opt&gt; ::=  </c>
    RULE_INTERFACEBASEOPT = 447,
    /// <c> &lt;Interface Item Decs Opt&gt; ::= &lt;Interface Item Decs Opt&gt; &lt;Interface Item Dec&gt; </c>
    RULE_INTERFACEITEMDECSOPT = 448,
    /// <c> &lt;Interface Item Decs Opt&gt; ::=  </c>
    RULE_INTERFACEITEMDECSOPT2 = 449,
    /// <c> &lt;Interface Item Dec&gt; ::= &lt;Interface Method Dec&gt; </c>
    RULE_INTERFACEITEMDEC = 450,
    /// <c> &lt;Interface Item Dec&gt; ::= &lt;Interface Property Dec&gt; </c>
    RULE_INTERFACEITEMDEC2 = 451,
    /// <c> &lt;Interface Item Dec&gt; ::= &lt;Interface Event Dec&gt; </c>
    RULE_INTERFACEITEMDEC3 = 452,
    /// <c> &lt;Interface Item Dec&gt; ::= &lt;Interface Indexer Dec&gt; </c>
    RULE_INTERFACEITEMDEC4 = 453,
    /// <c> &lt;Interface Method Dec&gt; ::= &lt;Attrib Opt&gt; &lt;New Opt&gt; &lt;Type&gt; Identifier '(' &lt;Formal Param List Opt&gt; ')' &lt;Interface Empty Body&gt; </c>
    RULE_INTERFACEMETHODDEC_IDENTIFIER_LPARAN_RPARAN = 454,
    /// <c> &lt;New Opt&gt; ::= new </c>
    RULE_NEWOPT_NEW = 455,
    /// <c> &lt;New Opt&gt; ::=  </c>
    RULE_NEWOPT = 456,
    /// <c> &lt;Interface Property Dec&gt; ::= &lt;Attrib Opt&gt; &lt;New Opt&gt; &lt;Type&gt; Identifier '{' &lt;Interface Accessors&gt; '}' </c>
    RULE_INTERFACEPROPERTYDEC_IDENTIFIER_LBRACE_RBRACE = 457,
    /// <c> &lt;Interface Indexer Dec&gt; ::= &lt;Attrib Opt&gt; &lt;New Opt&gt; &lt;Type&gt; this '[' &lt;Formal Param List&gt; ']' '{' &lt;Interface Accessors&gt; '}' </c>
    RULE_INTERFACEINDEXERDEC_THIS_LBRACKET_RBRACKET_LBRACE_RBRACE = 458,
    /// <c> &lt;Interface Accessors&gt; ::= &lt;Attrib Opt&gt; &lt;Access Opt&gt; get &lt;Interface Empty Body&gt; </c>
    RULE_INTERFACEACCESSORS_GET = 459,
    /// <c> &lt;Interface Accessors&gt; ::= &lt;Attrib Opt&gt; &lt;Access Opt&gt; set &lt;Interface Empty Body&gt; </c>
    RULE_INTERFACEACCESSORS_SET = 460,
    /// <c> &lt;Interface Accessors&gt; ::= &lt;Attrib Opt&gt; &lt;Access Opt&gt; get &lt;Interface Empty Body&gt; &lt;Attrib Opt&gt; &lt;Access Opt&gt; set &lt;Interface Empty Body&gt; </c>
    RULE_INTERFACEACCESSORS_GET_SET = 461,
    /// <c> &lt;Interface Accessors&gt; ::= &lt;Attrib Opt&gt; &lt;Access Opt&gt; set &lt;Interface Empty Body&gt; &lt;Attrib Opt&gt; &lt;Access Opt&gt; get &lt;Interface Empty Body&gt; </c>
    RULE_INTERFACEACCESSORS_SET_GET = 462,
    /// <c> &lt;Interface Event Dec&gt; ::= &lt;Attrib Opt&gt; &lt;New Opt&gt; event &lt;Type&gt; Identifier &lt;Interface Empty Body&gt; </c>
    RULE_INTERFACEEVENTDEC_EVENT_IDENTIFIER = 463,
    /// <c> &lt;Interface Empty Body&gt; ::= ';' </c>
    RULE_INTERFACEEMPTYBODY_SEMI = 464,
    /// <c> &lt;Interface Empty Body&gt; ::= '{' '}' </c>
    RULE_INTERFACEEMPTYBODY_LBRACE_RBRACE = 465,
    /// <c> &lt;Enum Decl&gt; ::= &lt;Header&gt; enum Identifier &lt;Enum Base Opt&gt; &lt;Enum Body&gt; &lt;Semicolon Opt&gt; </c>
    RULE_ENUMDECL_ENUM_IDENTIFIER = 466,
    /// <c> &lt;Enum Base Opt&gt; ::= ':' &lt;Integral Type&gt; </c>
    RULE_ENUMBASEOPT_COLON = 467,
    /// <c> &lt;Enum Base Opt&gt; ::=  </c>
    RULE_ENUMBASEOPT = 468,
    /// <c> &lt;Enum Body&gt; ::= '{' &lt;Enum Item Decs Opt&gt; '}' </c>
    RULE_ENUMBODY_LBRACE_RBRACE = 469,
    /// <c> &lt;Enum Body&gt; ::= '{' &lt;Enum Item Decs&gt; ',' '}' </c>
    RULE_ENUMBODY_LBRACE_COMMA_RBRACE = 470,
    /// <c> &lt;Enum Item Decs Opt&gt; ::= &lt;Enum Item Decs&gt; </c>
    RULE_ENUMITEMDECSOPT = 471,
    /// <c> &lt;Enum Item Decs Opt&gt; ::=  </c>
    RULE_ENUMITEMDECSOPT2 = 472,
    /// <c> &lt;Enum Item Decs&gt; ::= &lt;Enum Item Dec&gt; </c>
    RULE_ENUMITEMDECS = 473,
    /// <c> &lt;Enum Item Decs&gt; ::= &lt;Enum Item Decs&gt; ',' &lt;Enum Item Dec&gt; </c>
    RULE_ENUMITEMDECS_COMMA = 474,
    /// <c> &lt;Enum Item Dec&gt; ::= &lt;Attrib Opt&gt; Identifier </c>
    RULE_ENUMITEMDEC_IDENTIFIER = 475,
    /// <c> &lt;Enum Item Dec&gt; ::= &lt;Attrib Opt&gt; Identifier '=' &lt;Expression&gt; </c>
    RULE_ENUMITEMDEC_IDENTIFIER_EQ = 476,
    /// <c> &lt;Delegate Decl&gt; ::= &lt;Header&gt; delegate &lt;Type&gt; Identifier '(' &lt;Formal Param List Opt&gt; ')' ';' </c>
    RULE_DELEGATEDECL_DELEGATE_IDENTIFIER_LPARAN_RPARAN_SEMI = 477,
    /// <c> &lt;Attrib Opt&gt; ::= &lt;Attrib Opt&gt; &lt;Attrib Section&gt; </c>
    RULE_ATTRIBOPT = 478,
    /// <c> &lt;Attrib Opt&gt; ::=  </c>
    RULE_ATTRIBOPT2 = 479,
    /// <c> &lt;Attrib Section&gt; ::= '[' &lt;Attrib Target Spec Opt&gt; &lt;Attrib List&gt; ']' </c>
    RULE_ATTRIBSECTION_LBRACKET_RBRACKET = 480,
    /// <c> &lt;Attrib Section&gt; ::= '[' &lt;Attrib Target Spec Opt&gt; &lt;Attrib List&gt; ',' ']' </c>
    RULE_ATTRIBSECTION_LBRACKET_COMMA_RBRACKET = 481,
    /// <c> &lt;Attrib Target Spec Opt&gt; ::= assembly ':' </c>
    RULE_ATTRIBTARGETSPECOPT_ASSEMBLY_COLON = 482,
    /// <c> &lt;Attrib Target Spec Opt&gt; ::= field ':' </c>
    RULE_ATTRIBTARGETSPECOPT_FIELD_COLON = 483,
    /// <c> &lt;Attrib Target Spec Opt&gt; ::= event ':' </c>
    RULE_ATTRIBTARGETSPECOPT_EVENT_COLON = 484,
    /// <c> &lt;Attrib Target Spec Opt&gt; ::= method ':' </c>
    RULE_ATTRIBTARGETSPECOPT_METHOD_COLON = 485,
    /// <c> &lt;Attrib Target Spec Opt&gt; ::= module ':' </c>
    RULE_ATTRIBTARGETSPECOPT_MODULE_COLON = 486,
    /// <c> &lt;Attrib Target Spec Opt&gt; ::= param ':' </c>
    RULE_ATTRIBTARGETSPECOPT_PARAM_COLON = 487,
    /// <c> &lt;Attrib Target Spec Opt&gt; ::= property ':' </c>
    RULE_ATTRIBTARGETSPECOPT_PROPERTY_COLON = 488,
    /// <c> &lt;Attrib Target Spec Opt&gt; ::= return ':' </c>
    RULE_ATTRIBTARGETSPECOPT_RETURN_COLON = 489,
    /// <c> &lt;Attrib Target Spec Opt&gt; ::= type ':' </c>
    RULE_ATTRIBTARGETSPECOPT_TYPE_COLON = 490,
    /// <c> &lt;Attrib Target Spec Opt&gt; ::= global '::' </c>
    RULE_ATTRIBTARGETSPECOPT_GLOBAL_COLONCOLON = 491,
    /// <c> &lt;Attrib Target Spec Opt&gt; ::=  </c>
    RULE_ATTRIBTARGETSPECOPT = 492,
    /// <c> &lt;Attrib List&gt; ::= &lt;Attribute&gt; </c>
    RULE_ATTRIBLIST = 493,
    /// <c> &lt;Attrib List&gt; ::= &lt;Attrib List&gt; ',' &lt;Attribute&gt; </c>
    RULE_ATTRIBLIST_COMMA = 494,
    /// <c> &lt;Attribute&gt; ::= &lt;Qualified ID&gt; '(' &lt;Expression List&gt; ')' </c>
    RULE_ATTRIBUTE_LPARAN_RPARAN = 495,
    /// <c> &lt;Attribute&gt; ::= &lt;Qualified ID&gt; '(' ')' </c>
    RULE_ATTRIBUTE_LPARAN_RPARAN2 = 496,
    /// <c> &lt;Attribute&gt; ::= &lt;Qualified ID&gt; </c>
    RULE_ATTRIBUTE = 497
  };
}
