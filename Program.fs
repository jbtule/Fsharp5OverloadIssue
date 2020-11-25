// Learn more about F# at http://fsharp.org

open System

type OverloadMeths =
    static member ToOption(x) = x |> Option.ofNullable
    static member ToOption(x) = x |> Option.ofObj
    static member ToOption(x: 'T option) = x

type OptionBuilder() =
      member __.Zero() = None

      member __.Return(x: 'T) = Some x

      member __.Bind(m: 'T option, f) = Option.bind f m
      member __.Bind(m: 'T Nullable, f) = m |> Option.ofNullable |> Option.bind f
      member __.Bind(m: 'T when 'T:null, f) = m |> Option.ofObj |> Option.bind f

      member __.Delay(f: unit -> _) = f
      member __.Run(f) = f()

let option = OptionBuilder()

[<AllowNullLiteral>]
type Node (child:Node)=
    new() = new Node(null)
    member val child:Node = child with get,set

[<EntryPoint>]
let main argv =

    let parent = Node()
    let a1 = parent.child |> OverloadMeths.ToOption
    let b1 = a1 |> Option.bind (fun x -> x.child |> OverloadMeths.ToOption)
    let c1 = b1 |> Option.bind (fun x -> x.child |> OverloadMeths.ToOption)

    printfn "c1=%A" c1

    let parent = Node()
    let d2 =
        option {
            let! a2 = parent.child
            let! b2 = a2.child
            let! c2 = b2.child
            return c2
        } 
    printfn "d2=%A" d2
    0 // return an integer exit code
