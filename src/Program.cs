// V is the number of verbs, W is number of object words, G is number of "gettable" objects.
int verbCount = 26, objectWordCount = 37, g = 19;
int ll, rm;
string m;

// DIM R$ means to declare an array of strings in BASIC.
var r = new string[64];
var d = new string[64];
var o = new string[objectWordCount];
var v = new string[verbCount];

// DIM C means to declare arrays of integers in BASIC.
var c = new int[objectWordCount];
var l = new int[g];
var f = new int[objectWordCount];

Initialize(); // GOSUB 1600

// Description & Feedback
Console.Clear();
Console.WriteLine("Haunted House");
Console.WriteLine("-------------");
Console.WriteLine("Your location");
Console.WriteLine($"{d[rm]}");
Console.Write("exits: ");

for (int i = 0; i < r[rm].Length; i++)
{
  Console.Write($"{r[rm][i]},");
}

Console.WriteLine();

// Console.WriteLine($"rm: {rm}");
for (int i = 1; i < g; i++)
{
  // Console.WriteLine($"{l[i]}; {f[i]}");
  if (l[i] == rm && f[i] == 0)
  {
    Console.WriteLine($"You can see {o[i]} here");
  }
}
Console.WriteLine("=============");

Console.Write(m);
m = "what";

// Input & Input Analysis
Console.WriteLine(" what will you do now");
var q = Console.ReadLine();

string vs = "", ws = "";
int vb = 0, ob = 0;

for (int i = 0; i < q.Length; i++)
{
  if (q.Contains(" ") && vs == string.Empty)
  {
    vs = q.Substring(0, q.IndexOf(" ")).ToLower();
    // Console.WriteLine($"vs: {vs}");
  }

  if (q.Contains(" ") && vs != string.Empty)
  {
    ws = q.Substring(q.IndexOf(" ") + 1).ToLower();
    i = q.Length;
  }
}

if(ws == string.Empty)
{
  vs = q;
}

// Console.WriteLine($"vs: {vs}; ws: {ws}");

for (int i = 1; i < verbCount; i++)
{
  if (vs == v[i])
  {
    vb = i;
  }
}

for (int i = 1; i < objectWordCount; i++)
{
  if (ws == o[i])
  {
    ob = i;
  }
}

// Console.WriteLine($"vb: {vb}; ob: {ob}");

// Error Messages Override Conditions
if (string.Compare(ws, "") > 0 && ob == 0) m = "that's silly";
if (vb == 0) vb = verbCount + 1;
if (string.IsNullOrEmpty(ws)) m = "i need two words";


void Initialize() // 1600
{
  int[] lData = [0, 46, 38, 35, 50, 13, 18, 28, 42, 10, 25, 26, 4, 2, 7, 47, 60, 43, 32];
  for (int i = 0; i < g; i++)
  {
    l[i] = lData[i];
  }
  //Console.WriteLine($"Items in the array l: {string.Join(", ", l)}");

  string[] vData = ["", "help", "carrying", "go", "n", "s", "w", "e", "u", "d", "get", "take", "open", "examine", "read", "say",
    "dig", "swing", "climb", "light", "unlight", "spray", "use", "unlock", "leave", "score"];
  for (int i = 0; i < verbCount; i++)
  {
    v[i] = vData[i];
  }

  string[] rData = [
    "", "se","we","we","swe","we","we","swe","ws",
    "ns","se","we","nw","se","w","ne","nsw",
    "ns","ns","se","we","nwud","se","wsud","ns",
    "n","ns","nse","we","we","nsw","ns","ns",
    "s","nse","nsw","s","nsud","n","n","ns",
    "ne","nw","ne","w","nse","we","w","ns",
    "se","nsw","e","we","nw","s","sw","nw",
    "ne","nwe","we","we","we","nwe","nwe","w"
    ];
  for (int i = 0; i < 64; i++)
  {
    r[i] = rData[i];
  }

  string[] dData = [
    "", "dark corner", "overgrown garden", "by large woodpile", "yard by rubbish",
    "weedpatch", "forest", "thick forest", "blasted tree",
    "corner of house", "entrance to kitchen", "kitchen & grimey cooker", "scullery door",
    "room with inches of dust", "rear turret room", "clearing by house", "path",
    "side of house", "back of hallway", "dark alcove", "small dark room",
    "bottom of spiral staircase", "wide passage", "slippery steps", "clifftop",
    "near crumbling wall", "gloomy passage", "pool of light", "impressive vaulted hallway",
    "hall by thick wooden door", "trophy room", "cellar with barred window", "cliff path",
    "cupboard with hanging coat", "front hall", "sitting room", "secret room",
    "steep marble stairs", "dining room", "deep cellar with coffin", "cliff path",
    "closet", "front lobby", "library of evil books", "study with desk & holde in wall",
    "weird cobweb room", "very cold chamber", "spooky room", "cliff path by marsh",
    "rubble-strewn verandah", "front proch", "front tower", "sloping corridor",
    "upper gallery", "marsh by wall", "marsh", "soggy path",
    "by twisted railing", "path through iron gate", "by railings", "beneath front tower",
    "debris from blumbling facade", "large fallen brickwork", "rotting stone arch", "crumbling clifftop"
    ];
  for (int i = 0; i < 64; i++)
  {
    d[i] = dData[i];
  }

  string[] oData = [
    "", "painting", "ring", "magic spells", "goblet", "scroll", "coins", "statue", "candlestick",
    "matches", "vaccume", "batteries", "shovel", "axe", "rope", "boat", "aerosol", "candle", "key",
    "north", "south", "west", "east", "up", "down",
    "door", "bats", "ghosts", "drawer", "desk", "coat", "rubbish",
    "coffin", "books", "xzanfar", "wall", "spells"
    ];
  for (int i = 0; i < objectWordCount; i++)
  {
    o[i] = oData[i];
  }

  f[19] = 1; // 18
  f[18] = 1; // 17
  f[3] = 1; // 2
  f[27] = 1; // 26
  f[29] = 1; // 28
  f[24] = 1; // 23
  ll = 61; // 60
  rm = 58; // 57
  m = "ok";
}