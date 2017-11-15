namespace iostp2

open System

open Foundation
open UIKit

type Container = Xamarin.UIProvider

type BaseController = Container.ViewControllerBase

[<Register (BaseController.CustomClass)>]
type ViewController (handle:IntPtr) =
    inherit BaseController (handle)

    let mutable counter = 0

    override x.ViewDidLoad () =
        base.ViewDidLoad ()

        // Perform any additional setup after loading the view
        let updateButton() =
            x.myButton.SetTitle(sprintf "You clicked me %d time(s)" counter, UIControlState.Normal)
            counter <- counter + 1

        // Set the initial text
        updateButton()
        x.myButton.TouchUpInside.Add(fun _ -> updateButton())

    override x.ShouldAutorotateToInterfaceOrientation (toInterfaceOrientation) =
        // Return true for supported orientations
        if UIDevice.CurrentDevice.UserInterfaceIdiom = UIUserInterfaceIdiom.Phone then
           toInterfaceOrientation <> UIInterfaceOrientation.PortraitUpsideDown
        else
           true

    override x.DidReceiveMemoryWarning () =
        // Releases the view if it doesn't have a superview.
        base.DidReceiveMemoryWarning ()
        // Release any cached data, images, etc that aren't in use.
