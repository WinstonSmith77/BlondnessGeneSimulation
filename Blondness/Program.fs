// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open Random
open Bio
open System
open Logic

[<Literal>]
let numberOfBlond = 1000

[<Literal>]
let numberOfNonBlond = 1000

[<Literal>]
let numberIterations = 10000

let firstGeneration () = 
   
    let blondGuys = List.init numberOfBlond (fun index -> Bio.create Feature.Has)
    let nonBlondGuys = List.init numberOfNonBlond (fun index -> Bio.create Feature.DontHas)

    List.append blondGuys nonBlondGuys

[<EntryPoint>]
let main argv = 
    let start = firstGeneration()
   
    let after = Logic.repeat (fun input -> Bio.nextGeneration input) start numberIterations

    let areBlond =
        after
        |> List.filter Bio.isBlond 
        |> List.length

    let hasBlondGenes =
        after
        |> List.filter Bio.hasBlondGenes 
        |> List.length

   
    let percentageBlond = (float areBlond) / (List.length start |> float)
    let percentageBlondGenes = (float hasBlondGenes) / (List.length start |> float)
    printfn "Blond %A BlondGenes %A" percentageBlond percentageBlondGenes
    let unused = Console.ReadLine()
    0
