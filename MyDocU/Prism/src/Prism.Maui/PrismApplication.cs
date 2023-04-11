using System;
using Microsoft.Extensions.DependencyInjection;
using Prism.Navigation;

namespace Prism;

public class PrismApplication : Application, IWindowManager
{
    private Window initialWindow;

    protected override Window CreateWindow(IActivationState activationState)
    {
        if (initialWindow is not null)
            return initialWindow;
        else if (Windows.OfType<PrismWindow>().Any())
            return initialWindow = Windows.OfType<PrismWindow>().First();

        activationState.Context.Services.GetRequiredService<PrismAppBuilder>().OnAppStarted();

        return initialWindow ?? throw new InvalidNavigationException("Expected Navigation Failed. No Root Window has been created.");
    }

    void IWindowManager.OpenWindow(Window window)
    {
        if (initialWindow is null)
            initialWindow = window;
        else
            OpenWindow(window);
    }
}

