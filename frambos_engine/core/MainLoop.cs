﻿using System;
using frambos.ecs;
using frambos.graphics;
using Silk.NET.SDL;

namespace frambos.core;

/// <summary>
/// handles communication between the renderer and silk.net/the OS
/// </summary>
public static unsafe class MainLoop {
    internal static Sdl sdl { get; set; }
    internal static Window* window { get; set; }
    internal static Silk.NET.SDL.Renderer* render { get; set; }

    /// <summary>
    /// startups the engine
    /// </summary>
    public static unsafe void setup(string[] args, Action start_game)
    {
        // unrequested help command
        Console.WriteLine("Options:");
        Console.WriteLine("  -v, --verbose: shows error messages, helpful for troubleshooting");

        // first check arguments for the engine
        foreach (var arg in args) {
            if (arg == "-v" || arg == "--verbose") {
                Frambos.verbose_mode = true;
            }
        }

        Frambos.log("starting up engine");

        // setup sdl
        sdl = Sdl.GetApi();
        if (sdl.Init(Sdl.InitVideo) < 0) {
            Frambos.log("SDL ERROR: ", new string((char*)sdl.GetError()));
            return;
        }

        Window* window = sdl.CreateWindow("Space Game", 0, 0, 1280, 720, 0);
        if (window == null) {
            Frambos.log("SDL ERROR: ", new string((char*)sdl.GetError()));
            return;
        }
        sdl.SetWindowFullscreen(window, (uint)WindowFlags.FullscreenDesktop);

        render = sdl.CreateRenderer(window, -1, 0);
        if (render == null) {
            Frambos.log("SDL ERROR: ", new string((char*)sdl.GetError()));
            return;
        }

        sdl.SetRenderDrawColor(render, 0, 0, 0, 1);
        Frambos.log("done setting up window");

        double prev_time = sdl.GetTicks64() / 1000d;
        double delta = 0;

        // scale crap :D
        int resw = 0;
        int resh = 0;
        sdl.GetWindowSize(window, ref resw, ref resh);
        Frambos.log(resh);
        // a lot of Ds so it recognizes that it is indeed float fuckery
        graphics.Renderer.scale_factor = resh / 720d;
        graphics.Renderer.center_offset = (resw - (1280d * (resh / 720d))) / 2d;

        // now the game starts loading its crap :)
        // it's important to note that only now that the assets would work
        // ecs is loaded immediately after that
        Frambos.log("game can now start");
        start_game.Invoke();
        
        // main loop :D
        bool quit = false;
        Event e = new();
        while (!quit) {
            while (sdl.PollEvent(ref e) != 0) {
                if (e.Type == (uint)EventType.Quit) {
                    Frambos.log("close request");
                    quit = true;
                    break;
                }
                else {
                    InputManager.handle_new_event(e);
                }
            }

            double cur_time = sdl.GetTicks64() / 1000d;
            delta = cur_time - prev_time;
            prev_time = cur_time;

            // mouse stuff
            /*int* x = (int*)0;
            int* y = (int*)0;
            sdl.GetMouseState(x, y);
            if (true) {}
            // if you have a screen with a resolution lower than 1280x720 it deserves to be broken
            InputManager.mouse_pos = new util.Vector2(
                *x / graphics.Renderer.scale_factor, *y / graphics.Renderer.scale_factor);*/
            
            // jgjjfgd
            InputManager.handle_keyboard_but_every_frame();
            EcsManager.update_everything(delta);

            // test =)
            Frambos.log("is pressed", InputManager.is_key_pressed(Key.semicolon));
            Frambos.log("is just pressed", InputManager.is_key_just_pressed(Key.semicolon));
            Frambos.log("is released", InputManager.is_key_released(Key.semicolon));

            // rendering (:
            sdl.RenderClear(render);
            EcsManager.render_everything();
            sdl.RenderPresent(render);
        }

        AssetManager.dispose_all();

        sdl.DestroyRenderer(render);
        sdl.DestroyWindow(window);
        sdl.Quit();

        Frambos.log("game finished running");
    }
}
