// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open Random
open Bio
open System


[<EntryPoint>]
let main argv = 
    let numberOfIndividuals = 100000
    let start = List.init numberOfIndividuals  (fun index -> Bio.create())

    let areBlond =  List.filter Bio.isBlond start |> List.length

    let percentage = (float areBlond) / (float numberOfIndividuals)

    printfn "%A" percentage

    let unused = Console.ReadLine()

    0
