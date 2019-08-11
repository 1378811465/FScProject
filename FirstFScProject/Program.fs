// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
module Program

(* 基本函数 *)

System.Console.WriteLine("基本函数阶段")

// 2次方幂函数
let square n = n * n

// lambda表达式 平方函数
let square2 = fun n -> n * n

// 递归
let anInt = 5
let rec factorial n = 
    if n = 0
    then 1
    else n * factorial (n - 1)

// 输出递归值得二次方幂值
System.Console.WriteLine(square (factorial anInt))

(* 聚合元素方式 *)

// 元组定义
let tuples = ("hello", "word", "!")

// 列表定义
let list = ["hello"; "word"; "!"]

// 向列表增加新值，需要赋给一个新的列表，原来列表值不变
let newList = "hei" :: list

System.Console.WriteLine("\n聚合元素阶段")

System.Console.WriteLine("元组")

// 输出元组
System.Console.WriteLine(tuples)

System.Console.WriteLine("列表")

// 显示旧的列表所有元素
printfn "%A" list

// 显示新的列表所有元素
printfn "%A" newList

(* 高阶函数几种类型 *)

// 高阶函数 1：可以将函数当作参数进行传值
let fun1 = fun fn arg -> fn arg

System.Console.WriteLine("\n高阶函数应用开始")
System.Console.WriteLine("高阶函数第一种类型：可以将函数当作参数进行传值")
System.Console.WriteLine(fun1 square 2)

// 高阶函数 2： 可以将函数当作返回值返回
//第一种用法
let fun2_1 = 
    fun num -> 
        let game = fun guess -> 
            if guess = num 
            then
                printfn "CORRECT VALUE %d AND GUESS VALUE %d : YOU WIN!" num guess
            else 
                printfn "CORRECT VALUE %d AND GUESS VALUE %d : YOU ERROR,AGIN GUESS!" num guess
        game

 //第二种用法
let fun2_2 = 
    fun str ->
        fun guessStr -> 
            if guessStr = str 
            then
                printfn "CORRECT VALUE %c AND GUESS VALUE %c : YOU WIN!" str guessStr
            else 
                printfn "CORRECT VALUE %c AND GUESS VALUE %c : YOU ERROR,AGIN GUESS!" str guessStr

System.Console.WriteLine("高阶函数第二种类型：可以将函数当作返回值进行返回")

System.Console.WriteLine("整数参数形式")

// 整数参数
let guessFun = fun2_1 6
guessFun 3
guessFun 4
guessFun 6

System.Console.WriteLine("字符参数形式")

// 字符参数
let guessFun2 = fun2_2 'k'
guessFun2 'a'
guessFun2 'b'
guessFun2 'k'

// 高阶函数3：可以将函数存储在数据结构中

// 元组存储 类型必须相同 存储函数时，函数定义必须相同
let funTuple = (square, fun n -> n * n)

System.Console.WriteLine(funTuple)

// 列表存储 类型可以不同
let funList = [square,anInt,10, fun n -> n * n]

System.Console.WriteLine(funList)

(* 咖喱函数(利用f#隐式计算，简便多个参数使用多个函数的情况) *)
System.Console.WriteLine("\n咖喱函数阶段")

//简化上例参数函数(隐藏了构造和返回函数的具体细节过程，但验证形式却是一样)
let guessFunSimple target guess = 
    if target = guess 
    then
        printfn "CORRECT VALUE %A AND GUESS VALUE %A : YOU WIN!" target guess
    else 
        printfn "CORRECT VALUE %A AND GUESS VALUE %A : YOU ERROR,AGIN GUESS!" target guess

//验证实例
System.Console.WriteLine("整数参数形式")

// 整数参数
let playGame1 = guessFunSimple 8
playGame1 2
playGame1 3
playGame1 8

System.Console.WriteLine("字符参数形式")

// 字符参数
let playGame2 = guessFunSimple 'k'
playGame2 'c'
playGame2 'd'
playGame2 'k'

(* 标识符和函数定义是可互换的 *)
System.Console.WriteLine("\n标识符和函数定义是可互换的")

let isNegative = fun n -> n < 10

let num = 20

// 标识符使用
System.Console.WriteLine(fun1 isNegative num)

// 函数定义来代替
System.Console.WriteLine((fun op arg -> op arg) (fun n -> n < 10) num)


(*[<EntryPoint>]
let main argv = 
    printfn "%d square and factorial is %d:" anInt (square (factorial anInt))
    0 // return an integer exit code*)