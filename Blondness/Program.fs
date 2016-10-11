// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.
open Random
open Bio
open System

let init = 
    let numberOfBlond = 100
    let blondGuys = List.init numberOfBlond (fun index -> Bio.create true)

    let numberOfNonBlond = 1000
    let nonBlondGuys = List.init numberOfNonBlond (fun index -> Bio.create false)

    List.append blondGuys nonBlondGuys

[<EntryPoint>]
let main argv = 
    let all = init

    let all = Random.shuffle all


    let dummy = Random.shuffle [1..100]

    let areBlond = List.filter Bio.isBlond all |> List.length
    let percentage = (float areBlond) / (List.length all |> float)
    printfn "%A" percentage
    let unused = Console.ReadLine()
    0
