// Copyright (c) Six Labors.
// Licensed under the Six Labors Split License.

namespace SixLabors.ImageSharp.Benchmarks
{
    public partial class RgbToYCbCr
    {
        /// <summary>
        /// Scaled integer RGBA to YCbCr lookup tables
        /// </summary>
        private static class LookupTables
        {
            public static readonly int[] Y0 =
                {
                    0, 306, 612, 918, 1224, 1530, 1836, 2142, 2448, 2754, 3060, 3366, 3672, 3978, 4284,
                    4590, 4896, 5202, 5508, 5814, 6120, 6426, 6732, 7038, 7344, 7650, 7956, 8262, 8568,
                    8874, 9180, 9486, 9792, 10098, 10404, 10710, 11016, 11322, 11628, 11934, 12240,
                    12546, 12852, 13158, 13464, 13770, 14076, 14382, 14688, 14994, 15300, 15606, 15912,
                    16218, 16524, 16830, 17136, 17442, 17748, 18054, 18360, 18666, 18972, 19278, 19584,
                    19890, 20196, 20502, 20808, 21114, 21420, 21726, 22032, 22338, 22644, 22950, 23256,
                    23562, 23868, 24174, 24480, 24786, 25092, 25398, 25704, 26010, 26316, 26622, 26928,
                    27234, 27540, 27846, 28152, 28458, 28764, 29070, 29376, 29682, 29988, 30294, 30600,
                    30906, 31212, 31518, 31824, 32130, 32436, 32742, 33048, 33354, 33660, 33966, 34272,
                    34578, 34884, 35190, 35496, 35802, 36108, 36414, 36720, 37026, 37332, 37638, 37944,
                    38250, 38556, 38862, 39168, 39474, 39780, 40086, 40392, 40698, 41004, 41310, 41616,
                    41922, 42228, 42534, 42840, 43146, 43452, 43758, 44064, 44370, 44676, 44982, 45288,
                    45594, 45900, 46206, 46512, 46818, 47124, 47430, 47736, 48042, 48348, 48654, 48960,
                    49266, 49572, 49878, 50184, 50490, 50796, 51102, 51408, 51714, 52020, 52326, 52632,
                    52938, 53244, 53550, 53856, 54162, 54468, 54774, 55080, 55386, 55692, 55998, 56304,
                    56610, 56916, 57222, 57528, 57834, 58140, 58446, 58752, 59058, 59364, 59670, 59976,
                    60282, 60588, 60894, 61200, 61506, 61812, 62118, 62424, 62730, 63036, 63342, 63648,
                    63954, 64260, 64566, 64872, 65178, 65484, 65790, 66096, 66402, 66708, 67014, 67320,
                    67626, 67932, 68238, 68544, 68850, 69156, 69462, 69768, 70074, 70380, 70686, 70992,
                    71298, 71604, 71910, 72216, 72522, 72828, 73134, 73440, 73746, 74052, 74358, 74664,
                    74970, 75276, 75582, 75888, 76194, 76500, 76806, 77112, 77418, 77724, 78030
                };

            public static readonly int[] Y1 =
                {
                    0, 601, 1202, 1803, 2404, 3005, 3606, 4207, 4808, 5409, 6010, 6611, 7212, 7813, 8414,
                    9015, 9616, 10217, 10818, 11419, 12020, 12621, 13222, 13823, 14424, 15025, 15626,
                    16227, 16828, 17429, 18030, 18631, 19232, 19833, 20434, 21035, 21636, 22237, 22838,
                    23439, 24040, 24641, 25242, 25843, 26444, 27045, 27646, 28247, 28848, 29449, 30050,
                    30651, 31252, 31853, 32454, 33055, 33656, 34257, 34858, 35459, 36060, 36661, 37262,
                    37863, 38464, 39065, 39666, 40267, 40868, 41469, 42070, 42671, 43272, 43873, 44474,
                    45075, 45676, 46277, 46878, 47479, 48080, 48681, 49282, 49883, 50484, 51085, 51686,
                    52287, 52888, 53489, 54090, 54691, 55292, 55893, 56494, 57095, 57696, 58297, 58898,
                    59499, 60100, 60701, 61302, 61903, 62504, 63105, 63706, 64307, 64908, 65509, 66110,
                    66711, 67312, 67913, 68514, 69115, 69716, 70317, 70918, 71519, 72120, 72721, 73322,
                    73923, 74524, 75125, 75726, 76327, 76928, 77529, 78130, 78731, 79332, 79933, 80534,
                    81135, 81736, 82337, 82938, 83539, 84140, 84741, 85342, 85943, 86544, 87145, 87746,
                    88347, 88948, 89549, 90150, 90751, 91352, 91953, 92554, 93155, 93756, 94357, 94958,
                    95559, 96160, 96761, 97362, 97963, 98564, 99165, 99766, 100367, 100968, 101569,
                    102170, 102771, 103372, 103973, 104574, 105175, 105776, 106377, 106978, 107579,
                    108180, 108781, 109382, 109983, 110584, 111185, 111786, 112387, 112988, 113589,
                    114190, 114791, 115392, 115993, 116594, 117195, 117796, 118397, 118998, 119599,
                    120200, 120801, 121402, 122003, 122604, 123205, 123806, 124407, 125008, 125609,
                    126210, 126811, 127412, 128013, 128614, 129215, 129816, 130417, 131018, 131619,
                    132220, 132821, 133422, 134023, 134624, 135225, 135826, 136427, 137028, 137629,
                    138230, 138831, 139432, 140033, 140634, 141235, 141836, 142437, 143038, 143639,
                    144240, 144841, 145442, 146043, 146644, 147245, 147846, 148447, 149048, 149649,
                    150250, 150851, 151452, 152053, 152654, 153255
                };

