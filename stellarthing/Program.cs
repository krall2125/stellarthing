﻿using System.Linq;
using starry;
using stellarthing;
using static starry.Starry;

create(new StarrySettings {
    startup = () => {
        World.addEntity(new Player());
    },
    gameName = "Stellarthing",
    gameVersion = "v0.8.0",
    verbose = args.Contains("--verbose") || isDebug(),
});