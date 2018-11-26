# BlackWasp Command Design Pattern
Tutorial from BlackWasp for the Command Design Pattern

* Implements the code sample provided at [BlackWasp Command Pattern](http://www.blackwasp.co.uk/command.aspx) with ReSharper-suggested enhancements
* Executes the code using a .NET Core Console application
* Unit tests all methods using these testing and utility libraries:
  * **Xbehave** and **xUnit**
  * **Moq**, **Moq.AutoMock**, and **Moq.Sequences**
  * **Shouldly**
  * **Bogus**
* Follows the [Ardalis Clean Architecture pattern](https://github.com/ardalis/CleanArchitecture) and [avoids referencing Infrastructure](https://ardalis.com/avoid-referencing-infrastructure-in-visual-studio-solutions)
  * [How to have a Project Reference without referencing the actual binary](https://blogs.msdn.microsoft.com/kirillosenkov/2015/04/04/how-to-have-a-project-reference-without-referencing-the-actual-binary/)
  * [Loading unreferenced assemblies at runtime for IoC with ASP.NET Core](https://joergweissbecker.wordpress.com/2017/12/06/loading-unreferenced-assemblies-at-runtime-for-ioc-with-asp-net-core/)