            public static readonly int[] Y2 =
                {
                    0, 117, 234, 351, 468, 585, 702, 819, 936, 1053, 1170, 1287, 1404, 1521, 1638, 1755,
                    1872, 1989, 2106, 2223, 2340, 2457, 2574, 2691, 2808, 2925, 3042, 3159, 3276, 3393,
                    3510, 3627, 3744, 3861, 3978, 4095, 4212, 4329, 4446, 4563, 4680, 4797, 4914, 5031,
                    5148, 5265, 5382, 5499, 5616, 5733, 5850, 5967, 6084, 6201, 6318, 6435, 6552, 6669,
                    6786, 6903, 7020, 7137, 7254, 7371, 7488, 7605, 7722, 7839, 7956, 8073, 8190, 8307,
                    8424, 8541, 8658, 8775, 8892, 9009, 9126, 9243, 9360, 9477, 9594, 9711, 9828, 9945,
                    10062, 10179, 10296, 10413, 10530, 10647, 10764, 10881, 10998, 11115, 11232, 11349,
                    11466, 11583, 11700, 11817, 11934, 12051, 12168, 12285, 12402, 12519, 12636, 12753,
                    12870, 12987, 13104, 13221, 13338, 13455, 13572, 13689, 13806, 13923, 14040, 14157,
                    14274, 14391, 14508, 14625, 14742, 14859, 14976, 15093, 15210, 15327, 15444, 15561,
                    15678, 15795, 15912, 16029, 16146, 16263, 16380, 16497, 16614, 16731, 16848, 16965,
                    17082, 17199, 17316, 17433, 17550, 17667, 17784, 17901, 18018, 18135, 18252, 18369,
                    18486, 18603, 18720, 18837, 18954, 19071, 19188, 19305, 19422, 19539, 19656, 19773,
                    19890, 20007, 20124, 20241, 20358, 20475, 20592, 20709, 20826, 20943, 21060, 21177,
                    21294, 21411, 21528, 21645, 21762, 21879, 21996, 22113, 22230, 22347, 22464, 22581,
                    22698, 22815, 22932, 23049, 23166, 23283, 23400, 23517, 23634, 23751, 23868, 23985,
                    24102, 24219, 24336, 24453, 24570, 24687, 24804, 24921, 25038, 25155, 25272, 25389,
                    25506, 25623, 25740, 25857, 25974, 26091, 26208, 26325, 26442, 26559, 26676, 26793,
                    26910, 27027, 27144, 27261, 27378, 27495, 27612, 27729, 27846, 27963, 28080, 28197,
                    28314, 28431, 28548, 28665, 28782, 28899, 29016, 29133, 29250, 29367, 29484, 29601,
                    29718, 29835
                };

