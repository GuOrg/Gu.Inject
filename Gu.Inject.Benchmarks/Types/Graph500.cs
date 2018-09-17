// ReSharper disable UnusedParameter.Local
// ReSharper disable UnusedMember.Global
// ReSharper disable EmptyConstructor
namespace Gu.Inject.Benchmarks.Types
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Graph500
    {
        public class Node1 : INode
        {
            public Node1(
                Node7 node7,
                Node8 node8,
                Node20 node20,
                Node26 node26,
                Node29 node29,
                Node34 node34,
                Node37 node37,
                Node49 node49,
                Node50 node50,
                Node57 node57,
                Node60 node60,
                Node63 node63,
                Node72 node72,
                Node79 node79,
                Node83 node83,
                Node93 node93,
                Node96 node96,
                Node101 node101,
                Node109 node109,
                Node113 node113,
                Node116 node116,
                Node118 node118,
                Node121 node121,
                Node124 node124,
                Node127 node127,
                Node135 node135,
                Node136 node136,
                Node144 node144,
                Node154 node154,
                Node156 node156,
                Node162 node162,
                Node167 node167,
                Node179 node179,
                Node180 node180,
                Node183 node183,
                Node188 node188,
                Node193 node193,
                Node200 node200,
                Node202 node202,
                Node207 node207,
                Node216 node216,
                Node217 node217,
                Node219 node219,
                Node221 node221,
                Node225 node225,
                Node226 node226,
                Node230 node230,
                Node233 node233,
                Node234 node234,
                Node240 node240,
                Node244 node244,
                Node245 node245,
                Node252 node252,
                Node254 node254,
                Node259 node259,
                Node261 node261,
                Node263 node263,
                Node268 node268,
                Node277 node277,
                Node282 node282,
                Node287 node287,
                Node288 node288,
                Node294 node294,
                Node295 node295,
                Node300 node300,
                Node305 node305,
                Node310 node310,
                Node318 node318,
                Node324 node324,
                Node328 node328,
                Node334 node334,
                Node338 node338,
                Node340 node340,
                Node344 node344,
                Node346 node346,
                Node348 node348,
                Node349 node349,
                Node352 node352,
                Node359 node359,
                Node363 node363,
                Node375 node375,
                Node381 node381,
                Node383 node383,
                Node395 node395,
                Node408 node408,
                Node411 node411,
                Node412 node412,
                Node415 node415,
                Node423 node423,
                Node431 node431,
                Node432 node432,
                Node437 node437,
                Node440 node440,
                Node444 node444,
                Node448 node448,
                Node461 node461,
                Node466 node466,
                Node472 node472,
                Node476 node476,
                Node485 node485,
                Node490 node490,
                Node498 node498)
            {
                this.Children = new INode[]
                {
                    node7,
                    node8,
                    node20,
                    node26,
                    node29,
                    node34,
                    node37,
                    node49,
                    node50,
                    node57,
                    node60,
                    node63,
                    node72,
                    node79,
                    node83,
                    node93,
                    node96,
                    node101,
                    node109,
                    node113,
                    node116,
                    node118,
                    node121,
                    node124,
                    node127,
                    node135,
                    node136,
                    node144,
                    node154,
                    node156,
                    node162,
                    node167,
                    node179,
                    node180,
                    node183,
                    node188,
                    node193,
                    node200,
                    node202,
                    node207,
                    node216,
                    node217,
                    node219,
                    node221,
                    node225,
                    node226,
                    node230,
                    node233,
                    node234,
                    node240,
                    node244,
                    node245,
                    node252,
                    node254,
                    node259,
                    node261,
                    node263,
                    node268,
                    node277,
                    node282,
                    node287,
                    node288,
                    node294,
                    node295,
                    node300,
                    node305,
                    node310,
                    node318,
                    node324,
                    node328,
                    node334,
                    node338,
                    node340,
                    node344,
                    node346,
                    node348,
                    node349,
                    node352,
                    node359,
                    node363,
                    node375,
                    node381,
                    node383,
                    node395,
                    node408,
                    node411,
                    node412,
                    node415,
                    node423,
                    node431,
                    node432,
                    node437,
                    node440,
                    node444,
                    node448,
                    node461,
                    node466,
                    node472,
                    node476,
                    node485,
                    node490,
                    node498,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node2 : INode
        {
            public Node2(
                Node18 node18,
                Node30 node30,
                Node58 node58,
                Node64 node64,
                Node82 node82,
                Node86 node86,
                Node92 node92,
                Node96 node96,
                Node102 node102,
                Node104 node104,
                Node106 node106,
                Node114 node114,
                Node116 node116,
                Node130 node130,
                Node138 node138,
                Node140 node140,
                Node146 node146,
                Node174 node174,
                Node186 node186,
                Node188 node188,
                Node190 node190,
                Node208 node208,
                Node210 node210,
                Node234 node234,
                Node236 node236,
                Node246 node246,
                Node256 node256,
                Node274 node274,
                Node280 node280,
                Node288 node288,
                Node290 node290,
                Node298 node298,
                Node302 node302,
                Node306 node306,
                Node308 node308,
                Node336 node336,
                Node356 node356,
                Node358 node358,
                Node372 node372,
                Node386 node386,
                Node396 node396,
                Node414 node414,
                Node422 node422,
                Node430 node430,
                Node434 node434,
                Node438 node438,
                Node448 node448,
                Node456 node456,
                Node472 node472,
                Node478 node478,
                Node482 node482,
                Node494 node494)
            {
                this.Children = new INode[]
                {
                    node18,
                    node30,
                    node58,
                    node64,
                    node82,
                    node86,
                    node92,
                    node96,
                    node102,
                    node104,
                    node106,
                    node114,
                    node116,
                    node130,
                    node138,
                    node140,
                    node146,
                    node174,
                    node186,
                    node188,
                    node190,
                    node208,
                    node210,
                    node234,
                    node236,
                    node246,
                    node256,
                    node274,
                    node280,
                    node288,
                    node290,
                    node298,
                    node302,
                    node306,
                    node308,
                    node336,
                    node356,
                    node358,
                    node372,
                    node386,
                    node396,
                    node414,
                    node422,
                    node430,
                    node434,
                    node438,
                    node448,
                    node456,
                    node472,
                    node478,
                    node482,
                    node494,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node3 : INode
        {
            public Node3(
                Node15 node15,
                Node36 node36,
                Node72 node72,
                Node87 node87,
                Node90 node90,
                Node126 node126,
                Node138 node138,
                Node141 node141,
                Node144 node144,
                Node150 node150,
                Node156 node156,
                Node174 node174,
                Node186 node186,
                Node204 node204,
                Node210 node210,
                Node213 node213,
                Node225 node225,
                Node279 node279,
                Node282 node282,
                Node288 node288,
                Node315 node315,
                Node321 node321,
                Node336 node336,
                Node342 node342,
                Node345 node345,
                Node357 node357,
                Node363 node363,
                Node366 node366,
                Node369 node369,
                Node405 node405,
                Node414 node414,
                Node429 node429,
                Node432 node432,
                Node438 node438,
                Node441 node441,
                Node447 node447,
                Node489 node489)
            {
                this.Children = new INode[]
                {
                    node15,
                    node36,
                    node72,
                    node87,
                    node90,
                    node126,
                    node138,
                    node141,
                    node144,
                    node150,
                    node156,
                    node174,
                    node186,
                    node204,
                    node210,
                    node213,
                    node225,
                    node279,
                    node282,
                    node288,
                    node315,
                    node321,
                    node336,
                    node342,
                    node345,
                    node357,
                    node363,
                    node366,
                    node369,
                    node405,
                    node414,
                    node429,
                    node432,
                    node438,
                    node441,
                    node447,
                    node489,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node4 : INode
        {
            public Node4(
                Node32 node32,
                Node36 node36,
                Node44 node44,
                Node52 node52,
                Node80 node80,
                Node108 node108,
                Node124 node124,
                Node136 node136,
                Node196 node196,
                Node232 node232,
                Node272 node272,
                Node280 node280,
                Node284 node284,
                Node292 node292,
                Node312 node312,
                Node324 node324,
                Node332 node332,
                Node352 node352,
                Node364 node364,
                Node380 node380,
                Node388 node388,
                Node396 node396,
                Node400 node400,
                Node404 node404,
                Node416 node416,
                Node424 node424,
                Node440 node440,
                Node456 node456,
                Node484 node484)
            {
                this.Children = new INode[]
                {
                    node32,
                    node36,
                    node44,
                    node52,
                    node80,
                    node108,
                    node124,
                    node136,
                    node196,
                    node232,
                    node272,
                    node280,
                    node284,
                    node292,
                    node312,
                    node324,
                    node332,
                    node352,
                    node364,
                    node380,
                    node388,
                    node396,
                    node400,
                    node404,
                    node416,
                    node424,
                    node440,
                    node456,
                    node484,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node5 : INode
        {
            public Node5(
                Node10 node10,
                Node30 node30,
                Node50 node50,
                Node60 node60,
                Node70 node70,
                Node75 node75,
                Node95 node95,
                Node100 node100,
                Node120 node120,
                Node160 node160,
                Node180 node180,
                Node190 node190,
                Node200 node200,
                Node205 node205,
                Node235 node235,
                Node255 node255,
                Node270 node270,
                Node310 node310,
                Node320 node320,
                Node335 node335,
                Node350 node350,
                Node370 node370,
                Node375 node375,
                Node405 node405,
                Node430 node430,
                Node475 node475,
                Node480 node480,
                Node495 node495)
            {
                this.Children = new INode[]
                {
                    node10,
                    node30,
                    node50,
                    node60,
                    node70,
                    node75,
                    node95,
                    node100,
                    node120,
                    node160,
                    node180,
                    node190,
                    node200,
                    node205,
                    node235,
                    node255,
                    node270,
                    node310,
                    node320,
                    node335,
                    node350,
                    node370,
                    node375,
                    node405,
                    node430,
                    node475,
                    node480,
                    node495,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node6 : INode
        {
            public Node6(
                Node66 node66,
                Node84 node84,
                Node90 node90,
                Node114 node114,
                Node150 node150,
                Node180 node180,
                Node192 node192,
                Node204 node204,
                Node216 node216,
                Node234 node234,
                Node240 node240,
                Node396 node396)
            {
                this.Children = new INode[]
                {
                    node66,
                    node84,
                    node90,
                    node114,
                    node150,
                    node180,
                    node192,
                    node204,
                    node216,
                    node234,
                    node240,
                    node396,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node7 : INode
        {
            public Node7(
                Node35 node35,
                Node63 node63,
                Node77 node77,
                Node105 node105,
                Node210 node210,
                Node217 node217,
                Node329 node329,
                Node378 node378,
                Node420 node420,
                Node441 node441,
                Node448 node448,
                Node455 node455)
            {
                this.Children = new INode[]
                {
                    node35,
                    node63,
                    node77,
                    node105,
                    node210,
                    node217,
                    node329,
                    node378,
                    node420,
                    node441,
                    node448,
                    node455,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node8 : INode
        {
            public Node8(
                Node40 node40,
                Node168 node168,
                Node216 node216,
                Node232 node232,
                Node248 node248,
                Node264 node264,
                Node272 node272,
                Node304 node304,
                Node312 node312,
                Node456 node456,
                Node464 node464)
            {
                this.Children = new INode[]
                {
                    node40,
                    node168,
                    node216,
                    node232,
                    node248,
                    node264,
                    node272,
                    node304,
                    node312,
                    node456,
                    node464,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node9 : INode
        {
            public Node9(
                Node45 node45,
                Node144 node144,
                Node216 node216,
                Node315 node315,
                Node324 node324,
                Node342 node342,
                Node351 node351,
                Node387 node387,
                Node405 node405,
                Node441 node441)
            {
                this.Children = new INode[]
                {
                    node45,
                    node144,
                    node216,
                    node315,
                    node324,
                    node342,
                    node351,
                    node387,
                    node405,
                    node441,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node10 : INode
        {
            public Node10(
                Node30 node30,
                Node130 node130,
                Node140 node140,
                Node180 node180,
                Node200 node200,
                Node300 node300,
                Node320 node320,
                Node330 node330,
                Node340 node340,
                Node370 node370,
                Node390 node390)
            {
                this.Children = new INode[]
                {
                    node30,
                    node130,
                    node140,
                    node180,
                    node200,
                    node300,
                    node320,
                    node330,
                    node340,
                    node370,
                    node390,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node11 : INode
        {
            public Node11(
                Node33 node33,
                Node99 node99,
                Node110 node110,
                Node275 node275,
                Node374 node374,
                Node385 node385,
                Node418 node418)
            {
                this.Children = new INode[]
                {
                    node33,
                    node99,
                    node110,
                    node275,
                    node374,
                    node385,
                    node418,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node12 : INode
        {
            public Node12(
                Node60 node60,
                Node96 node96,
                Node420 node420)
            {
                this.Children = new INode[]
                {
                    node60,
                    node96,
                    node420,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node13 : INode
        {
            public Node13(
                Node78 node78,
                Node221 node221,
                Node364 node364,
                Node403 node403,
                Node455 node455)
            {
                this.Children = new INode[]
                {
                    node78,
                    node221,
                    node364,
                    node403,
                    node455,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node14 : INode
        {
            public Node14(
                Node28 node28,
                Node84 node84,
                Node98 node98,
                Node112 node112,
                Node154 node154,
                Node196 node196,
                Node238 node238,
                Node252 node252,
                Node280 node280,
                Node322 node322,
                Node378 node378,
                Node420 node420)
            {
                this.Children = new INode[]
                {
                    node28,
                    node84,
                    node98,
                    node112,
                    node154,
                    node196,
                    node238,
                    node252,
                    node280,
                    node322,
                    node378,
                    node420,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node15 : INode
        {
            public Node15(
                Node330 node330,
                Node405 node405,
                Node465 node465)
            {
                this.Children = new INode[]
                {
                    node330,
                    node405,
                    node465,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node16 : INode
        {
            public Node16(
                Node176 node176,
                Node384 node384,
                Node416 node416,
                Node448 node448)
            {
                this.Children = new INode[]
                {
                    node176,
                    node384,
                    node416,
                    node448,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node17 : INode
        {
            public Node17(
                Node85 node85,
                Node102 node102,
                Node170 node170,
                Node255 node255,
                Node289 node289,
                Node306 node306,
                Node357 node357,
                Node425 node425,
                Node459 node459)
            {
                this.Children = new INode[]
                {
                    node85,
                    node102,
                    node170,
                    node255,
                    node289,
                    node306,
                    node357,
                    node425,
                    node459,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node18 : INode
        {
            public Node18(
                Node72 node72,
                Node90 node90,
                Node198 node198,
                Node270 node270,
                Node378 node378,
                Node414 node414)
            {
                this.Children = new INode[]
                {
                    node72,
                    node90,
                    node198,
                    node270,
                    node378,
                    node414,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node19 : INode
        {
            public Node19(
                Node209 node209,
                Node228 node228,
                Node247 node247,
                Node304 node304,
                Node342 node342,
                Node361 node361,
                Node380 node380,
                Node399 node399,
                Node494 node494)
            {
                this.Children = new INode[]
                {
                    node209,
                    node228,
                    node247,
                    node304,
                    node342,
                    node361,
                    node380,
                    node399,
                    node494,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node20 : INode
        {
            public Node20(
                Node60 node60,
                Node240 node240,
                Node260 node260,
                Node380 node380)
            {
                this.Children = new INode[]
                {
                    node60,
                    node240,
                    node260,
                    node380,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node21 : INode
        {
            public Node21(
                Node147 node147,
                Node210 node210,
                Node483 node483)
            {
                this.Children = new INode[]
                {
                    node147,
                    node210,
                    node483,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node22 : INode
        {
            public Node22(
                Node198 node198,
                Node220 node220,
                Node264 node264,
                Node308 node308)
            {
                this.Children = new INode[]
                {
                    node198,
                    node220,
                    node264,
                    node308,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node23 : INode
        {
            public Node23(
                Node115 node115,
                Node276 node276,
                Node299 node299,
                Node368 node368)
            {
                this.Children = new INode[]
                {
                    node115,
                    node276,
                    node299,
                    node368,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node24 : INode
        {
            public Node24(
                Node96 node96,
                Node240 node240,
                Node384 node384)
            {
                this.Children = new INode[]
                {
                    node96,
                    node240,
                    node384,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node25 : INode
        {
            public Node25(
                Node50 node50,
                Node100 node100,
                Node175 node175,
                Node350 node350)
            {
                this.Children = new INode[]
                {
                    node50,
                    node100,
                    node175,
                    node350,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node26 : INode
        {
            public Node26(
                Node104 node104,
                Node260 node260,
                Node338 node338,
                Node364 node364,
                Node390 node390)
            {
                this.Children = new INode[]
                {
                    node104,
                    node260,
                    node338,
                    node364,
                    node390,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node27 : INode
        {
            public Node27(
                Node81 node81,
                Node378 node378)
            {
                this.Children = new INode[]
                {
                    node81,
                    node378,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node28 : INode
        {
            public Node28(
                Node112 node112,
                Node420 node420)
            {
                this.Children = new INode[]
                {
                    node112,
                    node420,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node29 : INode
        {
            public Node29(
                Node261 node261,
                Node406 node406)
            {
                this.Children = new INode[]
                {
                    node261,
                    node406,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node30 : INode
        {
            public Node30(
                Node150 node150,
                Node210 node210,
                Node270 node270,
                Node480 node480)
            {
                this.Children = new INode[]
                {
                    node150,
                    node210,
                    node270,
                    node480,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node31 : INode
        {
            public Node31(
                Node62 node62,
                Node93 node93,
                Node341 node341,
                Node372 node372,
                Node403 node403,
                Node434 node434)
            {
                this.Children = new INode[]
                {
                    node62,
                    node93,
                    node341,
                    node372,
                    node403,
                    node434,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node32 : INode
        {
            public Node32(
                Node256 node256)
            {
                this.Children = new INode[]
                {
                    node256,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node33 : INode
        {
            public Node33(
                Node198 node198,
                Node330 node330)
            {
                this.Children = new INode[]
                {
                    node198,
                    node330,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node34 : INode
        {
            public Node34(
                Node68 node68,
                Node340 node340,
                Node476 node476)
            {
                this.Children = new INode[]
                {
                    node68,
                    node340,
                    node476,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node35 : INode
        {
            public Node35(
                Node175 node175,
                Node210 node210,
                Node280 node280,
                Node350 node350,
                Node455 node455)
            {
                this.Children = new INode[]
                {
                    node175,
                    node210,
                    node280,
                    node350,
                    node455,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node36 : INode
        {
            public Node36(
                Node108 node108,
                Node180 node180,
                Node360 node360)
            {
                this.Children = new INode[]
                {
                    node108,
                    node180,
                    node360,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node37 : INode
        {
            public Node37(
                Node74 node74,
                Node370 node370)
            {
                this.Children = new INode[]
                {
                    node74,
                    node370,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node38 : INode
        {
            public Node38(
                Node76 node76,
                Node266 node266,
                Node380 node380)
            {
                this.Children = new INode[]
                {
                    node76,
                    node266,
                    node380,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node39 : INode
        {
            public Node39()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node40 : INode
        {
            public Node40(
                Node80 node80,
                Node160 node160,
                Node200 node200,
                Node360 node360,
                Node480 node480)
            {
                this.Children = new INode[]
                {
                    node80,
                    node160,
                    node200,
                    node360,
                    node480,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node41 : INode
        {
            public Node41(
                Node123 node123,
                Node246 node246,
                Node328 node328)
            {
                this.Children = new INode[]
                {
                    node123,
                    node246,
                    node328,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node42 : INode
        {
            public Node42()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node43 : INode
        {
            public Node43()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node44 : INode
        {
            public Node44(
                Node352 node352,
                Node396 node396)
            {
                this.Children = new INode[]
                {
                    node352,
                    node396,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node45 : INode
        {
            public Node45(
                Node135 node135)
            {
                this.Children = new INode[]
                {
                    node135,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node46 : INode
        {
            public Node46(
                Node92 node92,
                Node230 node230,
                Node322 node322)
            {
                this.Children = new INode[]
                {
                    node92,
                    node230,
                    node322,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node47 : INode
        {
            public Node47(
                Node329 node329)
            {
                this.Children = new INode[]
                {
                    node329,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node48 : INode
        {
            public Node48(
                Node144 node144,
                Node288 node288,
                Node336 node336)
            {
                this.Children = new INode[]
                {
                    node144,
                    node288,
                    node336,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node49 : INode
        {
            public Node49(
                Node147 node147,
                Node196 node196,
                Node441 node441,
                Node490 node490)
            {
                this.Children = new INode[]
                {
                    node147,
                    node196,
                    node441,
                    node490,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node50 : INode
        {
            public Node50()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node51 : INode
        {
            public Node51(
                Node204 node204)
            {
                this.Children = new INode[]
                {
                    node204,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node52 : INode
        {
            public Node52()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node53 : INode
        {
            public Node53(
                Node371 node371)
            {
                this.Children = new INode[]
                {
                    node371,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node54 : INode
        {
            public Node54(
                Node270 node270)
            {
                this.Children = new INode[]
                {
                    node270,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node55 : INode
        {
            public Node55()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node56 : INode
        {
            public Node56()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node57 : INode
        {
            public Node57(
                Node285 node285)
            {
                this.Children = new INode[]
                {
                    node285,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node58 : INode
        {
            public Node58()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node59 : INode
        {
            public Node59(
                Node177 node177,
                Node236 node236,
                Node354 node354,
                Node472 node472)
            {
                this.Children = new INode[]
                {
                    node177,
                    node236,
                    node354,
                    node472,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node60 : INode
        {
            public Node60(
                Node480 node480)
            {
                this.Children = new INode[]
                {
                    node480,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node61 : INode
        {
            public Node61(
                Node122 node122)
            {
                this.Children = new INode[]
                {
                    node122,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node62 : INode
        {
            public Node62(
                Node248 node248,
                Node310 node310)
            {
                this.Children = new INode[]
                {
                    node248,
                    node310,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node63 : INode
        {
            public Node63(
                Node126 node126)
            {
                this.Children = new INode[]
                {
                    node126,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node64 : INode
        {
            public Node64(
                Node192 node192)
            {
                this.Children = new INode[]
                {
                    node192,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node65 : INode
        {
            public Node65(
                Node260 node260,
                Node455 node455)
            {
                this.Children = new INode[]
                {
                    node260,
                    node455,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node66 : INode
        {
            public Node66(
                Node462 node462)
            {
                this.Children = new INode[]
                {
                    node462,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node67 : INode
        {
            public Node67(
                Node201 node201)
            {
                this.Children = new INode[]
                {
                    node201,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node68 : INode
        {
            public Node68(
                Node136 node136,
                Node476 node476)
            {
                this.Children = new INode[]
                {
                    node136,
                    node476,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node69 : INode
        {
            public Node69(
                Node207 node207)
            {
                this.Children = new INode[]
                {
                    node207,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node70 : INode
        {
            public Node70(
                Node490 node490)
            {
                this.Children = new INode[]
                {
                    node490,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node71 : INode
        {
            public Node71(
                Node142 node142,
                Node355 node355)
            {
                this.Children = new INode[]
                {
                    node142,
                    node355,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node72 : INode
        {
            public Node72(
                Node144 node144,
                Node288 node288)
            {
                this.Children = new INode[]
                {
                    node144,
                    node288,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node73 : INode
        {
            public Node73()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node74 : INode
        {
            public Node74(
                Node222 node222,
                Node370 node370)
            {
                this.Children = new INode[]
                {
                    node222,
                    node370,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node75 : INode
        {
            public Node75()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node76 : INode
        {
            public Node76(
                Node304 node304)
            {
                this.Children = new INode[]
                {
                    node304,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node77 : INode
        {
            public Node77(
                Node308 node308,
                Node385 node385,
                Node462 node462)
            {
                this.Children = new INode[]
                {
                    node308,
                    node385,
                    node462,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node78 : INode
        {
            public Node78(
                Node234 node234)
            {
                this.Children = new INode[]
                {
                    node234,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node79 : INode
        {
            public Node79(
                Node237 node237)
            {
                this.Children = new INode[]
                {
                    node237,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node80 : INode
        {
            public Node80()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node81 : INode
        {
            public Node81()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node82 : INode
        {
            public Node82()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node83 : INode
        {
            public Node83(
                Node249 node249,
                Node498 node498)
            {
                this.Children = new INode[]
                {
                    node249,
                    node498,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node84 : INode
        {
            public Node84(
                Node168 node168,
                Node420 node420)
            {
                this.Children = new INode[]
                {
                    node168,
                    node420,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node85 : INode
        {
            public Node85(
                Node255 node255)
            {
                this.Children = new INode[]
                {
                    node255,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node86 : INode
        {
            public Node86()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node87 : INode
        {
            public Node87(
                Node261 node261)
            {
                this.Children = new INode[]
                {
                    node261,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node88 : INode
        {
            public Node88()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node89 : INode
        {
            public Node89()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node90 : INode
        {
            public Node90()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node91 : INode
        {
            public Node91()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node92 : INode
        {
            public Node92()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node93 : INode
        {
            public Node93()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node94 : INode
        {
            public Node94()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node95 : INode
        {
            public Node95(
                Node285 node285,
                Node380 node380)
            {
                this.Children = new INode[]
                {
                    node285,
                    node380,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node96 : INode
        {
            public Node96()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node97 : INode
        {
            public Node97()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node98 : INode
        {
            public Node98()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node99 : INode
        {
            public Node99(
                Node396 node396,
                Node495 node495)
            {
                this.Children = new INode[]
                {
                    node396,
                    node495,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node100 : INode
        {
            public Node100(
                Node400 node400)
            {
                this.Children = new INode[]
                {
                    node400,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node101 : INode
        {
            public Node101()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node102 : INode
        {
            public Node102()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node103 : INode
        {
            public Node103()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node104 : INode
        {
            public Node104()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node105 : INode
        {
            public Node105()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node106 : INode
        {
            public Node106(
                Node424 node424)
            {
                this.Children = new INode[]
                {
                    node424,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node107 : INode
        {
            public Node107(
                Node214 node214)
            {
                this.Children = new INode[]
                {
                    node214,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node108 : INode
        {
            public Node108(
                Node216 node216)
            {
                this.Children = new INode[]
                {
                    node216,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node109 : INode
        {
            public Node109(
                Node327 node327,
                Node436 node436)
            {
                this.Children = new INode[]
                {
                    node327,
                    node436,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node110 : INode
        {
            public Node110()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node111 : INode
        {
            public Node111()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node112 : INode
        {
            public Node112()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node113 : INode
        {
            public Node113(
                Node226 node226)
            {
                this.Children = new INode[]
                {
                    node226,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node114 : INode
        {
            public Node114()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node115 : INode
        {
            public Node115()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node116 : INode
        {
            public Node116(
                Node348 node348)
            {
                this.Children = new INode[]
                {
                    node348,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node117 : INode
        {
            public Node117()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node118 : INode
        {
            public Node118(
                Node236 node236)
            {
                this.Children = new INode[]
                {
                    node236,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node119 : INode
        {
            public Node119(
                Node357 node357)
            {
                this.Children = new INode[]
                {
                    node357,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node120 : INode
        {
            public Node120()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node121 : INode
        {
            public Node121(
                Node363 node363)
            {
                this.Children = new INode[]
                {
                    node363,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node122 : INode
        {
            public Node122(
                Node244 node244)
            {
                this.Children = new INode[]
                {
                    node244,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node123 : INode
        {
            public Node123()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node124 : INode
        {
            public Node124(
                Node248 node248,
                Node496 node496)
            {
                this.Children = new INode[]
                {
                    node248,
                    node496,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node125 : INode
        {
            public Node125()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node126 : INode
        {
            public Node126()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node127 : INode
        {
            public Node127()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node128 : INode
        {
            public Node128()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node129 : INode
        {
            public Node129()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node130 : INode
        {
            public Node130()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node131 : INode
        {
            public Node131()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node132 : INode
        {
            public Node132()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node133 : INode
        {
            public Node133()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node134 : INode
        {
            public Node134()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node135 : INode
        {
            public Node135()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node136 : INode
        {
            public Node136()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node137 : INode
        {
            public Node137()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node138 : INode
        {
            public Node138(
                Node414 node414)
            {
                this.Children = new INode[]
                {
                    node414,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node139 : INode
        {
            public Node139(
                Node278 node278)
            {
                this.Children = new INode[]
                {
                    node278,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node140 : INode
        {
            public Node140()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node141 : INode
        {
            public Node141()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node142 : INode
        {
            public Node142()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node143 : INode
        {
            public Node143()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node144 : INode
        {
            public Node144()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node145 : INode
        {
            public Node145()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node146 : INode
        {
            public Node146(
                Node438 node438)
            {
                this.Children = new INode[]
                {
                    node438,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node147 : INode
        {
            public Node147()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node148 : INode
        {
            public Node148(
                Node296 node296)
            {
                this.Children = new INode[]
                {
                    node296,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node149 : INode
        {
            public Node149()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node150 : INode
        {
            public Node150()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node151 : INode
        {
            public Node151()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node152 : INode
        {
            public Node152(
                Node304 node304)
            {
                this.Children = new INode[]
                {
                    node304,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node153 : INode
        {
            public Node153(
                Node459 node459)
            {
                this.Children = new INode[]
                {
                    node459,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node154 : INode
        {
            public Node154()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node155 : INode
        {
            public Node155()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node156 : INode
        {
            public Node156()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node157 : INode
        {
            public Node157()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node158 : INode
        {
            public Node158()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node159 : INode
        {
            public Node159()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node160 : INode
        {
            public Node160()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node161 : INode
        {
            public Node161()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node162 : INode
        {
            public Node162()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node163 : INode
        {
            public Node163()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node164 : INode
        {
            public Node164(
                Node328 node328)
            {
                this.Children = new INode[]
                {
                    node328,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node165 : INode
        {
            public Node165(
                Node495 node495)
            {
                this.Children = new INode[]
                {
                    node495,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node166 : INode
        {
            public Node166(
                Node498 node498)
            {
                this.Children = new INode[]
                {
                    node498,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node167 : INode
        {
            public Node167()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node168 : INode
        {
            public Node168()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node169 : INode
        {
            public Node169()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node170 : INode
        {
            public Node170()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node171 : INode
        {
            public Node171()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node172 : INode
        {
            public Node172()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node173 : INode
        {
            public Node173()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node174 : INode
        {
            public Node174()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node175 : INode
        {
            public Node175()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node176 : INode
        {
            public Node176()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node177 : INode
        {
            public Node177()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node178 : INode
        {
            public Node178()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node179 : INode
        {
            public Node179()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node180 : INode
        {
            public Node180()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node181 : INode
        {
            public Node181()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node182 : INode
        {
            public Node182()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node183 : INode
        {
            public Node183()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node184 : INode
        {
            public Node184()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node185 : INode
        {
            public Node185()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node186 : INode
        {
            public Node186(
                Node372 node372)
            {
                this.Children = new INode[]
                {
                    node372,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node187 : INode
        {
            public Node187(
                Node374 node374)
            {
                this.Children = new INode[]
                {
                    node374,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node188 : INode
        {
            public Node188()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node189 : INode
        {
            public Node189()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node190 : INode
        {
            public Node190()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node191 : INode
        {
            public Node191(
                Node382 node382)
            {
                this.Children = new INode[]
                {
                    node382,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node192 : INode
        {
            public Node192()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node193 : INode
        {
            public Node193(
                Node386 node386)
            {
                this.Children = new INode[]
                {
                    node386,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node194 : INode
        {
            public Node194()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node195 : INode
        {
            public Node195(
                Node390 node390)
            {
                this.Children = new INode[]
                {
                    node390,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node196 : INode
        {
            public Node196()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node197 : INode
        {
            public Node197()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node198 : INode
        {
            public Node198()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node199 : INode
        {
            public Node199(
                Node398 node398)
            {
                this.Children = new INode[]
                {
                    node398,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node200 : INode
        {
            public Node200(
                Node400 node400)
            {
                this.Children = new INode[]
                {
                    node400,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node201 : INode
        {
            public Node201(
                Node402 node402)
            {
                this.Children = new INode[]
                {
                    node402,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node202 : INode
        {
            public Node202()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node203 : INode
        {
            public Node203()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node204 : INode
        {
            public Node204(
                Node408 node408)
            {
                this.Children = new INode[]
                {
                    node408,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node205 : INode
        {
            public Node205(
                Node410 node410)
            {
                this.Children = new INode[]
                {
                    node410,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node206 : INode
        {
            public Node206()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node207 : INode
        {
            public Node207(
                Node414 node414)
            {
                this.Children = new INode[]
                {
                    node414,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node208 : INode
        {
            public Node208()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node209 : INode
        {
            public Node209()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node210 : INode
        {
            public Node210()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node211 : INode
        {
            public Node211()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node212 : INode
        {
            public Node212(
                Node424 node424)
            {
                this.Children = new INode[]
                {
                    node424,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node213 : INode
        {
            public Node213()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node214 : INode
        {
            public Node214()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node215 : INode
        {
            public Node215()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node216 : INode
        {
            public Node216(
                Node432 node432)
            {
                this.Children = new INode[]
                {
                    node432,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node217 : INode
        {
            public Node217()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node218 : INode
        {
            public Node218()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node219 : INode
        {
            public Node219()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node220 : INode
        {
            public Node220()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node221 : INode
        {
            public Node221(
                Node442 node442)
            {
                this.Children = new INode[]
                {
                    node442,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node222 : INode
        {
            public Node222()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node223 : INode
        {
            public Node223()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node224 : INode
        {
            public Node224()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node225 : INode
        {
            public Node225()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node226 : INode
        {
            public Node226(
                Node452 node452)
            {
                this.Children = new INode[]
                {
                    node452,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node227 : INode
        {
            public Node227()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node228 : INode
        {
            public Node228()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node229 : INode
        {
            public Node229()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node230 : INode
        {
            public Node230()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node231 : INode
        {
            public Node231()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node232 : INode
        {
            public Node232()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node233 : INode
        {
            public Node233()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node234 : INode
        {
            public Node234()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node235 : INode
        {
            public Node235()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node236 : INode
        {
            public Node236(
                Node472 node472)
            {
                this.Children = new INode[]
                {
                    node472,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node237 : INode
        {
            public Node237()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node238 : INode
        {
            public Node238(
                Node476 node476)
            {
                this.Children = new INode[]
                {
                    node476,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node239 : INode
        {
            public Node239()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node240 : INode
        {
            public Node240()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node241 : INode
        {
            public Node241(
                Node482 node482)
            {
                this.Children = new INode[]
                {
                    node482,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node242 : INode
        {
            public Node242()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node243 : INode
        {
            public Node243(
                Node486 node486)
            {
                this.Children = new INode[]
                {
                    node486,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node244 : INode
        {
            public Node244()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node245 : INode
        {
            public Node245(
                Node490 node490)
            {
                this.Children = new INode[]
                {
                    node490,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node246 : INode
        {
            public Node246(
                Node492 node492)
            {
                this.Children = new INode[]
                {
                    node492,
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node247 : INode
        {
            public Node247()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node248 : INode
        {
            public Node248()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node249 : INode
        {
            public Node249()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node250 : INode
        {
            public Node250()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node251 : INode
        {
            public Node251()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node252 : INode
        {
            public Node252()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node253 : INode
        {
            public Node253()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node254 : INode
        {
            public Node254()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node255 : INode
        {
            public Node255()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node256 : INode
        {
            public Node256()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node257 : INode
        {
            public Node257()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node258 : INode
        {
            public Node258()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node259 : INode
        {
            public Node259()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node260 : INode
        {
            public Node260()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node261 : INode
        {
            public Node261()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node262 : INode
        {
            public Node262()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node263 : INode
        {
            public Node263()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node264 : INode
        {
            public Node264()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node265 : INode
        {
            public Node265()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node266 : INode
        {
            public Node266()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node267 : INode
        {
            public Node267()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node268 : INode
        {
            public Node268()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node269 : INode
        {
            public Node269()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node270 : INode
        {
            public Node270()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node271 : INode
        {
            public Node271()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node272 : INode
        {
            public Node272()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node273 : INode
        {
            public Node273()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node274 : INode
        {
            public Node274()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node275 : INode
        {
            public Node275()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node276 : INode
        {
            public Node276()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node277 : INode
        {
            public Node277()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node278 : INode
        {
            public Node278()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node279 : INode
        {
            public Node279()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node280 : INode
        {
            public Node280()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node281 : INode
        {
            public Node281()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node282 : INode
        {
            public Node282()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node283 : INode
        {
            public Node283()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node284 : INode
        {
            public Node284()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node285 : INode
        {
            public Node285()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node286 : INode
        {
            public Node286()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node287 : INode
        {
            public Node287()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node288 : INode
        {
            public Node288()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node289 : INode
        {
            public Node289()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node290 : INode
        {
            public Node290()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node291 : INode
        {
            public Node291()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node292 : INode
        {
            public Node292()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node293 : INode
        {
            public Node293()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node294 : INode
        {
            public Node294()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node295 : INode
        {
            public Node295()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node296 : INode
        {
            public Node296()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node297 : INode
        {
            public Node297()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node298 : INode
        {
            public Node298()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node299 : INode
        {
            public Node299()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node300 : INode
        {
            public Node300()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node301 : INode
        {
            public Node301()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node302 : INode
        {
            public Node302()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node303 : INode
        {
            public Node303()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node304 : INode
        {
            public Node304()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node305 : INode
        {
            public Node305()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node306 : INode
        {
            public Node306()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node307 : INode
        {
            public Node307()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node308 : INode
        {
            public Node308()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node309 : INode
        {
            public Node309()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node310 : INode
        {
            public Node310()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node311 : INode
        {
            public Node311()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node312 : INode
        {
            public Node312()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node313 : INode
        {
            public Node313()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node314 : INode
        {
            public Node314()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node315 : INode
        {
            public Node315()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node316 : INode
        {
            public Node316()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node317 : INode
        {
            public Node317()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node318 : INode
        {
            public Node318()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node319 : INode
        {
            public Node319()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node320 : INode
        {
            public Node320()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node321 : INode
        {
            public Node321()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node322 : INode
        {
            public Node322()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node323 : INode
        {
            public Node323()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node324 : INode
        {
            public Node324()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node325 : INode
        {
            public Node325()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node326 : INode
        {
            public Node326()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node327 : INode
        {
            public Node327()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node328 : INode
        {
            public Node328()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node329 : INode
        {
            public Node329()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node330 : INode
        {
            public Node330()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node331 : INode
        {
            public Node331()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node332 : INode
        {
            public Node332()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node333 : INode
        {
            public Node333()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node334 : INode
        {
            public Node334()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node335 : INode
        {
            public Node335()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node336 : INode
        {
            public Node336()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node337 : INode
        {
            public Node337()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node338 : INode
        {
            public Node338()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node339 : INode
        {
            public Node339()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node340 : INode
        {
            public Node340()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node341 : INode
        {
            public Node341()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node342 : INode
        {
            public Node342()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node343 : INode
        {
            public Node343()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node344 : INode
        {
            public Node344()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node345 : INode
        {
            public Node345()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node346 : INode
        {
            public Node346()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node347 : INode
        {
            public Node347()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node348 : INode
        {
            public Node348()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node349 : INode
        {
            public Node349()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node350 : INode
        {
            public Node350()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node351 : INode
        {
            public Node351()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node352 : INode
        {
            public Node352()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node353 : INode
        {
            public Node353()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node354 : INode
        {
            public Node354()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node355 : INode
        {
            public Node355()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node356 : INode
        {
            public Node356()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node357 : INode
        {
            public Node357()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node358 : INode
        {
            public Node358()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node359 : INode
        {
            public Node359()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node360 : INode
        {
            public Node360()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node361 : INode
        {
            public Node361()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node362 : INode
        {
            public Node362()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node363 : INode
        {
            public Node363()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node364 : INode
        {
            public Node364()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node365 : INode
        {
            public Node365()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node366 : INode
        {
            public Node366()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node367 : INode
        {
            public Node367()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node368 : INode
        {
            public Node368()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node369 : INode
        {
            public Node369()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node370 : INode
        {
            public Node370()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node371 : INode
        {
            public Node371()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node372 : INode
        {
            public Node372()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node373 : INode
        {
            public Node373()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node374 : INode
        {
            public Node374()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node375 : INode
        {
            public Node375()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node376 : INode
        {
            public Node376()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node377 : INode
        {
            public Node377()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node378 : INode
        {
            public Node378()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node379 : INode
        {
            public Node379()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node380 : INode
        {
            public Node380()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node381 : INode
        {
            public Node381()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node382 : INode
        {
            public Node382()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node383 : INode
        {
            public Node383()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node384 : INode
        {
            public Node384()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node385 : INode
        {
            public Node385()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node386 : INode
        {
            public Node386()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node387 : INode
        {
            public Node387()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node388 : INode
        {
            public Node388()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node389 : INode
        {
            public Node389()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node390 : INode
        {
            public Node390()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node391 : INode
        {
            public Node391()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node392 : INode
        {
            public Node392()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node393 : INode
        {
            public Node393()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node394 : INode
        {
            public Node394()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node395 : INode
        {
            public Node395()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node396 : INode
        {
            public Node396()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node397 : INode
        {
            public Node397()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node398 : INode
        {
            public Node398()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node399 : INode
        {
            public Node399()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node400 : INode
        {
            public Node400()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node401 : INode
        {
            public Node401()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node402 : INode
        {
            public Node402()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node403 : INode
        {
            public Node403()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node404 : INode
        {
            public Node404()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node405 : INode
        {
            public Node405()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node406 : INode
        {
            public Node406()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node407 : INode
        {
            public Node407()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node408 : INode
        {
            public Node408()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node409 : INode
        {
            public Node409()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node410 : INode
        {
            public Node410()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node411 : INode
        {
            public Node411()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node412 : INode
        {
            public Node412()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node413 : INode
        {
            public Node413()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node414 : INode
        {
            public Node414()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node415 : INode
        {
            public Node415()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node416 : INode
        {
            public Node416()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node417 : INode
        {
            public Node417()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node418 : INode
        {
            public Node418()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node419 : INode
        {
            public Node419()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node420 : INode
        {
            public Node420()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node421 : INode
        {
            public Node421()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node422 : INode
        {
            public Node422()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node423 : INode
        {
            public Node423()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node424 : INode
        {
            public Node424()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node425 : INode
        {
            public Node425()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node426 : INode
        {
            public Node426()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node427 : INode
        {
            public Node427()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node428 : INode
        {
            public Node428()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node429 : INode
        {
            public Node429()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node430 : INode
        {
            public Node430()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node431 : INode
        {
            public Node431()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node432 : INode
        {
            public Node432()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node433 : INode
        {
            public Node433()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node434 : INode
        {
            public Node434()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node435 : INode
        {
            public Node435()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node436 : INode
        {
            public Node436()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node437 : INode
        {
            public Node437()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node438 : INode
        {
            public Node438()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node439 : INode
        {
            public Node439()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node440 : INode
        {
            public Node440()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node441 : INode
        {
            public Node441()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node442 : INode
        {
            public Node442()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node443 : INode
        {
            public Node443()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node444 : INode
        {
            public Node444()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node445 : INode
        {
            public Node445()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node446 : INode
        {
            public Node446()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node447 : INode
        {
            public Node447()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node448 : INode
        {
            public Node448()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node449 : INode
        {
            public Node449()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node450 : INode
        {
            public Node450()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node451 : INode
        {
            public Node451()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node452 : INode
        {
            public Node452()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node453 : INode
        {
            public Node453()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node454 : INode
        {
            public Node454()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node455 : INode
        {
            public Node455()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node456 : INode
        {
            public Node456()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node457 : INode
        {
            public Node457()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node458 : INode
        {
            public Node458()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node459 : INode
        {
            public Node459()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node460 : INode
        {
            public Node460()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node461 : INode
        {
            public Node461()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node462 : INode
        {
            public Node462()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node463 : INode
        {
            public Node463()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node464 : INode
        {
            public Node464()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node465 : INode
        {
            public Node465()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node466 : INode
        {
            public Node466()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node467 : INode
        {
            public Node467()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node468 : INode
        {
            public Node468()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node469 : INode
        {
            public Node469()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node470 : INode
        {
            public Node470()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node471 : INode
        {
            public Node471()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node472 : INode
        {
            public Node472()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node473 : INode
        {
            public Node473()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node474 : INode
        {
            public Node474()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node475 : INode
        {
            public Node475()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node476 : INode
        {
            public Node476()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node477 : INode
        {
            public Node477()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node478 : INode
        {
            public Node478()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node479 : INode
        {
            public Node479()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node480 : INode
        {
            public Node480()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node481 : INode
        {
            public Node481()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node482 : INode
        {
            public Node482()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node483 : INode
        {
            public Node483()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node484 : INode
        {
            public Node484()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node485 : INode
        {
            public Node485()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node486 : INode
        {
            public Node486()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node487 : INode
        {
            public Node487()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node488 : INode
        {
            public Node488()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node489 : INode
        {
            public Node489()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node490 : INode
        {
            public Node490()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node491 : INode
        {
            public Node491()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node492 : INode
        {
            public Node492()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node493 : INode
        {
            public Node493()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node494 : INode
        {
            public Node494()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node495 : INode
        {
            public Node495()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node496 : INode
        {
            public Node496()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node497 : INode
        {
            public Node497()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node498 : INode
        {
            public Node498()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }

        public class Node499 : INode
        {
            public Node499()
            {
                this.Children = new INode[]
                {
                };
            }

            public IReadOnlyList<INode> Children { get; }

            public IEnumerable<INode> AllChildren => this.Children.Concat(this.Children.SelectMany(c => c.AllChildren));
        }
    }
}