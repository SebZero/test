using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SynthetizerLib
{

    /*
Do7	4186,01
Si6	3951,07
La6	3729,31
La6	3520
Sol6	3322,44
Sol6	3135,96
Fa6	2959,96
Fa6	2793,83
Mi6	2637,02
Ré6	2489,02
Ré6	2349,32
Do6	2217,46
Do6	2093
Si5	1975,53
La5	1864,66
La5	1760
Sol5	1661,22
Sol5	1567,98
Fa5	1479,98
Fa5	1396,91
Mi5	1318,51
Ré5	1244,51
Ré5	1174,66
Do5	1108,73
Do5	1046,5
Si4	987,767
La4	932,328
La4	880
Sol4	830,609
Sol4	783,991
Fa4	739,989
Fa4	698,456
Mi4	659,255
Ré4	622,254
Ré4	587,33
Do4	554,365
Do4	523,251
Si3	493,883
La3	466,164
La3	440
Sol3	415,305
Sol3	391,995
Fa3	369,994
Fa3	349,228
Mi3	329,628
Ré3	311,127
Ré3	293,665
Do3	277,183
Do3	261,626
Si2	246,942
La2	233,082
La2	220
Sol2	207,652
Sol2	195,998
Fa2	184,997
Fa2	174,614
Mi2	164,814
Ré2	155,563
Ré2	146,832
Do2	138,591
Do2	130,813
Si1	123,471
La1	116,541
La1	110
Sol1	103,826
Sol1	979,989
Fa1	924,986
Fa1	873,071
Mi1	824,069
Ré1	777,817
Ré1	734,162
Do1	692,957
Do1	654,064
Si-1	617,354
La-1	582,705
La-1	55
Sol-1	519,130
Sol-1	489,995
Fa-1	462,493
Fa-1	436,536
Mi-1	412,035
Ré-1	388,909
Ré-1	367,081
Do-1	346,479
Do-1	327,032
     */

    public static class Tones
    {
        private static Dictionary<string, Tone> _dic = CreateDictionary();

        private static Dictionary<string, Tone> CreateDictionary()
        {
            Dictionary<string, Tone> dic = new Dictionary<string, Tone>();

            AddItem(dic, "Do-1", 327);
            AddItem(dic, "Do-1#", 346);
            AddItem(dic, "Ré-1", 367);
            AddItem(dic, "Ré-1#", 388);
            AddItem(dic, "Mi-1", 412);
            AddItem(dic, "Fa-1", 436);
            AddItem(dic, "Fa-1#", 462);
            AddItem(dic, "Sol-1", 489);
            AddItem(dic, "Sol-1#", 519);
            AddItem(dic, "La-1", 55);
            AddItem(dic, "La-1#", 582);
            AddItem(dic, "Si-1", 617);
            AddItem(dic, "Do1", 654);
            AddItem(dic, "Do1#", 692);
            AddItem(dic, "Ré1", 734);
            AddItem(dic, "Ré1#", 777);
            AddItem(dic, "Mi1", 824);
            AddItem(dic, "Fa1", 873);
            AddItem(dic, "Fa1#", 924);
            AddItem(dic, "Sol1", 979);
            AddItem(dic, "Sol1#", 103);
            AddItem(dic, "La1", 110);
            AddItem(dic, "La1#", 116);
            AddItem(dic, "Si1", 123);
            AddItem(dic, "Do2", 130);
            AddItem(dic, "Do2#", 138);
            AddItem(dic, "Ré2", 146);
            AddItem(dic, "Ré2#", 155);
            AddItem(dic, "Mi2", 164);
            AddItem(dic, "Fa2", 174);
            AddItem(dic, "Fa2#", 184);
            AddItem(dic, "Sol2", 195);
            AddItem(dic, "Sol2#", 207);
            AddItem(dic, "La2", 220);
            AddItem(dic, "La2#", 233);
            AddItem(dic, "Si2", 246);
            AddItem(dic, "Do3", 261);
            AddItem(dic, "Do3#", 277);
            AddItem(dic, "Ré3", 293);
            AddItem(dic, "Ré3#", 311);
            AddItem(dic, "Mi3", 329);
            AddItem(dic, "Fa3", 349);
            AddItem(dic, "Fa3#", 369);
            AddItem(dic, "Sol3", 391);
            AddItem(dic, "Sol3#", 415);
            AddItem(dic, "La3", 440);
            AddItem(dic, "La3#", 466);
            AddItem(dic, "Si3", 493);
            AddItem(dic, "Do4", 523);
            AddItem(dic, "Do4#", 554);
            AddItem(dic, "Ré4", 587);
            AddItem(dic, "Ré4#", 622);
            AddItem(dic, "Mi4", 659);
            AddItem(dic, "Fa4", 698);
            AddItem(dic, "Fa4#", 739);
            AddItem(dic, "Sol4", 783);
            AddItem(dic, "Sol4#", 830);
            AddItem(dic, "La4", 880);
            AddItem(dic, "La4#", 932);
            AddItem(dic, "Si4", 987);
            AddItem(dic, "Do5", 1046);
            AddItem(dic, "Do5#", 1108);
            AddItem(dic, "Ré5", 1174);
            AddItem(dic, "Ré5#", 1244);
            AddItem(dic, "Mi5", 1318);
            AddItem(dic, "Fa5", 1396);
            AddItem(dic, "Fa5#", 1479);
            AddItem(dic, "Sol5", 1567);
            AddItem(dic, "Sol5#", 1661);
            AddItem(dic, "La5", 1760);
            AddItem(dic, "La5#", 1864);
            AddItem(dic, "Si5", 1975);
            AddItem(dic, "Do6", 2093);
            AddItem(dic, "Do6#", 2217);
            AddItem(dic, "Ré6", 2349);
            AddItem(dic, "Ré6#", 2489);
            AddItem(dic, "Mi6", 2637);
            AddItem(dic, "Fa6", 2793);
            AddItem(dic, "Fa6#", 2959);
            AddItem(dic, "Sol6", 3135);
            AddItem(dic, "Sol6#", 3322);
            AddItem(dic, "La6", 3520);
            AddItem(dic, "La6#", 3729);
            AddItem(dic, "Si6", 3951);
            AddItem(dic, "Do7", 4186);

            return dic;
        }

        private static void AddItem(Dictionary<string, Tone> dic, string name, int frequency)
        {
            dic.Add(name, new Tone(name, frequency));

        }

        public static List<Tone> ToneList()
        {
            return _dic.Values.ToList();
        }
        public static Tone Item(string name)
        {
            return _dic[name];
        }
    }

    public class Tone
    {
        public string Name { get; set; }
        public int Duration { get; set; }
        public int Amplitude { get; set; }

        public int Frequency { get; set; }

        public Tone(string name, int frequency)
        {
            this.Name = name;
            this.Amplitude = 15000;
            this.Duration = 100;
            this.Frequency = frequency;
        }
    }
}
