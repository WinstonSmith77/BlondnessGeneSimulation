// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open Bio
open System
open Logic

[<Literal>]
let numberOfBlond = 10000

[<Literal>]
let numberOfNonBlond = 20000

[<Literal>]
let numberIterations = 3000

[<Literal>]
let logEach = 50

let CreateFirstGeneration() = 
    let blond = CreatePerson Feature.Has
    let blondGuys = List.init numberOfBlond (fun _ -> blond)

    let nonBlond = CreatePerson Feature.DontHas
    let nonBlondGuys = List.init numberOfNonBlond  (fun _ -> nonBlond)
    List.append blondGuys nonBlondGuys

let Log length current index=
    let areBlond = HowManySatisfy IsBlond current
    
    let hasBlondGenes = HowManySatisfy HasBlondGenes current
    
    let percentageBlond = (float areBlond) / (length |> float)
    let percentageBlondGenes = (float hasBlondGenes) / (length |> float)
    printfn "Generation %A Blond %A BlondGenes %A" index percentageBlond percentageBlondGenes
    

[<EntryPoint>]
let main _ = 
    let firstGeneration = CreateFirstGeneration()
    let length = Seq.length firstGeneration

    let createNextGeneration index current = 
        let next = NextGeneration current
        if index % logEach = 0 then
            Log length next (numberIterations - index)
        next

    let lastGeneration = Repeat createNextGeneration numberIterations firstGeneration 
    
    Log length lastGeneration numberIterations
    ignore(Console.ReadLine())
   
    0
