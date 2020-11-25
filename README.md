# Fsharp5OverloadIssue
An overload regression in F# 5.0. Seemingly related to nullable.

All Code is in Program.fs

4.7 project and 5.0 project referencing same file. 4.7 compiles and runs just fine, 5.0 doesn't compile.

![Image of Compiler Red Underlines](VSErrorScreensShot.png)
![Error	FS0072	Lookup on object of indeterminate type based on information prior to this program point. A type annotation may be needed prior to this program point to constrain the type of the object. This may allow the lookup to be resolved.](VSNonsense.png)
