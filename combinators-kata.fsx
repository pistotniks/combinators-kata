//combinators kata

// type Result {}

// type OK<T> : Result {
//     T value 
// public OK (T value)
//     this.value = value
// }

// type Error<T> : Result {
//     T error
//     public Error(T error)
//     {
//         this.error = error;
//     }
// }

// type Result<T> = 
// | Ok of T
// | Error

let myintOkResult = Ok 1
let mystrOkResult = Ok "itsok"
let myErrorWithInt = Error 99


printfn "%A" myintOkResult

// let name = "Adrian Who doesnt know fsharp"
// let age = 25

// let validateName (name:string) =
    


let printResult aResult =
    match aResult with
    | Ok theValueOfOk -> printfn "%A" theValueOfOk
    | Error thevalueOfError -> printfn "%A" thevalueOfError
    

printResult myintOkResult
printResult myErrorWithInt

// match <valueToDestructure> with
// | Ok <okvaluevarname> -> so something with value ....
// | Error <errorvaluevarname> -> ....



//succeed :A constructor that takes a one-track value and creates a two-track value on the Success branch.
//... In other contexts, this might also be called return or pure.
let aSwitchFunction x = 
    if (x > 3) then
        Ok x
    else 
        Error "x is smaller than 3"


let succeed x = 
    Ok x

// Result = {Ok || Error}

let myvalue = 1
succeed myvalue

//fail A constructor that takes a one-track value and creates a two-track value on the Failure branch.
let fail x =
    Error x
let createmeAAddFunction ()  =
    fun x y -> x + y
let createmeAAddFunction2 x  =
    fun y -> x + y
let createmeAAddFunction3 x y  =
    x + y


let add = createmeAAddFunction ()
add 1 1

(add 1) 2
// (craetemeAddFunction 1)  --->  ((fun y -> 1 + y ) 2) 
let addFunc () =
    let add x y = x + y
    add

//('a -> Result<'b,'c>) -> (Result<a,> -> Result <'b,'c>)
//bind	An adapter that takes a switch function and creates a new function that accepts two-track values as input.  
let bind f twoTrackInput =
    let myTwoTrackFun twoTrackInput = 
        match twoTrackInput with
        | Ok value -> f value
        | Error v -> v 
    myTwoTrackFun

let either successFn failureFn x =
    match x with 
    | Ok s -> successFn s
    | Error e -> failureFn e
        
let bind' switchFun twoTrackInput =
    match twoTrackInput with
    | Ok s -> switchFun s
    | Error e -> Error e

let bind switchFun twoTrackInput =
    either switchFun fail twoTrackInput

// let twoTInput = Ok 1
// aSwitchFunction twoTInput

let twoTInput = Ok 1
let myTwoTrackSwitch = bind aSwitchFunction
myTwoTrackSwitch twoTInput


// >>=	An infix version of bind for piping two-track values into switch functions.

// >=> Switch composition. A combiner that takes two switch functions and creates a new switch function by connecting them in series.

//switch An adapter that takes a normal one-track function and turns it into a switch function. (Also known as a "lift" in some contexts.)

//map An adapter that takes a normal one-track function and turns it into a two-track function. (Also known as a "lift" in some contexts.)

//tee	An adapter that takes a dead-end function and turns it into a one-track function that can be used in a data flow. (Also known as tap.)

//tryCatch	An adapter that takes a normal one-track function and turns it into a switch function, but also catches exceptions.

//doubleMap	An adapter that takes two one-track functions and turns them into a single two-track function. (Also known as bimap.)

//adding plus to kata

//plus	A combiner that takes two switch functions and creates a new switch function by joining them in "parallel" and "adding" the results. (Also known as ++ and <+> in other contexts.)
