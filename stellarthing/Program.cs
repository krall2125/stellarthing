﻿using System.IO;
using System.Linq;
using starry;
using stellarthing;
using static starry.Starry;

create(new StarrySettings {
    startup = () => {
        load<Font>("ui/RedHatText-Bold.tff");
        Tilemap.world = "space";
        World.addEntity(new SpaceScene());
        World.addEntity(new Player());
    },
    gameName = "Stellarthing",
    gameVersion = "v0.9.0",
    verbose = args.Contains("--verbose") || isDebug(),
    keymap = {
        {"move_up", [Key.w, Key.arrowUp]},
        {"move_left", [Key.a, Key.arrowLeft]},
        {"move_down", [Key.s, Key.arrowDown]},
        {"move_right", [Key.d, Key.arrowRight]},
    },
    assetPath = Path.GetFullPath("assets"),
    renderSize = vec2i(1920, 1080),
    tileSize = vec2i(96, 96),
    defaultFont = "ui/RedHatText-Bold.tff",
    fontCharacterSize = vec2i(60, 131),
    fontCharacters = new() {
        {'\0', vec2i(30, 4)}, // for invalid characters
        {' ', vec2i(0, 0)},
        {'!', vec2i(1, 0)},
        {'"', vec2i(2, 0)},
        {'#', vec2i(3, 0)},
        {'$', vec2i(4, 0)},
        {'%', vec2i(5, 0)},
        {'&', vec2i(6, 0)},
        {'\'', vec2i(7, 0)},
        {'(', vec2i(8, 0)},
        {')', vec2i(9, 0)},
        {'*', vec2i(10, 0)},
        {'+', vec2i(11, 0)},
        {',', vec2i(12, 0)},
        {'-', vec2i(13, 0)},
        {'.', vec2i(14, 0)},
        {'/', vec2i(15, 0)},
        {'0', vec2i(16, 0)},
        {'1', vec2i(17, 0)},
        {'2', vec2i(18, 0)},
        {'3', vec2i(19, 0)},
        {'4', vec2i(20, 0)},
        {'5', vec2i(21, 0)},
        {'6', vec2i(22, 0)},
        {'7', vec2i(23, 0)},
        {'8', vec2i(24, 0)},
        {'9', vec2i(25, 0)},
        {':', vec2i(26, 0)},
        {';', vec2i(27, 0)},
        {'<', vec2i(28, 0)},
        {'=', vec2i(29, 0)},
        {'>', vec2i(30, 0)},
        {'?', vec2i(31, 0)},
        {'@', vec2i(0, 1)},
        {'A', vec2i(1, 1)},
        {'B', vec2i(2, 1)},
        {'C', vec2i(3, 1)},
        {'D', vec2i(4, 1)},
        {'E', vec2i(5, 1)},
        {'F', vec2i(6, 1)},
        {'G', vec2i(7, 1)},
        {'H', vec2i(8, 1)},
        {'I', vec2i(9, 1)},
        {'J', vec2i(10, 1)},
        {'K', vec2i(11, 1)},
        {'L', vec2i(12, 1)},
        {'M', vec2i(13, 1)},
        {'N', vec2i(14, 1)},
        {'O', vec2i(15, 1)},
        {'P', vec2i(16, 1)},
        {'Q', vec2i(17, 1)},
        {'R', vec2i(18, 1)},
        {'S', vec2i(19, 1)},
        {'T', vec2i(20, 1)},
        {'U', vec2i(21, 1)},
        {'V', vec2i(22, 1)},
        {'W', vec2i(23, 1)},
        {'X', vec2i(24, 1)},
        {'Y', vec2i(25, 1)},
        {'Z', vec2i(26, 1)},
        {'[', vec2i(27, 1)},
        {'\\', vec2i(28, 1)},
        {']', vec2i(29, 1)},
        {'^', vec2i(30, 1)},
        {'_', vec2i(31, 1)},
        {'`', vec2i(0, 2)},
        {'a', vec2i(1, 2)},
        {'b', vec2i(2, 2)},
        {'c', vec2i(3, 2)},
        {'d', vec2i(4, 2)},
        {'e', vec2i(5, 2)},
        {'f', vec2i(6, 2)},
        {'g', vec2i(7, 2)},
        {'h', vec2i(8, 2)},
        {'i', vec2i(9, 2)},
        {'j', vec2i(10, 2)},
        {'k', vec2i(11, 2)},
        {'l', vec2i(12, 2)},
        {'m', vec2i(13, 2)},
        {'n', vec2i(14, 2)},
        {'o', vec2i(15, 2)},
        {'p', vec2i(16, 2)},
        {'q', vec2i(17, 2)},
        {'r', vec2i(18, 2)},
        {'s', vec2i(19, 2)},
        {'t', vec2i(20, 2)},
        {'u', vec2i(21, 2)},
        {'v', vec2i(22, 2)},
        {'w', vec2i(23, 2)},
        {'x', vec2i(24, 2)},
        {'y', vec2i(25, 2)},
        {'z', vec2i(26, 2)},
        {'{', vec2i(27, 2)},
        {'|', vec2i(28, 2)},
        {'}', vec2i(29, 2)},
        {'~', vec2i(30, 2)},
        {'°', vec2i(31, 2)},
        {'¡', vec2i(0, 3)},
        {'´', vec2i(1, 3)},
        {'¨', vec2i(2, 3)},
        {'Á', vec2i(3, 3)},
        {'É', vec2i(4, 3)},
        {'Í', vec2i(5, 3)},
        {'Ó', vec2i(6, 3)},
        {'Ú', vec2i(7, 3)},
        {'Ñ', vec2i(8, 3)},
        {'á', vec2i(9, 3)},
        {'é', vec2i(10, 3)},
        {'í', vec2i(11, 3)},
        {'ó', vec2i(12, 3)},
        {'ú', vec2i(13, 3)},
        {'ñ', vec2i(14, 3)},
        {'Ç', vec2i(15, 3)},
        {'À', vec2i(16, 3)},
        {'È', vec2i(17, 3)},
        {'Ì', vec2i(18, 3)},
        {'Ò', vec2i(19, 3)},
        {'Ù', vec2i(20, 3)},
        {'Â', vec2i(21, 3)},
        {'Ê', vec2i(22, 3)},
        {'Î', vec2i(23, 3)},
        {'Ô', vec2i(24, 3)},
        {'Û', vec2i(25, 3)},
        {'Ä', vec2i(26, 3)},
        {'Ë', vec2i(27, 3)},
        {'Ï', vec2i(28, 3)},
        {'Ö', vec2i(29, 3)},
        {'Ü', vec2i(30, 3)},
        {'¿', vec2i(0, 4)},
        {'Ã', vec2i(1, 4)},
        {'Ẽ', vec2i(2, 4)},
        {'Ĩ', vec2i(3, 4)},
        {'Õ', vec2i(4, 4)},
        {'Ũ', vec2i(5, 4)},
        {'ç', vec2i(6, 4)},
        {'à', vec2i(7, 4)},
        {'è', vec2i(8, 4)},
        {'ì', vec2i(9, 4)},
        {'ò', vec2i(10, 4)},
        {'ù', vec2i(11, 4)},
        {'â', vec2i(12, 4)},
        {'ê', vec2i(13, 4)},
        {'î', vec2i(14, 4)},
        {'ô', vec2i(15, 4)},
        {'û', vec2i(16, 4)},
        {'ä', vec2i(17, 4)},
        {'ë', vec2i(18, 4)},
        {'ï', vec2i(19, 4)},
        {'ö', vec2i(20, 4)},
        {'ü', vec2i(21, 4)},
        {'ã', vec2i(22, 4)},
        {'ẽ', vec2i(23, 4)},
        {'ĩ', vec2i(24, 4)},
        {'õ', vec2i(25, 4)},
        {'ũ', vec2i(26, 4)},
        {'ª', vec2i(27, 4)},
        {'º', vec2i(28, 4)},
        {'§', vec2i(29, 4)},
    }
});
