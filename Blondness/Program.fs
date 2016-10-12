// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open Random
open Bio
open System
open Logic

[<Literal>]
let numberOfBlond = 200000

[<Literal>]
let numberOfNonBlond = 800000

[<Literal>]
let numberIterations = 300

let firstGeneration() = 
    let blondGuys = List.init numberOfBlond (fun index -> create Feature.Has)
    let nonBlondGuys = List.init numberOfNonBlond (fun index -> create Feature.DontHas)
    List.append blondGuys nonBlondGuys

[<EntryPoint>]
let main argv = 
    let start = firstGeneration()
    let currentGeneartion = Logic.repeat (fun input -> nextGeneration input) start numberIterations
    
    let areBlond = 
        currentGeneartion
        |> List.filter Bio.isBlond
        |> List.length
    
    let hasBlondGenes = 
        currentGeneartion
        |> List.filter Bio.hasBlondGenes
        |> List.length
    
    let percentageBlond = (float areBlond) / (List.length start |> float)
    let percentageBlondGenes = (float hasBlondGenes) / (List.length start |> float)
    printfn "Blond %A BlondGenes %A" percentageBlond percentageBlondGenes
    let unused = Console.ReadLine()
    0