            public static readonly int[] Cb0 =
                {
                    0, -172, -344, -516, -688, -860, -1032, -1204, -1376, -1548, -1720, -1892,
                    -2064, -2236, -2408, -2580, -2752, -2924, -3096, -3268, -3440, -3612,
                    -3784, -3956, -4128, -4300, -4472, -4644, -4816, -4988, -5160, -5332,
                    -5504, -5676, -5848, -6020, -6192, -6364, -6536, -6708, -6880, -7052,
                    -7224, -7396, -7568, -7740, -7912, -8084, -8256, -8428, -8600, -8772,
                    -8944, -9116, -9288, -9460, -9632, -9804, -9976, -10148, -10320, -10492,
                    -10664, -10836, -11008, -11180, -11352, -11524, -11696, -11868, -12040,
                    -12212, -12384, -12556, -12728, -12900, -13072, -13244, -13416, -13588,
                    -13760, -13932, -14104, -14276, -14448, -14620, -14792, -14964, -15136,
                    -15308, -15480, -15652, -15824, -15996, -16168, -16340, -16512, -16684,
                    -16856, -17028, -17200, -17372, -17544, -17716, -17888, -18060, -18232,
                    -18404, -18576, -18748, -18920, -19092, -19264, -19436, -19608, -19780,
                    -19952, -20124, -20296, -20468, -20640, -20812, -20984, -21156, -21328,
                    -21500, -21672, -21844, -22016, -22188, -22360, -22532, -22704, -22876,
                    -23048, -23220, -23392, -23564, -23736, -23908, -24080, -24252, -24424,
                    -24596, -24768, -24940, -25112, -25284, -25456, -25628, -25800, -25972,
                    -26144, -26316, -26488, -26660, -26832, -27004, -27176, -27348, -27520,
                    -27692, -27864, -28036, -28208, -28380, -28552, -28724, -28896, -29068,
                    -29240, -29412, -29584, -29756, -29928, -30100, -30272, -30444, -30616,
                    -30788, -30960, -31132, -31304, -31476, -31648, -31820, -31992, -32164,
                    -32336, -32508, -32680, -32852, -33024, -33196, -33368, -33540, -33712,
                    -33884, -34056, -34228, -34400, -34572, -34744, -34916, -35088, -35260,
                    -35432, -35604, -35776, -35948, -36120, -36292, -36464, -36636, -36808,
                    -36980, -37152, -37324, -37496, -37668, -37840, -38012, -38184, -38356,
                    -38528, -38700, -38872, -39044, -39216, -39388, -39560, -39732, -39904,
                    -40076, -40248, -40420, -40592, -40764, -40936, -41108, -41280, -41452,
                    -41624, -41796, -41968, -42140, -42312, -42484, -42656, -42828, -43000,
                    -43172, -43344, -43516, -43688, -43860
                };

            public static readonly int[] Cb1 =
                {
                    0, 339, 678, 1017, 1356, 1695, 2034, 2373, 2712, 3051, 3390, 3729, 4068,
                    4407, 4746, 5085, 5424, 5763, 6102, 6441, 6780, 7119, 7458, 7797, 8136,
                    8475, 8814, 9153, 9492, 9831, 10170, 10509, 10848, 11187, 11526, 11865,
                    12204, 12543, 12882, 13221, 13560, 13899, 14238, 14577, 14916, 15255,
                    15594, 15933, 16272, 16611, 16950, 17289, 17628, 17967, 18306, 18645,
                    18984, 19323, 19662, 20001, 20340, 20679, 21018, 21357, 21696, 22035,
                    22374, 22713, 23052, 23391, 23730, 24069, 24408, 24747, 25086, 25425,
                    25764, 26103, 26442, 26781, 27120, 27459, 27798, 28137, 28476, 28815,
                    29154, 29493, 29832, 30171, 30510, 30849, 31188, 31527, 31866, 32205,
                    32544, 32883, 33222, 33561, 33900, 34239, 34578, 34917, 35256, 35595,
                    35934, 36273, 36612, 36951, 37290, 37629, 37968, 38307, 38646, 38985,
                    39324, 39663, 40002, 40341, 40680, 41019, 41358, 41697, 42036, 42375,
                    42714, 43053, 43392, 43731, 44070, 44409, 44748, 45087, 45426, 45765,
                    46104, 46443, 46782, 47121, 47460, 47799, 48138, 48477, 48816, 49155,
                    49494, 49833, 50172, 50511, 50850, 51189, 51528, 51867, 52206, 52545,
                    52884, 53223, 53562, 53901, 54240, 54579, 54918, 55257, 55596, 55935,
                    56274, 56613, 56952, 57291, 57630, 57969, 58308, 58647, 58986, 59325,
                    59664, 60003, 60342, 60681, 61020, 61359, 61698, 62037, 62376, 62715,
                    63054, 63393, 63732, 64071, 64410, 64749, 65088, 65427, 65766, 66105,
                    66444, 66783, 67122, 67461, 67800, 68139, 68478, 68817, 69156, 69495,
                    69834, 70173, 70512, 70851, 71190, 71529, 71868, 72207, 72546, 72885,
                    73224, 73563, 73902, 74241, 74580, 74919, 75258, 75597, 75936, 76275,
                    76614, 76953, 77292, 77631, 77970, 78309, 78648, 78987, 79326, 79665,
                    80004, 80343, 80682, 81021, 81360, 81699, 82038, 82377, 82716, 83055,
                    83394, 83733, 84072, 84411, 84750, 85089, 85428, 85767, 86106, 86445
                };

