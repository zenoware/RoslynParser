
namespace CSMS.CSMSSDK.Model
{
  /// <summary>
  /// C++ Symbols
  /// </summary>
    public enum CPPSymbolIndex
    {
        @Eof = 0,                                  // (EOF)
        @Error = 1,                                // (Error)
        @Comment = 2,                              // Comment
        @Newline = 3,                              // NewLine
        @Test = 4,                                 // Test
        @Whitespace = 5,                           // Whitespace
        @Timesdiv = 6,                             // '*/'
        @Divtimes = 7,                             // '/*'
        @Divdiv = 8,                               // '//'
        @Minus = 9,                                // '-'
        @Minusminus = 10,                          // '--'
        @Exclam = 11,                              // '!'
        @Exclameq = 12,                            // '!='
        @Num = 13,                                 // '#'
        @Percent = 14,                             // '%'
        @Amp = 15,                                 // '&'
        @Ampamp = 16,                              // '&&'
        @Ampeq = 17,                               // '&='
        @Lparan = 18,                              // '('
        @Rparan = 19,                              // ')'
        @Times = 20,                               // '*'
        @Timeseq = 21,                             // '*='
        @Comma = 22,                               // ','
        @Dot = 23,                                 // '.'
        @Div = 24,                                 // '/'
        @Diveq = 25,                               // '/='
        @Colon = 26,                               // ':'
        @Semi = 27,                                // ';'
        @Question = 28,                            // '?'
        @Lbracket = 29,                            // '['
        @Rbracket = 30,                            // ']'
        @Caret = 31,                               // '^'
        @Careteq = 32,                             // '^='
        @Lbrace = 33,                              // '{'
        @Pipe = 34,                                // '|'
        @Pipepipe = 35,                            // '||'
        @Pipeeq = 36,                              // '|='
        @Rbrace = 37,                              // '}'
        @Tilde = 38,                               // '~'
        @Plus = 39,                                // '+'
        @Plusplus = 40,                            // '++'
        @Pluseq = 41,                              // '+='
        @Lt = 42,                                  // '<'
        @Ltlt = 43,                                // '<<'
        @Ltlteq = 44,                              // '<<='
        @Lteq = 45,                                // '<='
        @Eq = 46,                                  // '='
        @Minuseq = 47,                             // '-='
        @Eqeq = 48,                                // '=='
        @Gt = 49,                                  // '>'
        @Minusgt = 50,                             // '->'
        @Gteq = 51,                                // '>='
        @Gtgt = 52,                                // '>>'
        @Gtgteq = 53,                              // '>>='
        @Auto = 54,                                // auto
        @Bool = 55,                                // bool
        @Break = 56,                               // break
        @Case = 57,                                // case
        @Char = 58,                                // char
        @Charliteral = 59,                         // CharLiteral
        @Class = 60,                               // class
        @Const = 61,                               // const
        @Continue = 62,                            // continue
        @Decliteral = 63,                          // DecLiteral
        @Default = 64,                             // default
        @Delete = 65,                              // delete
        @Do = 66,                                  // do
        @Double = 67,                              // double
        @Else = 68,                                // else
        @Enum = 69,                                // enum
        @Extern = 70,                              // extern
        @Float = 71,                               // float
        @Floatliteral = 72,                        // FloatLiteral
        @For = 73,                                 // for
        @Friend = 74,                              // friend
        @Goto = 75,                                // goto
        @Hexliteral = 76,                          // HexLiteral
        @Id = 77,                                  // Id
        @If = 78,                                  // if
        @Include = 79,                             // include
        @Inline = 80,                              // inline
        @Int = 81,                                 // int
        @Long = 82,                                // long
        @Membername = 83,                          // MemberName
        @Mutable = 84,                             // mutable
        @Namespace = 85,                           // namespace
        @New = 86,                                 // new
        @Octliteral = 87,                          // OctLiteral
        @Private = 88,                             // private
        @Protected = 89,                           // protected
        @Public = 90,                              // public
        @Register = 91,                            // register
        @Return = 92,                              // return
        @Short = 93,                               // short
        @Signed = 94,                              // signed
        @Sizeof = 95,                              // sizeof
        @Static = 96,                              // static
        @Stringliteral = 97,                       // StringLiteral
        @Struct = 98,                              // struct
        @Switch = 99,                              // switch
        @Template = 100,                           // Template
        @Typedef = 101,                            // typedef
        @Union = 102,                              // union
        @Unsigned = 103,                           // unsigned
        @Using = 104,                              // using
        @Virtual = 105,                            // virtual
        @Void = 106,                               // void
        @Volatile = 107,                           // volatile
        @While = 108,                              // while
        @Addressreq = 109,                         // <Address Req>
        @Arg = 110,                                // <Arg>
        @Array = 111,                              // <Array>
        @Arrayinit = 112,                          // <Array Init>
        @Arrayinitoropif = 113,                    // <Array Init or Op If>
        @Arrayitem = 114,                          // <Array Item>
        @Base = 115,                               // <Base>
        @Basefunct = 116,                          // <Base Funct>
        @Basefunctlist = 117,                      // <Base Funct List>
        @Baseopt = 118,                            // <Base Opt>
        @Block = 119,                              // <Block>
        @Casestms = 120,                           // <Case Stms>
        @Classbase = 121,                          // <Class Base>
        @Classbaselist = 122,                      // <Class Base List>
        @Classbaseopt = 123,                       // <Class Base Opt>
        @Classbody = 124,                          // <Class Body>
        @Classdecl = 125,                          // <Class Decl>
        @Classproto = 126,                         // <Class Proto>
        @Decl = 127,                               // <Decl>
        @Decls = 128,                              // <Decls>
        @Destructor = 129,                         // <Destructor>
        @Enumdecl = 130,                           // <Enum Decl>
        @Enumdef = 131,                            // <Enum Def>
        @Enumval = 132,                            // <Enum Val>
        @Expr = 133,                               // <Expr>
        @Externbody = 134,                         // <Extern Body>
        @File = 135,                               // <File>
        @Funcdecl = 136,                           // <Func Decl>
        @Funcid = 137,                             // <Func ID>
        @Funcproto = 138,                          // <Func Proto>
        @Label = 139,                              // <Label>
        @Literal = 140,                            // <Literal>
        @Memberlist = 141,                         // <Member List>
        @Mod = 142,                                // <Mod>
        @Modlist = 143,                            // <Mod List>
        @Modlistopt = 144,                         // <Mod List Opt>
        @Namespacebody = 145,                      // <Namespace Body>
        @Namespacedecl = 146,                      // <Namespace Decl>
        @Namespaceproto = 147,                     // <Namespace Proto>
        @Normalstm = 148,                          // <Normal Stm>
        @Opadd = 149,                              // <Op Add>
        @Opand = 150,                              // <Op And>
        @Opassign = 151,                           // <Op Assign>
        @Opbinand = 152,                           // <Op BinAND>
        @Opbinor = 153,                            // <Op BinOR>
        @Opbinxor = 154,                           // <Op BinXOR>
        @Opcompare = 155,                          // <Op Compare>
        @Opequate = 156,                           // <Op Equate>
        @Opif = 157,                               // <Op If>
        @Opmult = 158,                             // <Op Mult>
        @Opor = 159,                               // <Op Or>
        @Oppointer = 160,                          // <Op Pointer>
        @Opshift = 161,                            // <Op Shift>
        @Opunary = 162,                            // <Op Unary>
        @Param = 163,                              // <Param>
        @Params = 164,                             // <Params>
        @Pointers = 165,                           // <Pointers>
        @Pointersreq = 166,                        // <Pointers Req>
        @Pp_statement = 167,                       // <PP_Statement>
        @Preprocessor = 168,                       // <Preprocessor>
        @Preprocessors = 169,                      // <Preprocessors>
        @Qualifiedid = 170,                        // <Qualified ID>
        @Qualifiedidlist = 171,                    // <Qualified ID List>
        @Scalar = 172,                             // <Scalar>
        @Scalarlist = 173,                         // <Scalar List>
        @Semiopt = 174,                            // <Semi Opt>
        @Sign = 175,                               // <Sign>
        @Signreq = 176,                            // <Sign Req>
        @Stm = 177,                                // <Stm>
        @Stmlist = 178,                            // <Stm List>
        @Structdecl = 179,                         // <Struct Decl>
        @Structdef = 180,                          // <Struct Def>
        @Stuctproto = 181,                         // <Stuct Proto>
        @Thenstm = 182,                            // <Then Stm>
        @Type = 183,                               // <Type>
        @Typedefdecl = 184,                        // <Typedef Decl>
        @Uniondecl = 185,                          // <Union Decl>
        @Using2 = 186,                             // <Using>
        @Value = 187,                              // <Value>
        @Var = 188,                                // <Var>
        @Vardecl = 189,                            // <Var Decl>
        @Varitem = 190,                            // <Var Item>
        @Varlist = 191,                            // <Var List>
        @Varreference = 192                        // <Var Reference>
    }

