using System;
using static starry.Starry;

namespace starry;

/// <summary>
/// key codes, mapped directly to GLFW keys
/// </summary>
public enum Key {
    space = 32,
    apostrophe = 39, // '
    comma = 44, // ,
    minus = 45, // -
    period = 46, // .
    slash = 47, // /
    key0 = 48,
    key1 = 49,
    key2 = 50,
    key3 = 51,
    key4 = 52,
    key5 = 53,
    key6 = 54,
    key7 = 55,
    key8 = 56,
    key9 = 57,
    semicolon = 59, // ;
    equal = 61, // =
    a = 65,
    b = 66,
    c = 67,
    d = 68,
    e = 69, // HAHAHAHA SEE HOW THE BRAIN PLAYS AROUND AND YOU FALL INSIDE A HOLE YOU COULDN'T SEE AND YOU FALL INSIDE A HOLE INSIDE A SOMEONE HELP ME UNDERSTAND WHAT'S GOING ON INSIDE MY MIND DOCTOR I CAN'T TELL IF I'M NOT ME WHEN IT GROWS BRIGHT THE PARTICLES START TO MARVEL HAVING MADE IT THROUGH THE NIGHT NEVER THEY PONDER WHETHER ELECTRIC CALMING IF YOU LOOK AT IT RIGHT
    f = 70,
    g = 71,
    h = 72,
    i = 73,
    j = 74,
    k = 75,
    l = 76,
    m = 77,
    n = 78,
    o = 79,
    p = 80,
    q = 81,
    r = 82,
    s = 83,
    t = 84,
    u = 85,
    v = 86,
    w = 87,
    x = 88,
    y = 89,
    z = 90,
    leftBracket = 91, // [
    backslash = 92, // \
    rightBracket = 93, // ]
    grave = 96, // `
    international1 = 161,
    international2 = 162,
    escape = 256,
    enter = 257, // also known as return
    tab = 258,
    backspace = 259,
    insert = 260,
    delete = 261,
    arrowRight = 262,
    arrowLeft = 263,
    arrowDown = 264,
    arrowUp = 265,
    pageUp = 266,
    pageDown = 267,
    home = 268,
    end = 269,
    capsLock = 280,
    scrollLock = 281, // not on all keyboards
    numLock = 282,
    print = 283,
    pause = 284, // not on all keyboards
    f1 = 290,
    f2 = 291,
    f3 = 292,
    f4 = 293,
    f5 = 294,
    f6 = 295,
    f7 = 296,
    f8 = 297,
    f9 = 298,
    f10 = 299,
    f11 = 300,
    f12 = 301,
    f13 = 302,
    f14 = 303,
    f15 = 304,
    f16 = 305,
    f17 = 306,
    f18 = 307,
    f19 = 308,
    f20 = 309,
    f21 = 310,
    f22 = 311,
    f23 = 312,
    f24 = 313,
    f25 = 314,
    kp0 = 320,
    kp1 = 321,
    kp2 = 322,
    kp3 = 323,
    kp4 = 324,
    kp5 = 325,
    kp6 = 326,
    kp7 = 327,
    kp8 = 328,
    kp9 = 329,
    kpDecimal = 330,
    kpDivide = 331,
    kpMultiply = 332,
    kpSubtract = 333,
    kpAdd = 334,
    kpEnter = 335,
    kpEqual = 336,
    leftShift = 340,
    leftControl = 341,
    leftAlt = 342,
    leftSuper = 343, // also known as meta and the windows key
    rightShift = 344,
    rightControl = 345,
    rightAlt = 346,
    rightSuper = 347, // also known as meta and the windows key
    menu = 348, // i think that's the context menu key
}