            public static readonly int[] Cb2Cr0 =
                {
                    0, 512, 1024, 1536, 2048, 2560, 3072, 3584, 4096, 4608, 5120, 5632, 6144,
                    6656, 7168, 7680, 8192, 8704, 9216, 9728, 10240, 10752, 11264, 11776,
                    12288, 12800, 13312, 13824, 14336, 14848, 15360, 15872, 16384, 16896,
                    17408, 17920, 18432, 18944, 19456, 19968, 20480, 20992, 21504, 22016,
                    22528, 23040, 23552, 24064, 24576, 25088, 25600, 26112, 26624, 27136,
                    27648, 28160, 28672, 29184, 29696, 30208, 30720, 31232, 31744, 32256,
                    32768, 33280, 33792, 34304, 34816, 35328, 35840, 36352, 36864, 37376,
                    37888, 38400, 38912, 39424, 39936, 40448, 40960, 41472, 41984, 42496,
                    43008, 43520, 44032, 44544, 45056, 45568, 46080, 46592, 47104, 47616,
                    48128, 48640, 49152, 49664, 50176, 50688, 51200, 51712, 52224, 52736,
                    53248, 53760, 54272, 54784, 55296, 55808, 56320, 56832, 57344, 57856,
                    58368, 58880, 59392, 59904, 60416, 60928, 61440, 61952, 62464, 62976,
                    63488, 64000, 64512, 65024, 65536, 66048, 66560, 67072, 67584, 68096,
                    68608, 69120, 69632, 70144, 70656, 71168, 71680, 72192, 72704, 73216,
                    73728, 74240, 74752, 75264, 75776, 76288, 76800, 77312, 77824, 78336,
                    78848, 79360, 79872, 80384, 80896, 81408, 81920, 82432, 82944, 83456,
                    83968, 84480, 84992, 85504, 86016, 86528, 87040, 87552, 88064, 88576,
                    89088, 89600, 90112, 90624, 91136, 91648, 92160, 92672, 93184, 93696,
                    94208, 94720, 95232, 95744, 96256, 96768, 97280, 97792, 98304, 98816,
                    99328, 99840, 100352, 100864, 101376, 101888, 102400, 102912, 103424,
                    103936, 104448, 104960, 105472, 105984, 106496, 107008, 107520, 108032,
                    108544, 109056, 109568, 110080, 110592, 111104, 111616, 112128, 112640,
                    113152, 113664, 114176, 114688, 115200, 115712, 116224, 116736, 117248,
                    117760, 118272, 118784, 119296, 119808, 120320, 120832, 121344, 121856,
                    122368, 122880, 123392, 123904, 124416, 124928, 125440, 125952, 126464,
                    126976, 127488, 128000, 128512, 129024, 129536, 130048, 130560
                };

