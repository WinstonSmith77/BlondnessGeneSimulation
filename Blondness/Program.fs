// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open Random
open Bio
open System
open Logic

[<Literal>]
let numberOfBlond = 1000

[<Literal>]
let numberOfNonBlond = 100

[<Literal>]
let numberIterations = 10000

let firstGeneration () = 
   
    let blondGuys = List.init numberOfBlond (fun index -> Bio.create Feature.Has)
    let nonBlondGuys = List.init numberOfNonBlond (fun index -> Bio.create Feature.DontHas)

    List.append blondGuys nonBlondGuys

[<EntryPoint>]
let main argv = 
    let start = firstGeneration()
    let areBlond =
        Logic.repeat (fun input -> Bio.nextGeneration input) start numberIterations
        |> List.filter Bio.isBlond 
        |> List.length

   
    let percentage = (float areBlond) / (List.length start |> float)
    printfn "%A" percentage
    let unused = Console.ReadLine()
    0
