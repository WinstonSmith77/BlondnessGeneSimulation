// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open Random
open Bio
open System
open Logic

[<Literal>]
let numberOfBlond = 1000

[<Literal>]
let numberOfNonBlond = 16000

[<Literal>]
let numberIterations = 30000

[<Literal>]
let logEach = 100

let firstGeneration() = 
    let blondGuys = List.init numberOfBlond (fun index -> CreatePerson Feature.Has)
    let nonBlondGuys = List.init numberOfNonBlond (fun index -> CreatePerson Feature.DontHas)
    List.append blondGuys nonBlondGuys

let log start current index=
    let areBlond = HowManySatisfy IsBlond current
    
    let hasBlondGenes = HowManySatisfy HasBlondGenes current
    
    let percentageBlond = (float areBlond) / (List.length start |> float)
    let percentageBlondGenes = (float hasBlondGenes) / (List.length start |> float)
    printfn "Generation %A Blond %A BlondGenes %A" index percentageBlond percentageBlondGenes
    

[<EntryPoint>]
let main argv = 
    let start = firstGeneration()

    let createNextGeneration index current = 
        let next = nextGeneration current
        if index % logEach = 0 then
            log start next (numberIterations - index)
        next

    let current = Repeat createNextGeneration start numberIterations
    
    log start current numberIterations
    let unused = Console.ReadLine()
    0