            public static readonly int[] Cr1 =
                {
                    0, 429, 858, 1287, 1716, 2145, 2574, 3003, 3432, 3861, 4290, 4719, 5148,
                    5577, 6006, 6435, 6864, 7293, 7722, 8151, 8580, 9009, 9438, 9867, 10296,
                    10725, 11154, 11583, 12012, 12441, 12870, 13299, 13728, 14157, 14586,
                    15015, 15444, 15873, 16302, 16731, 17160, 17589, 18018, 18447, 18876,
                    19305, 19734, 20163, 20592, 21021, 21450, 21879, 22308, 22737, 23166,
                    23595, 24024, 24453, 24882, 25311, 25740, 26169, 26598, 27027, 27456,
                    27885, 28314, 28743, 29172, 29601, 30030, 30459, 30888, 31317, 31746,
                    32175, 32604, 33033, 33462, 33891, 34320, 34749, 35178, 35607, 36036,
                    36465, 36894, 37323, 37752, 38181, 38610, 39039, 39468, 39897, 40326,
                    40755, 41184, 41613, 42042, 42471, 42900, 43329, 43758, 44187, 44616,
                    45045, 45474, 45903, 46332, 46761, 47190, 47619, 48048, 48477, 48906,
                    49335, 49764, 50193, 50622, 51051, 51480, 51909, 52338, 52767, 53196,
                    53625, 54054, 54483, 54912, 55341, 55770, 56199, 56628, 57057, 57486,
                    57915, 58344, 58773, 59202, 59631, 60060, 60489, 60918, 61347, 61776,
                    62205, 62634, 63063, 63492, 63921, 64350, 64779, 65208, 65637, 66066,
                    66495, 66924, 67353, 67782, 68211, 68640, 69069, 69498, 69927, 70356,
                    70785, 71214, 71643, 72072, 72501, 72930, 73359, 73788, 74217, 74646,
                    75075, 75504, 75933, 76362, 76791, 77220, 77649, 78078, 78507, 78936,
                    79365, 79794, 80223, 80652, 81081, 81510, 81939, 82368, 82797, 83226,
                    83655, 84084, 84513, 84942, 85371, 85800, 86229, 86658, 87087, 87516,
                    87945, 88374, 88803, 89232, 89661, 90090, 90519, 90948, 91377, 91806,
                    92235, 92664, 93093, 93522, 93951, 94380, 94809, 95238, 95667, 96096,
                    96525, 96954, 97383, 97812, 98241, 98670, 99099, 99528, 99957, 100386,
                    100815, 101244, 101673, 102102, 102531, 102960, 103389, 103818, 104247,
                    104676, 105105, 105534, 105963, 106392, 106821, 107250, 107679, 108108,
                    108537, 108966, 109395
                };

            public static readonly int[] Cr2 =
                {
                    0, 83, 166, 249, 332, 415, 498, 581, 664, 747, 830, 913, 996, 1079, 1162,
                    1245, 1328, 1411, 1494, 1577, 1660, 1743, 1826, 1909, 1992, 2075, 2158,
                    2241, 2324, 2407, 2490, 2573, 2656, 2739, 2822, 2905, 2988, 3071, 3154,
                    3237, 3320, 3403, 3486, 3569, 3652, 3735, 3818, 3901, 3984, 4067, 4150,
                    4233, 4316, 4399, 4482, 4565, 4648, 4731, 4814, 4897, 4980, 5063, 5146,
                    5229, 5312, 5395, 5478, 5561, 5644, 5727, 5810, 5893, 5976, 6059, 6142,
                    6225, 6308, 6391, 6474, 6557, 6640, 6723, 6806, 6889, 6972, 7055, 7138,
                    7221, 7304, 7387, 7470, 7553, 7636, 7719, 7802, 7885, 7968, 8051, 8134,
                    8217, 8300, 8383, 8466, 8549, 8632, 8715, 8798, 8881, 8964, 9047, 9130,
                    9213, 9296, 9379, 9462, 9545, 9628, 9711, 9794, 9877, 9960, 10043, 10126,
                    10209, 10292, 10375, 10458, 10541, 10624, 10707, 10790, 10873, 10956,
                    11039, 11122, 11205, 11288, 11371, 11454, 11537, 11620, 11703, 11786,
                    11869, 11952, 12035, 12118, 12201, 12284, 12367, 12450, 12533, 12616,
                    12699, 12782, 12865, 12948, 13031, 13114, 13197, 13280, 13363, 13446,
                    13529, 13612, 13695, 13778, 13861, 13944, 14027, 14110, 14193, 14276,
                    14359, 14442, 14525, 14608, 14691, 14774, 14857, 14940, 15023, 15106,
                    15189, 15272, 15355, 15438, 15521, 15604, 15687, 15770, 15853, 15936,
                    16019, 16102, 16185, 16268, 16351, 16434, 16517, 16600, 16683, 16766,
                    16849, 16932, 17015, 17098, 17181, 17264, 17347, 17430, 17513, 17596,
                    17679, 17762, 17845, 17928, 18011, 18094, 18177, 18260, 18343, 18426,
                    18509, 18592, 18675, 18758, 18841, 18924, 19007, 19090, 19173, 19256,
                    19339, 19422, 19505, 19588, 19671, 19754, 19837, 19920, 20003, 20086,
                    20169, 20252, 20335, 20418, 20501, 20584, 20667, 20750, 20833, 20916,
                    20999, 21082, 21165
                };
        }
    }
}