  /// <summary>
  /// C++ Production Rules
  /// </summary>
    public enum CPPProductionIndex
    {
        @Decls = 0,                                // <Decls> ::= <Decl> <Decls>
        @Decls2 = 1,                               // <Decls> ::= 
        @Decl = 2,                                 // <Decl> ::= <PP_Statement>
        @Decl2 = 3,                                // <Decl> ::= <Using>
        @Decl3 = 4,                                // <Decl> ::= <Func Decl>
        @Decl4 = 5,                                // <Decl> ::= <Func Proto>
        @Decl5 = 6,                                // <Decl> ::= <Struct Decl>
        @Decl6 = 7,                                // <Decl> ::= <Stuct Proto>
        @Decl7 = 8,                                // <Decl> ::= <Class Decl>
        @Decl8 = 9,                                // <Decl> ::= <Class Proto>
        @Decl9 = 10,                               // <Decl> ::= <Namespace Decl>
        @Decl10 = 11,                              // <Decl> ::= <Namespace Proto>
        @Decl11 = 12,                              // <Decl> ::= <Union Decl>
        @Decl12 = 13,                              // <Decl> ::= <Enum Decl>
        @Decl13 = 14,                              // <Decl> ::= <Var Decl>
        @Decl14 = 15,                              // <Decl> ::= <Typedef Decl>
        @Decl15 = 16,                              // <Decl> ::= <Label>
        @Decl16 = 17,                              // <Decl> ::= <Destructor>
        @Decl17 = 18,                              // <Decl> ::= <Extern Body>
        @Externbody_Stringliteral_Lbrace_Rbrace = 19,  // <Extern Body> ::= <Mod List> StringLiteral '{' <Decls> '}'
        @Externbody_Extern_Charliteral_Lbrace_Rbrace = 20,  // <Extern Body> ::= extern CharLiteral '{' <Decls> '}'
        @Qualifiedid_Id = 21,                      // <Qualified ID> ::= Id <Member List>
        @Qualifiedid_Id_Template = 22,             // <Qualified ID> ::= Id <Member List> Template <Member List>
        @Memberlist_Membername = 23,               // <Member List> ::= <Member List> MemberName
        @Memberlist = 24,                          // <Member List> ::= 
        @Preprocessors_Include = 25,               // <Preprocessors> ::= include
        @Preprocessor_Num = 26,                    // <Preprocessor> ::= '#' <Preprocessors>
        @Pp_statement = 27,                        // <PP_Statement> ::= <Preprocessor> <Literal>
        @Pp_statement_Lt_Gt = 28,                  // <PP_Statement> ::= <Preprocessor> '<' <File> '>'
        @Pp_statement_Template = 29,               // <PP_Statement> ::= <Preprocessor> Template
        @File = 30,                                // <File> ::= <Qualified ID> <File>
        @File_Div = 31,                            // <File> ::= '/' <Qualified ID> <File>
        @File_Minus = 32,                          // <File> ::= '-' <Qualified ID> <File>
        @File_Dot = 33,                            // <File> ::= '.' <Qualified ID> <File>
        @File2 = 34,                               // <File> ::= 
        @Qualifiedidlist = 35,                     // <Qualified ID List> ::= <Qualified ID> <Qualified ID List>
        @Qualifiedidlist2 = 36,                    // <Qualified ID List> ::= <Qualified ID>
        @Using_Using_Semi = 37,                    // <Using> ::= using <Qualified ID List> ';'
        @Using_Using_Semi2 = 38,                   // <Using> ::= using <Qualified ID List> <Literal> ';'
        @Using_Using_Namespace_Semi = 39,          // <Using> ::= using namespace <Qualified ID List> ';'
        @Literal_Decliteral = 40,                  // <Literal> ::= DecLiteral
        @Literal_Octliteral = 41,                  // <Literal> ::= OctLiteral
        @Literal_Hexliteral = 42,                  // <Literal> ::= HexLiteral
        @Literal_Floatliteral = 43,                // <Literal> ::= FloatLiteral
        @Literal_Stringliteral = 44,               // <Literal> ::= StringLiteral
        @Literal_Charliteral = 45,                 // <Literal> ::= CharLiteral
        @Semiopt_Semi = 46,                        // <Semi Opt> ::= ';'
        @Semiopt = 47,                             // <Semi Opt> ::= 
        @Label_Colon = 48,                         // <Label> ::= <Mod List> ':'
        @Pointersreq_Times = 49,                   // <Pointers Req> ::= '*' <Pointers Req>
        @Pointersreq_Times2 = 50,                  // <Pointers Req> ::= '*'
        @Addressreq_Amp = 51,                      // <Address Req> ::= '&' <Address Req>
        @Addressreq_Amp2 = 52,                     // <Address Req> ::= '&'
        @Funcproto_Lparan_Rparan_Semi = 53,        // <Func Proto> ::= <Func ID> '(' <Params> ')' ';'
        @Funcproto_Lparan_Rparan_Semi2 = 54,       // <Func Proto> ::= <Func ID> '(' ')' ';'
        @Funcproto_Lparan_Rparan_Eq_Semi = 55,     // <Func Proto> ::= <Func ID> '(' <Params> ')' '=' <Op If> ';'
        @Funcproto_Lparan_Rparan_Eq_Semi2 = 56,    // <Func Proto> ::= <Func ID> '(' ')' '=' <Op If> ';'
        @Funcproto_Lparan_Rparan_Lparan_Rparan_Semi = 57,  // <Func Proto> ::= <Func ID> '(' <Pointers Req> <Expr> ')' '(' <Params> ')' ';'
        @Funcproto_Lparan_Rparan_Lparan_Rparan_Semi2 = 58,  // <Func Proto> ::= <Func ID> '(' <Pointers Req> <Expr> ')' '(' ')' ';'
        @Funcproto_Lparan_Rparan_Lparan_Rparan_Eq_Semi = 59,  // <Func Proto> ::= <Func ID> '(' <Pointers Req> <Expr> ')' '(' <Params> ')' '=' <Op If> ';'
        @Funcproto_Lparan_Rparan_Lparan_Rparan_Eq_Semi2 = 60,  // <Func Proto> ::= <Func ID> '(' <Pointers Req> <Expr> ')' '(' ')' '=' <Op If> ';'
        @Funcdecl_Lparan_Rparan = 61,              // <Func Decl> ::= <Func ID> '(' <Params> ')' <Mod List Opt> <Base Opt> <Block>
        @Funcdecl_Lparan_Rparan2 = 62,             // <Func Decl> ::= <Func ID> '(' <Params> ')' <Mod List Opt> <Struct Def> <Block>
        @Funcdecl_Lparan_Rparan3 = 63,             // <Func Decl> ::= <Func ID> '(' ')' <Mod List Opt> <Base Opt> <Block>
        @Funcdecl_Lparan_Rparan_Lparan_Rparan = 64,  // <Func Decl> ::= <Func ID> '(' <Pointers Req> <Expr> ')' '(' <Params> ')' <Mod List Opt> <Base Opt> <Block>
        @Funcdecl_Lparan_Rparan_Lparan_Rparan2 = 65,  // <Func Decl> ::= <Func ID> '(' <Pointers Req> <Expr> ')' '(' <Params> ')' <Mod List Opt> <Struct Def> <Block>
        @Funcdecl_Lparan_Rparan_Lparan_Rparan3 = 66,  // <Func Decl> ::= <Func ID> '(' <Pointers Req> <Expr> ')' '(' ')' <Mod List Opt> <Base Opt> <Block>
        @Baseopt_Colon = 67,                       // <Base Opt> ::= ':' <Base Funct List>
        @Baseopt = 68,                             // <Base Opt> ::= 
        @Modlistopt = 69,                          // <Mod List Opt> ::= <Mod List>
        @Modlistopt2 = 70,                         // <Mod List Opt> ::= 
        @Basefunctlist_Comma = 71,                 // <Base Funct List> ::= <Base Funct> ',' <Base Funct List>
        @Basefunctlist = 72,                       // <Base Funct List> ::= <Base Funct>
        @Basefunct_Lparan_Rparan = 73,             // <Base Funct> ::= <Func ID> '(' <Params> ')'
        @Basefunct_Lparan_Rparan2 = 74,            // <Base Funct> ::= <Func ID> '(' ')'
        @Destructor_Tilde = 75,                    // <Destructor> ::= '~' <Func Decl>
        @Destructor_Tilde2 = 76,                   // <Destructor> ::= '~' <Func Proto>
        @Destructor_Tilde3 = 77,                   // <Destructor> ::= <Qualified ID> '~' <Func Decl>
        @Destructor_Tilde4 = 78,                   // <Destructor> ::= <Qualified ID> '~' <Func Proto>
        @Destructor_Tilde5 = 79,                   // <Destructor> ::= <Mod List> '~' <Func Decl>
        @Destructor_Tilde6 = 80,                   // <Destructor> ::= <Mod List> '~' <Func Proto>
        @Destructor_Tilde7 = 81,                   // <Destructor> ::= <Mod List> <Qualified ID> '~' <Func Decl>
        @Destructor_Tilde8 = 82,                   // <Destructor> ::= <Mod List> <Qualified ID> '~' <Func Proto>
        @Params_Comma = 83,                        // <Params> ::= <Param> ',' <Params>
        @Params = 84,                              // <Params> ::= <Param>
        @Param = 85,                               // <Param> ::= <Mod List> <Type> <Qualified ID> <Pointers> <Array>
        @Param2 = 86,                              // <Param> ::= <Mod List> <Type> <Mod List> <Qualified ID> <Pointers> <Array>
        @Param3 = 87,                              // <Param> ::= <Type> <Qualified ID> <Pointers> <Array>
        @Param4 = 88,                              // <Param> ::= <Type> <Address Req> <Qualified ID> <Pointers> <Array>
        @Param5 = 89,                              // <Param> ::= <Mod List> <Qualified ID> <Qualified ID> <Array>
        @Param6 = 90,                              // <Param> ::= <Mod List> <Qualified ID> <Pointers Req> <Qualified ID> <Array>
        @Param7 = 91,                              // <Param> ::= <Mod List> <Qualified ID> <Address Req> <Qualified ID> <Array>
        @Param8 = 92,                              // <Param> ::= <Qualified ID> <Qualified ID> <Array>
        @Param_Lparan_Rparan_Lparan_Rparan = 93,   // <Param> ::= <Type> '(' <Pointers Req> <Qualified ID> ')' '(' <Type> ')'
        @Param_Lparan_Rparan_Lparan_Rparan2 = 94,  // <Param> ::= '(' <Pointers Req> <Qualified ID> ')' '(' <Type> ')'
        @Param9 = 95,                              // <Param> ::= <Address Req> <Qualified ID>
        @Param10 = 96,                             // <Param> ::= <Mod List> <Type> <Array>
        @Param11 = 97,                             // <Param> ::= <Mod List> <Type> <Mod List> <Array>
        @Param12 = 98,                             // <Param> ::= <Type> <Array>
        @Param13 = 99,                             // <Param> ::= <Mod List> <Qualified ID> <Pointers> <Array>
        @Param14 = 100,                            // <Param> ::= <Qualified ID> <Pointers> <Array>
        @Param15 = 101,                            // <Param> ::= <Qualified ID> <Pointers Req> <Qualified ID> <Array>
        @Param16 = 102,                            // <Param> ::= <Qualified ID> <Address Req> <Qualified ID> <Array>
        @Param_Dot = 103,                          // <Param> ::= <Qualified ID> '.' <Value>
        @Param_Minusgt = 104,                      // <Param> ::= <Qualified ID> '->' <Value>
        @Param_Eq = 105,                           // <Param> ::= <Mod List> <Type> <Qualified ID> <Pointers> <Array> '=' <Op If>
        @Param_Eq2 = 106,                          // <Param> ::= <Type> <Qualified ID> <Pointers> <Array> '=' <Op If>
        @Param_Eq3 = 107,                          // <Param> ::= <Type> <Address Req> <Qualified ID> <Pointers> <Array> '=' <Op If>
        @Param_Eq4 = 108,                          // <Param> ::= <Mod List> <Qualified ID> <Qualified ID> <Array> '=' <Op If>
        @Param_Eq5 = 109,                          // <Param> ::= <Mod List> <Qualified ID> <Pointers Req> <Qualified ID> <Array> '=' <Op If>
        @Param_Eq6 = 110,                          // <Param> ::= <Qualified ID> <Qualified ID> <Array> '=' <Op If>
        @Param_Eq7 = 111,                          // <Param> ::= <Mod List> <Type> <Array> '=' <Op If>
        @Param_Eq8 = 112,                          // <Param> ::= <Type> <Array> '=' <Op If>
        @Param_Eq9 = 113,                          // <Param> ::= <Mod List> <Qualified ID> <Pointers> <Array> '=' <Op If>
        @Param_Eq10 = 114,                         // <Param> ::= <Qualified ID> <Pointers> <Array> '=' <Op If>
        @Param_Eq11 = 115,                         // <Param> ::= <Qualified ID> <Pointers Req> <Qualified ID> <Array> '=' <Op If>
        @Param_Dot_Eq = 116,                       // <Param> ::= <Qualified ID> '.' <Value> '=' <Op If>
        @Param_Minusgt_Eq = 117,                   // <Param> ::= <Qualified ID> '->' <Value> '=' <Op If>
        @Funcid = 118,                             // <Func ID> ::= <Mod List> <Type> <Qualified ID>
        @Funcid2 = 119,                            // <Func ID> ::= <Mod List> <Qualified ID> <Qualified ID>
        @Funcid3 = 120,                            // <Func ID> ::= <Mod List> <Qualified ID> <Pointers Req> <Qualified ID>
        @Funcid4 = 121,                            // <Func ID> ::= <Mod List> <Qualified ID> <Qualified ID> <Pointers Req> <Qualified ID>
        @Funcid5 = 122,                            // <Func ID> ::= <Type> <Qualified ID>
        @Funcid6 = 123,                            // <Func ID> ::= <Type> <Address Req> <Qualified ID>
        @Funcid7 = 124,                            // <Func ID> ::= <Type> <Qualified ID> <Qualified ID>
        @Funcid8 = 125,                            // <Func ID> ::= <Qualified ID> <Qualified ID>
        @Funcid9 = 126,                            // <Func ID> ::= <Qualified ID> <Pointers Req> <Qualified ID>
        @Funcid10 = 127,                           // <Func ID> ::= <Qualified ID> <Address Req> <Qualified ID>
        @Funcid11 = 128,                           // <Func ID> ::= <Qualified ID> <Qualified ID> <Pointers Req> <Qualified ID>
        @Funcid12 = 129,                           // <Func ID> ::= <Qualified ID>
        @Funcid13 = 130,                           // <Func ID> ::= <Qualified ID> <Address Req>
        @Funcid14 = 131,                           // <Func ID> ::= <Mod List> <Type>
        @Funcid15 = 132,                           // <Func ID> ::= <Mod List>
        @Funcid16 = 133,                           // <Func ID> ::= <Mod List> <Pointers Req>
        @Funcid17 = 134,                           // <Func ID> ::= <Type>
        @Funcid18 = 135,                           // <Func ID> ::= <Mod List> <Qualified ID>
        @Funcid19 = 136,                           // <Func ID> ::= <Mod List> <Qualified ID> <Pointers Req>
        @Funcid20 = 137,                           // <Func ID> ::= <Qualified ID> <Qualified ID> <Pointers Req>
        @Funcid21 = 138,                           // <Func ID> ::= <Qualified ID> <Pointers Req>
        @Typedefdecl_Typedef_Semi = 139,           // <Typedef Decl> ::= typedef <Type> <Qualified ID> ';'
        @Typedefdecl_Typedef = 140,                // <Typedef Decl> ::= typedef <Func Proto>
        @Typedefdecl_Typedef_Semi2 = 141,          // <Typedef Decl> ::= typedef <Qualified ID> <Qualified ID> ';'
        @Stuctproto_Struct_Semi = 142,             // <Stuct Proto> ::= struct <Qualified ID> ';'
        @Stuctproto_Struct_Semi2 = 143,            // <Stuct Proto> ::= <Mod List> struct <Qualified ID> ';'
        @Structdecl_Typedef_Struct_Lbrace_Rbrace = 144,  // <Struct Decl> ::= typedef struct <Qualified ID> <Class Base Opt> '{' <Struct Def> '}' <Semi Opt>
        @Structdecl_Struct_Lbrace_Rbrace = 145,    // <Struct Decl> ::= struct <Qualified ID> <Class Base Opt> '{' <Struct Def> '}' <Semi Opt>
        @Structdecl_Typedef_Struct_Lbrace_Rbrace_Semi = 146,  // <Struct Decl> ::= typedef struct <Qualified ID> <Class Base Opt> '{' <Struct Def> '}' <Expr> ';'
        @Structdecl_Struct_Lbrace_Rbrace_Semi = 147,  // <Struct Decl> ::= struct <Qualified ID> <Class Base Opt> '{' <Struct Def> '}' <Expr> ';'
        @Structdecl_Typedef_Struct_Lbrace_Rbrace2 = 148,  // <Struct Decl> ::= <Mod List> typedef struct <Qualified ID> <Class Base Opt> '{' <Struct Def> '}' <Semi Opt>
        @Structdecl_Struct_Lbrace_Rbrace2 = 149,   // <Struct Decl> ::= <Mod List> struct <Qualified ID> <Class Base Opt> '{' <Struct Def> '}' <Semi Opt>
        @Structdecl_Typedef_Struct_Lbrace_Rbrace_Semi2 = 150,  // <Struct Decl> ::= <Mod List> typedef struct <Qualified ID> <Class Base Opt> '{' <Struct Def> '}' <Expr> ';'
        @Structdecl_Struct_Lbrace_Rbrace_Semi2 = 151,  // <Struct Decl> ::= <Mod List> struct <Qualified ID> <Class Base Opt> '{' <Struct Def> '}' <Expr> ';'
        @Classproto_Class_Semi = 152,              // <Class Proto> ::= class <Qualified ID> ';'
        @Classproto_Class_Semi2 = 153,             // <Class Proto> ::= <Mod List> class <Qualified ID> ';'
        @Classdecl_Class_Lbrace_Rbrace = 154,      // <Class Decl> ::= class <Qualified ID> <Class Base Opt> '{' <Class Body> '}' <Semi Opt>
        @Classdecl_Class_Lbrace_Rbrace2 = 155,     // <Class Decl> ::= <Mod List> class <Qualified ID> <Class Base Opt> '{' <Class Body> '}' <Semi Opt>
        @Classdecl_Class_Lbrace_Rbrace_Semi = 156,  // <Class Decl> ::= class <Qualified ID> <Class Base Opt> '{' <Class Body> '}' <Expr> ';'
        @Classdecl_Class_Lbrace_Rbrace_Semi2 = 157,  // <Class Decl> ::= <Mod List> class <Qualified ID> <Class Base Opt> '{' <Class Body> '}' <Expr> ';'
        @Classbaseopt_Colon = 158,                 // <Class Base Opt> ::= ':' <Class Base List>
        @Classbaseopt = 159,                       // <Class Base Opt> ::= 
        @Classbaselist_Comma = 160,                // <Class Base List> ::= <Class Base> ',' <Class Base List>
        @Classbaselist = 161,                      // <Class Base List> ::= <Class Base>
        @Classbase = 162,                          // <Class Base> ::= <Mod List> <Qualified ID>
        @Classbase2 = 163,                         // <Class Base> ::= <Qualified ID>
        @Namespaceproto_Namespace_Semi = 164,      // <Namespace Proto> ::= namespace <Qualified ID> ';'
        @Namespaceproto_Namespace_Semi2 = 165,     // <Namespace Proto> ::= <Mod List> namespace <Qualified ID> ';'
        @Namespacedecl_Namespace_Lbrace_Rbrace = 166,  // <Namespace Decl> ::= namespace <Qualified ID> '{' <Namespace Body> '}' <Semi Opt>
        @Namespacedecl_Namespace_Lbrace_Rbrace2 = 167,  // <Namespace Decl> ::= <Mod List> namespace <Qualified ID> '{' <Namespace Body> '}' <Semi Opt>
        @Namespacedecl_Namespace_Lbrace_Rbrace3 = 168,  // <Namespace Decl> ::= namespace '{' <Namespace Body> '}' <Semi Opt>
        @Namespacedecl_Namespace_Lbrace_Rbrace4 = 169,  // <Namespace Decl> ::= <Mod List> namespace '{' <Namespace Body> '}' <Semi Opt>
        @Uniondecl_Typedef_Union_Lbrace_Rbrace_Semi = 170,  // <Union Decl> ::= typedef union <Qualified ID> '{' <Struct Def> '}' ';'
        @Uniondecl_Typedef_Union_Lbrace_Rbrace_Semi2 = 171,  // <Union Decl> ::= typedef union <Qualified ID> '{' <Struct Def> '}' <Qualified ID> ';'
        @Uniondecl_Union_Lbrace_Rbrace_Semi = 172,  // <Union Decl> ::= union <Qualified ID> '{' <Struct Def> '}' ';'
        @Uniondecl_Typedef_Union_Lbrace_Rbrace_Semi3 = 173,  // <Union Decl> ::= <Mod List> typedef union <Qualified ID> '{' <Struct Def> '}' ';'
        @Uniondecl_Typedef_Union_Lbrace_Rbrace_Semi4 = 174,  // <Union Decl> ::= <Mod List> typedef union <Qualified ID> '{' <Struct Def> '}' <Qualified ID> ';'
        @Uniondecl_Union_Lbrace_Rbrace_Semi2 = 175,  // <Union Decl> ::= <Mod List> union <Qualified ID> '{' <Struct Def> '}' ';'
        @Classbody = 176,                          // <Class Body> ::= <Decls>
        @Namespacebody = 177,                      // <Namespace Body> ::= <Decls>
        @Structdef = 178,                          // <Struct Def> ::= <Var Decl> <Struct Def>
        @Structdef2 = 179,                         // <Struct Def> ::= <Var Decl>
        @Structdef3 = 180,                         // <Struct Def> ::= <Func Decl> <Struct Def>
        @Structdef4 = 181,                         // <Struct Def> ::= <Func Decl>
        @Structdef5 = 182,                         // <Struct Def> ::= <Func Proto> <Struct Def>
        @Structdef6 = 183,                         // <Struct Def> ::= <Func Proto>
        @Structdef_Colon_Semi = 184,               // <Struct Def> ::= <Type> <Qualified ID> ':' <Literal> ';' <Struct Def>
        @Structdef_Colon_Semi2 = 185,              // <Struct Def> ::= <Type> <Qualified ID> ':' <Literal> ';'
        @Vardecl = 186,                            // <Var Decl> ::= <Mod List> <Type> <Var Reference>
        @Vardecl2 = 187,                           // <Var Decl> ::= <Mod List> <Type> <Mod List> <Var Reference>
        @Vardecl3 = 188,                           // <Var Decl> ::= <Type> <Var Reference>
        @Vardecl4 = 189,                           // <Var Decl> ::= <Type> <Qualified ID> <Pointers Req> <Var Reference>
        @Vardecl5 = 190,                           // <Var Decl> ::= <Mod List> <Var Reference>
        @Vardecl6 = 191,                           // <Var Decl> ::= <Mod List> <Qualified ID> <Var Reference>
        @Vardecl7 = 192,                           // <Var Decl> ::= <Mod List> <Qualified ID> <Pointers Req> <Var Reference>
        @Vardecl8 = 193,                           // <Var Decl> ::= <Mod List> <Qualified ID> <Address Req> <Var Reference>
        @Vardecl9 = 194,                           // <Var Decl> ::= <Qualified ID> <Var Reference>
        @Vardecl10 = 195,                          // <Var Decl> ::= <Qualified ID> <Pointers Req> <Var Reference>
        @Varreference_Semi = 196,                  // <Var Reference> ::= <Var> <Var List> ';'
        @Var = 197,                                // <Var> ::= <Qualified ID> <Pointers> <Array>
        @Var_Eq = 198,                             // <Var> ::= <Qualified ID> <Pointers> <Array> '=' <Array Init or Op If>
        @Array_Lbracket_Rbracket = 199,            // <Array> ::= <Array> '[' <Expr> ']'
        @Array_Lbracket_Rbracket2 = 200,           // <Array> ::= <Array> '[' ']'
        @Array = 201,                              // <Array> ::= 
        @Arrayinitoropif_Lbrace_Rbrace = 202,      // <Array Init or Op If> ::= '{' <Array Init> '}'
        @Arrayinitoropif = 203,                    // <Array Init or Op If> ::= <Op If>
        @Arrayinitoropif2 = 204,                   // <Array Init or Op If> ::= <Op If> <Array Init or Op If>
        @Arrayinit_Comma = 205,                    // <Array Init> ::= <Array Item> ',' <Array Init>
        @Arrayinit_Lbrace_Rbrace_Comma = 206,      // <Array Init> ::= '{' <Array Init> '}' ',' <Array Init>
        @Arrayinit_Lbrace_Rbrace = 207,            // <Array Init> ::= '{' <Array Init> '}'
        @Arrayinit = 208,                          // <Array Init> ::= <Array Item>
        @Arrayitem = 209,                          // <Array Item> ::= <Op If>
        @Arrayitem2 = 210,                         // <Array Item> ::= 
        @Varlist_Comma = 211,                      // <Var List> ::= ',' <Var Item> <Var List>
        @Varlist = 212,                            // <Var List> ::= 
        @Varitem = 213,                            // <Var Item> ::= <Pointers> <Var>
        @Modlist = 214,                            // <Mod List> ::= <Mod List> <Mod>
        @Modlist2 = 215,                           // <Mod List> ::= <Mod>
        @Mod_Extern = 216,                         // <Mod> ::= extern
        @Mod_Static = 217,                         // <Mod> ::= static
        @Mod_Register = 218,                       // <Mod> ::= register
        @Mod_Auto = 219,                           // <Mod> ::= auto
        @Mod_Volatile = 220,                       // <Mod> ::= volatile
        @Mod_Const = 221,                          // <Mod> ::= const
        @Mod_Public = 222,                         // <Mod> ::= public
        @Mod_Private = 223,                        // <Mod> ::= private
        @Mod_Protected = 224,                      // <Mod> ::= protected
        @Mod_Mutable = 225,                        // <Mod> ::= mutable
        @Mod_Friend = 226,                         // <Mod> ::= friend
        @Mod_Inline = 227,                         // <Mod> ::= inline
        @Mod_Virtual = 228,                        // <Mod> ::= virtual
        @Enumdecl_Enum_Lbrace_Rbrace_Semi = 229,   // <Enum Decl> ::= enum <Qualified ID> '{' <Enum Def> '}' ';'
        @Enumdecl_Enum_Lbrace_Rbrace_Semi2 = 230,  // <Enum Decl> ::= enum <Qualified ID> '{' <Enum Def> '}' <Qualified ID> ';'
        @Enumdecl_Enum_Lbrace_Rbrace_Semi3 = 231,  // <Enum Decl> ::= enum '{' <Enum Def> '}' ';'
        @Enumdecl_Enum_Lbrace_Rbrace_Semi4 = 232,  // <Enum Decl> ::= enum '{' <Enum Def> '}' <Qualified ID> ';'
        @Enumdecl_Enum_Lbrace_Rbrace_Semi5 = 233,  // <Enum Decl> ::= <Mod List> enum <Qualified ID> '{' <Enum Def> '}' ';'
        @Enumdecl_Enum_Lbrace_Rbrace_Semi6 = 234,  // <Enum Decl> ::= <Mod List> enum <Qualified ID> '{' <Enum Def> '}' <Qualified ID> ';'
        @Enumdecl_Enum_Lbrace_Rbrace_Semi7 = 235,  // <Enum Decl> ::= <Mod List> enum '{' <Enum Def> '}' ';'
        @Enumdecl_Enum_Lbrace_Rbrace_Semi8 = 236,  // <Enum Decl> ::= <Mod List> enum '{' <Enum Def> '}' <Qualified ID> ';'
        @Enumdef_Comma = 237,                      // <Enum Def> ::= <Enum Val> ',' <Enum Def>
        @Enumdef = 238,                            // <Enum Def> ::= <Enum Val>
        @Enumval = 239,                            // <Enum Val> ::= <Qualified ID>
        @Enumval_Eq = 240,                         // <Enum Val> ::= <Qualified ID> '=' <Op If>
        @Type = 241,                               // <Type> ::= <Base> <Mod List> <Pointers Req>
        @Type2 = 242,                              // <Type> ::= <Base> <Mod List>
        @Type3 = 243,                              // <Type> ::= <Base> <Pointers Req>
        @Type4 = 244,                              // <Type> ::= <Base>
        @Base = 245,                               // <Base> ::= <Sign> <Scalar List>
        @Base2 = 246,                              // <Base> ::= <Sign Req>
        @Base_Struct = 247,                        // <Base> ::= struct <Qualified ID>
        @Base_Struct2 = 248,                       // <Base> ::= struct <Address Req> <Qualified ID>
        @Base_Struct3 = 249,                       // <Base> ::= struct <Pointers Req> <Qualified ID>
        @Base_Struct_Lbrace_Rbrace = 250,          // <Base> ::= struct '{' <Struct Def> '}'
        @Base_Class = 251,                         // <Base> ::= class <Qualified ID>
        @Base_Class_Lbrace_Rbrace = 252,           // <Base> ::= class '{' <Struct Def> '}'
        @Base_Union = 253,                         // <Base> ::= union <Qualified ID>
        @Base_Union_Lbrace_Rbrace = 254,           // <Base> ::= union '{' <Struct Def> '}'
        @Base_Enum = 255,                          // <Base> ::= enum <Qualified ID>
        @Base_Enum2 = 256,                         // <Base> ::= enum <Address Req> <Qualified ID>
        @Base_Enum3 = 257,                         // <Base> ::= enum <Pointers Req> <Qualified ID>
        @Base_Enum_Lbrace_Rbrace = 258,            // <Base> ::= enum '{' <Enum Def> '}'
        @Signreq_Signed = 259,                     // <Sign Req> ::= signed
        @Signreq_Unsigned = 260,                   // <Sign Req> ::= unsigned
        @Sign_Signed = 261,                        // <Sign> ::= signed
        @Sign_Unsigned = 262,                      // <Sign> ::= unsigned
        @Sign = 263,                               // <Sign> ::= 
        @Scalarlist = 264,                         // <Scalar List> ::= <Scalar> <Scalar List>
        @Scalarlist2 = 265,                        // <Scalar List> ::= <Scalar>
        @Scalar_Char = 266,                        // <Scalar> ::= char
        @Scalar_Int = 267,                         // <Scalar> ::= int
        @Scalar_Short = 268,                       // <Scalar> ::= short
        @Scalar_Long = 269,                        // <Scalar> ::= long
        @Scalar_Float = 270,                       // <Scalar> ::= float
        @Scalar_Double = 271,                      // <Scalar> ::= double
        @Scalar_Void = 272,                        // <Scalar> ::= void
        @Scalar_Bool = 273,                        // <Scalar> ::= bool
        @Pointers_Times = 274,                     // <Pointers> ::= '*' <Pointers>
        @Pointers_Amp = 275,                       // <Pointers> ::= '&' <Pointers>
        @Pointers = 276,                           // <Pointers> ::= 
        @Stm = 277,                                // <Stm> ::= <Var Decl>
        @Stm_Colon = 278,                          // <Stm> ::= <Qualified ID> ':'
        @Stm_If_Lparan_Rparan = 279,               // <Stm> ::= if '(' <Expr> ')' <Stm>
        @Stm_If_Lparan_Rparan_Else = 280,          // <Stm> ::= if '(' <Expr> ')' <Then Stm> else <Stm>
        @Stm_While_Lparan_Rparan = 281,            // <Stm> ::= while '(' <Expr> ')' <Stm>
        @Stm_For_Lparan_Semi_Semi_Rparan = 282,    // <Stm> ::= for '(' <Arg> ';' <Arg> ';' <Arg> ')' <Stm>
        @Stm2 = 283,                               // <Stm> ::= <Normal Stm>
        @Thenstm_If_Lparan_Rparan_Else = 284,      // <Then Stm> ::= if '(' <Expr> ')' <Then Stm> else <Then Stm>
        @Thenstm_While_Lparan_Rparan = 285,        // <Then Stm> ::= while '(' <Expr> ')' <Then Stm>
        @Thenstm_For_Lparan_Semi_Semi_Rparan = 286,  // <Then Stm> ::= for '(' <Arg> ';' <Arg> ';' <Arg> ')' <Then Stm>
        @Thenstm = 287,                            // <Then Stm> ::= <Normal Stm>
        @Normalstm = 288,                          // <Normal Stm> ::= <Typedef Decl>
        @Normalstm_Lparan_Rparan_Semi = 289,       // <Normal Stm> ::= <Func ID> '(' <Params> ')' ';'
        @Normalstm_Lparan_Rparan_Semi2 = 290,      // <Normal Stm> ::= <Func ID> '(' ')' ';'
        @Normalstm_Lparan_Rparan_Lparan_Rparan_Semi = 291,  // <Normal Stm> ::= <Func ID> '(' <Pointers Req> <Expr> ')' '(' <Params> ')' ';'
        @Normalstm_Lparan_Rparan_Lparan_Rparan_Semi2 = 292,  // <Normal Stm> ::= <Func ID> '(' <Pointers Req> <Expr> ')' '(' ')' ';'
        @Normalstm_Do_While_Lparan_Rparan = 293,   // <Normal Stm> ::= do <Stm> while '(' <Expr> ')'
        @Normalstm_Switch_Lparan_Rparan_Lbrace_Rbrace = 294,  // <Normal Stm> ::= switch '(' <Expr> ')' '{' <Case Stms> '}'
        @Normalstm2 = 295,                         // <Normal Stm> ::= <Block>
        @Normalstm_Semi = 296,                     // <Normal Stm> ::= <Expr> ';'
        @Normalstm_Goto_Id_Semi = 297,             // <Normal Stm> ::= goto Id ';'
        @Normalstm_Break_Semi = 298,               // <Normal Stm> ::= break ';'
        @Normalstm_Continue_Semi = 299,            // <Normal Stm> ::= continue ';'
        @Normalstm_Return_Semi = 300,              // <Normal Stm> ::= return <Expr> ';'
        @Normalstm_Return_Semi2 = 301,             // <Normal Stm> ::= return ';'
        @Normalstm_Semi2 = 302,                    // <Normal Stm> ::= ';'
        @Arg = 303,                                // <Arg> ::= <Expr>
        @Arg2 = 304,                               // <Arg> ::= <Type> <Var>
        @Arg3 = 305,                               // <Arg> ::= <Qualified ID> <Var>
        @Arg4 = 306,                               // <Arg> ::= 
        @Casestms_Case_Colon = 307,                // <Case Stms> ::= case <Value> ':' <Stm List> <Case Stms>
        @Casestms_Case_Minus_Colon = 308,          // <Case Stms> ::= case '-' <Value> ':' <Stm List> <Case Stms>
        @Casestms_Default_Colon = 309,             // <Case Stms> ::= default ':' <Stm List>
        @Casestms = 310,                           // <Case Stms> ::= 
        @Block_Lbrace_Rbrace = 311,                // <Block> ::= '{' <Stm List> '}' <Semi Opt>
        @Stmlist = 312,                            // <Stm List> ::= <Stm> <Stm List>
        @Stmlist2 = 313,                           // <Stm List> ::= 
        @Expr_Comma = 314,                         // <Expr> ::= <Expr> ',' <Op Assign>
        @Expr = 315,                               // <Expr> ::= <Op Assign>
        @Opassign_Eq = 316,                        // <Op Assign> ::= <Op If> '=' <Op Assign>
        @Opassign_Pluseq = 317,                    // <Op Assign> ::= <Op If> '+=' <Op Assign>
        @Opassign_Minuseq = 318,                   // <Op Assign> ::= <Op If> '-=' <Op Assign>
        @Opassign_Timeseq = 319,                   // <Op Assign> ::= <Op If> '*=' <Op Assign>
        @Opassign_Diveq = 320,                     // <Op Assign> ::= <Op If> '/=' <Op Assign>
        @Opassign_Careteq = 321,                   // <Op Assign> ::= <Op If> '^=' <Op Assign>
        @Opassign_Ampeq = 322,                     // <Op Assign> ::= <Op If> '&=' <Op Assign>
        @Opassign_Pipeeq = 323,                    // <Op Assign> ::= <Op If> '|=' <Op Assign>
        @Opassign_Gtgteq = 324,                    // <Op Assign> ::= <Op If> '>>=' <Op Assign>
        @Opassign_Ltlteq = 325,                    // <Op Assign> ::= <Op If> '<<=' <Op Assign>
        @Opassign = 326,                           // <Op Assign> ::= <Op If>
        @Opif_Question_Colon = 327,                // <Op If> ::= <Op Or> '?' <Op If> ':' <Op If>
        @Opif = 328,                               // <Op If> ::= <Op Or>
        @Opor_Pipepipe = 329,                      // <Op Or> ::= <Op Or> '||' <Op And>
        @Opor = 330,                               // <Op Or> ::= <Op And>
        @Opand_Ampamp = 331,                       // <Op And> ::= <Op And> '&&' <Op BinOR>
        @Opand = 332,                              // <Op And> ::= <Op BinOR>
        @Opbinor_Pipe = 333,                       // <Op BinOR> ::= <Op BinOR> '|' <Op BinXOR>
        @Opbinor = 334,                            // <Op BinOR> ::= <Op BinXOR>
        @Opbinxor_Caret = 335,                     // <Op BinXOR> ::= <Op BinXOR> '^' <Op BinAND>
        @Opbinxor = 336,                           // <Op BinXOR> ::= <Op BinAND>
        @Opbinand_Amp = 337,                       // <Op BinAND> ::= <Op BinAND> '&' <Op Equate>
        @Opbinand = 338,                           // <Op BinAND> ::= <Op Equate>
        @Opequate_Eqeq = 339,                      // <Op Equate> ::= <Op Equate> '==' <Op Compare>
        @Opequate_Exclameq = 340,                  // <Op Equate> ::= <Op Equate> '!=' <Op Compare>
        @Opequate = 341,                           // <Op Equate> ::= <Op Compare>
        @Opcompare_Lt = 342,                       // <Op Compare> ::= <Op Compare> '<' <Op Shift>
        @Opcompare_Gt = 343,                       // <Op Compare> ::= <Op Compare> '>' <Op Shift>
        @Opcompare_Lteq = 344,                     // <Op Compare> ::= <Op Compare> '<=' <Op Shift>
        @Opcompare_Gteq = 345,                     // <Op Compare> ::= <Op Compare> '>=' <Op Shift>
        @Opcompare = 346,                          // <Op Compare> ::= <Op Shift>
        @Opshift_Ltlt = 347,                       // <Op Shift> ::= <Op Shift> '<<' <Op Add>
        @Opshift_Gtgt = 348,                       // <Op Shift> ::= <Op Shift> '>>' <Op Add>
        @Opshift = 349,                            // <Op Shift> ::= <Op Add>
        @Opadd_Plus = 350,                         // <Op Add> ::= <Op Add> '+' <Op Mult>
        @Opadd_Minus = 351,                        // <Op Add> ::= <Op Add> '-' <Op Mult>
        @Opadd = 352,                              // <Op Add> ::= <Op Mult>
        @Opmult_Times = 353,                       // <Op Mult> ::= <Op Mult> '*' <Op Unary>
        @Opmult_Div = 354,                         // <Op Mult> ::= <Op Mult> '/' <Op Unary>
        @Opmult_Percent = 355,                     // <Op Mult> ::= <Op Mult> '%' <Op Unary>
        @Opmult = 356,                             // <Op Mult> ::= <Op Unary>
        @Opunary_Exclam = 357,                     // <Op Unary> ::= '!' <Op Unary>
        @Opunary_Tilde = 358,                      // <Op Unary> ::= '~' <Op Unary>
        @Opunary_Minus = 359,                      // <Op Unary> ::= '-' <Op Unary>
        @Opunary_Times = 360,                      // <Op Unary> ::= '*' <Op Unary>
        @Opunary_Amp = 361,                        // <Op Unary> ::= '&' <Op Unary>
        @Opunary_Plusplus = 362,                   // <Op Unary> ::= '++' <Op Unary>
        @Opunary_Minusminus = 363,                 // <Op Unary> ::= '--' <Op Unary>
        @Opunary_Plusplus2 = 364,                  // <Op Unary> ::= <Op Pointer> '++'
        @Opunary_Minusminus2 = 365,                // <Op Unary> ::= <Op Pointer> '--'
        @Opunary_Lparan_Rparan = 366,              // <Op Unary> ::= '(' <Qualified ID> ')' <Op Unary>
        @Opunary_Lparan_Rparan2 = 367,             // <Op Unary> ::= '(' <Qualified ID> ')'
        @Opunary_Lparan_Rparan3 = 368,             // <Op Unary> ::= '(' <Expr> <Pointers> ')' <Op Unary>
        @Opunary_Lparan_Rparan4 = 369,             // <Op Unary> ::= '(' <Qualified ID> <Pointers Req> ')' <Op Unary>
        @Opunary_Lparan_Times_Rparan = 370,        // <Op Unary> ::= '(' <Qualified ID> '*' <Qualified ID> ')'
        @Opunary_Lparan_Rparan5 = 371,             // <Op Unary> ::= '(' <Type> <Qualified ID> <Pointers> ')' <Op Unary>
        @Opunary_Lparan_Rparan6 = 372,             // <Op Unary> ::= '(' <Type> ')' <Op Unary>
        @Opunary_Sizeof_Lparan_Rparan = 373,       // <Op Unary> ::= sizeof '(' <Type> ')'
        @Opunary_Sizeof_Lparan_Rparan2 = 374,      // <Op Unary> ::= sizeof '(' <Expr> ')'
        @Opunary_Sizeof_Lparan_Rparan3 = 375,      // <Op Unary> ::= sizeof '(' <Qualified ID> <Pointers Req> ')'
        @Opunary = 376,                            // <Op Unary> ::= <Op Pointer>
        @Opunary_Lparan_Times_Rparan2 = 377,       // <Op Unary> ::= '(' <Qualified ID> '*' <Expr> ')'
        @Oppointer_Dot = 378,                      // <Op Pointer> ::= <Op Pointer> '.' <Value>
        @Oppointer_Minusgt = 379,                  // <Op Pointer> ::= <Op Pointer> '->' <Value>
        @Oppointer_Lbracket_Rbracket = 380,        // <Op Pointer> ::= <Op Pointer> '[' <Expr> ']'
        @Oppointer = 381,                          // <Op Pointer> ::= <Value>
        @Value_Octliteral = 382,                   // <Value> ::= OctLiteral
        @Value_Hexliteral = 383,                   // <Value> ::= HexLiteral
        @Value_Decliteral = 384,                   // <Value> ::= DecLiteral
        @Value_Stringliteral = 385,                // <Value> ::= StringLiteral
        @Value_Charliteral = 386,                  // <Value> ::= CharLiteral
        @Value_Floatliteral = 387,                 // <Value> ::= FloatLiteral
        @Value_Lparan_Rparan = 388,                // <Value> ::= <Qualified ID> <Qualified ID> '(' <Expr> <Pointers> ')'
        @Value_Lparan_Rparan2 = 389,               // <Value> ::= <Qualified ID> <Qualified ID> '(' ')'
        @Value_Lparan_Rparan3 = 390,               // <Value> ::= <Qualified ID> '(' <Expr> <Pointers> ')'
        @Value_Lparan_Rparan4 = 391,               // <Value> ::= <Qualified ID> '(' ')'
        @Value_New_Lparan_Rparan = 392,            // <Value> ::= new <Qualified ID> '(' <Expr> <Pointers> ')'
        @Value_New_Lparan_Rparan2 = 393,           // <Value> ::= new <Qualified ID> '(' ')'
        @Value_New = 394,                          // <Value> ::= new <Qualified ID> <Pointers>
        @Value_New2 = 395,                         // <Value> ::= new <Type> <Array>
        @Value_Delete = 396,                       // <Value> ::= delete <Array> <Qualified ID>
        @Value = 397,                              // <Value> ::= <Qualified ID>
        @Value_Lparan_Rparan5 = 398,               // <Value> ::= '(' <Expr> ')'
        @Value_Lparan_Rparan_Lparan_Rparan = 399,  // <Value> ::= '(' <Expr> ')' '(' <Expr> ')'
        @Value_Lparan_Rparan_Lparan_Rparan2 = 400,  // <Value> ::= '(' <Expr> ')' '(' ')'
        @Value_Lparan_Rparan6 = 401                // <Value> ::= '(' ')'
    }

}
