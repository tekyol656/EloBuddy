using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy.SDK.Menu;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace Aka_s_Vayne_reworked
{
    class MenuManager
    {
        public static Menu VMenu,
            Qsettings,
            ComboMenu,
            CondemnMenu,
            HarassMenu,
            FleeMenu,
            LaneClearMenu,
            JungleClearMenu,
            MiscMenu,
            ItemMenu,
            DrawingMenu;

        public static void Load()
        {
            Mainmenu();
            Combomenu();
            QSettings();
            Condemnmenu();
            Harassmenu();
            Fleemenu();
            LaneClearmenu();
            JungleClearmenu();
            Miscmenu();
            Itemmenu();
            Drawingmenu();
        }

        public static void Mainmenu()
        {
            VMenu = MainMenu.AddMenu("Aka´s Vayne", "akavayne");
            VMenu.AddGroupLabel("Welcome to my Vayne Addon have fun! :)");
            VMenu.AddGroupLabel("Made by Aka *-*");
        }

        public static void Combomenu()
        {
            ComboMenu = VMenu.AddSubMenu("Combo", "Combo");
            ComboMenu.AddGroupLabel("Combo");
            ComboMenu.AddGroupLabel("Q Mode");
            ComboMenu.AddLabel("Smart mode disabled. Use New or Old.");
            var qmode = ComboMenu.Add("Qmode", new ComboBox("Q Mode", 4, "Mouse", "Smart(disabled)", "Kite", "Old", "New"));
            qmode.OnValueChange += delegate
            {
                if (qmode.CurrentValue == 1)
                {
                    Qsettings["UseSafeQ"].IsVisible = true;
                    Qsettings["UseQE"].IsVisible = true;
                    Qsettings["QE"].IsVisible = true;
                    Qsettings["UseQspam"].IsVisible = true;
                    Qsettings["QNmode"].IsVisible = false;
                    Qsettings["QNenemies"].IsVisible = false;
                    Qsettings["QNWall"].IsVisible = false;
                    Qsettings["QNTurret"].IsVisible = false;
                }
                if (qmode.CurrentValue == 3)
                {
                    Qsettings["UseSafeQ"].IsVisible = false;
                    Qsettings["UseQE"].IsVisible = false;
                    Qsettings["QE"].IsVisible = false;
                    Qsettings["UseQspam"].IsVisible = false;
                    Qsettings["QNmode"].IsVisible = false;
                    Qsettings["QNenemies"].IsVisible = false;
                    Qsettings["QNWall"].IsVisible = false;
                    Qsettings["QNTurret"].IsVisible = false;
                }
                if (qmode.CurrentValue == 2)
                {
                    Qsettings["UseSafeQ"].IsVisible = false;
                    Qsettings["UseQE"].IsVisible = false;
                    Qsettings["QE"].IsVisible = false;
                    Qsettings["UseQspam"].IsVisible = false;
                    Qsettings["QNmode"].IsVisible = false;
                    Qsettings["QNenemies"].IsVisible = false;
                    Qsettings["QNWall"].IsVisible = false;
                    Qsettings["QNTurret"].IsVisible = false;
                }
                if (qmode.CurrentValue == 0)
                {
                    Qsettings["UseSafeQ"].IsVisible = false;
                    Qsettings["UseQE"].IsVisible = false;
                    Qsettings["QE"].IsVisible = false;
                    Qsettings["UseQspam"].IsVisible = false;
                    Qsettings["QNmode"].IsVisible = false;
                    Qsettings["QNenemies"].IsVisible = false;
                    Qsettings["QNWall"].IsVisible = false;
                    Qsettings["QNTurret"].IsVisible = false;
                }
                if (qmode.CurrentValue == 4)
                {
                    Qsettings["UseSafeQ"].IsVisible = false;
                    Qsettings["UseQE"].IsVisible = false;
                    Qsettings["QE"].IsVisible = false;
                    Qsettings["UseQspam"].IsVisible = false;
                    Qsettings["QNmode"].IsVisible = true;
                    Qsettings["QNenemies"].IsVisible = true;
                    Qsettings["QNWall"].IsVisible = true;
                    Qsettings["QNTurret"].IsVisible = true;
                }
            };
            ComboMenu.Add("Qmode2", new ComboBox("Smart Mode", 0, "Aggressive", "Defensive"));
            ComboMenu.Add("UseQwhen", new ComboBox("Use Q", 0, "After Attack", "Before Attack", "Never"));
            ComboMenu.AddGroupLabel("AA Resets");
            ComboMenu.AddLabel("Once you untick´d the AA Reset you have to reload[F5]");
            ComboMenu.Add("AAReset", new CheckBox("Use custom Orbwalk for faster Kite"));
            ComboMenu.AddLabel("If your AA´s Cancel use this or deactivate the custom Orbwalk.");
            ComboMenu.Add("AACancel", new Slider("AA Cancel", 0, 0, 20));
            ComboMenu.AddGroupLabel("W Settings");
            ComboMenu.Add("focusw", new CheckBox("Focus W", false));
            ComboMenu.AddGroupLabel("E Settings");
            ComboMenu.Add("Ekill", new CheckBox("Use E if killable?"));
            ComboMenu.Add("comboUseE", new CheckBox("Use E"));
            ComboMenu.AddGroupLabel("R Settings");
            ComboMenu.Add("comboUseR", new CheckBox("Use R", false));
            ComboMenu.Add("comboRSlider", new Slider("Use R if", 2, 1, 5));
            ComboMenu.Add("RnoAA", new CheckBox("No AA while stealth", false));
            ComboMenu.Add("RnoAAs", new Slider("No AA stealth when >= enemy in range", 2, 0, 5));
        }

        public static void QSettings()
        {
            Qsettings = VMenu.AddSubMenu("Q Settings", "Q Settings");
            Qsettings.AddGroupLabel("Q Settings");
            Qsettings.AddLabel("In Burstmode Vayne will Tumble in Walls for a faster Reset.");
            Qsettings.Add("Mirin", new CheckBox("Burstmode"));
            //smart
            Qsettings.Add("UseSafeQ", new CheckBox("Dynamic Q Safety?", false)).IsVisible = true;
            Qsettings.Add("UseQE", new CheckBox("Dont Q into enemies?", false)).IsVisible = true;
            Qsettings.Add("QE", new CheckBox("Try to QE?", false)).IsVisible = true;
            Qsettings.Add("UseQspam", new CheckBox("Ignore checks", false)).IsVisible = true;
            //new
            Qsettings.Add("QNmode", new ComboBox("New Mode", 1, "Side", "Safe Position")).IsVisible = false;
            Qsettings.Add("QNenemies", new Slider("Block Q in x enemies", 3, 5, 0)).IsVisible = false;
            Qsettings.Add("QNWall", new CheckBox("Block Q in Wall", true)).IsVisible = false;
            Qsettings.Add("QNTurret", new CheckBox("Block Q Undertower", true)).IsVisible = false;

        }

        public static void Condemnmenu()
        {
            CondemnMenu = VMenu.AddSubMenu("Condemn", "Condemn");
            CondemnMenu.AddGroupLabel("Condemn");
            CondemnMenu.AddLabel("Shine + Aka disabled for now. Use Marksman.");
            CondemnMenu.Add("Condemnmode", new ComboBox("Condemn Mode", 2, "Best", "New", "Marksman", "Shine(disabled)", "Aka(disabled)"));
            CondemnMenu.Add("UseEauto", new CheckBox("Use auto E?"));
            CondemnMenu.Add("UseEc", new CheckBox("Only Stun current target?", false));
            CondemnMenu.Add("condemnPercent", new Slider("Condemn Hitchance %", 33, 1));
            CondemnMenu.Add("pushDistance", new Slider("Condemn Push Distance", 420, 350, 470));
            CondemnMenu.Add("noeaa", new Slider("No E if target can be killed with x AA´s", 0, 0, 4));
            CondemnMenu.Add("trinket", new CheckBox("Use trinket bush?"));
            CondemnMenu.Add("j4flag", new CheckBox("Condemn to J4 Flags?"));
            CondemnMenu.AddGroupLabel("Mechanics");
            CondemnMenu.Add("flashe", new KeyBind("Flash Condemn!", false, KeyBind.BindTypes.HoldActive, 'Y'));
            CondemnMenu.Add("insece", new KeyBind("Flash Insec!", false, KeyBind.BindTypes.HoldActive, 'Z'));
            CondemnMenu.Add("insecmodes", new ComboBox("Insec Mode", 0, "To Allys", "To Tower", "To Mouse"));
        }

        public static void Harassmenu()
        {
            HarassMenu = VMenu.AddSubMenu("Harass", "Harass");
            HarassMenu.AddGroupLabel("Harass");
            HarassMenu.AddLabel("I would prefer to tick only 1 of the Options, I prefer the Q one.");
            HarassMenu.Add("UseQHarass", new CheckBox("Use Q(if 2 W stacks)"));
            HarassMenu.Add("UseEHarass", new CheckBox("Use E(if 2 W stacks)", false));
            HarassMenu.Add("UseCHarass", new CheckBox("Use Combo: AA -> Q+AA -> E(working propably)", false));
            HarassMenu.Add("ManaHarass", new Slider("Maximum mana usage in percent ({0}%)", 40));
        }

        public static void Fleemenu()
        {
            FleeMenu = VMenu.AddSubMenu("Flee", "Flee");
            FleeMenu.AddGroupLabel("Flee");
            FleeMenu.Add("FleeUseQ", new CheckBox("Use Q"));
            FleeMenu.Add("FleeUseE", new CheckBox("Use E"));
        }

        public static void LaneClearmenu()
        {
            LaneClearMenu = VMenu.AddSubMenu("LaneClear", "LaneClear");
            LaneClearMenu.AddGroupLabel("LaneClear");
            LaneClearMenu.Add("LCQ", new CheckBox("Use Q"));
            LaneClearMenu.Add("LCQMana", new Slider("Maximum mana usage in percent ({0}%)", 40));

        }

        public static void JungleClearmenu()
        {
            JungleClearMenu = VMenu.AddSubMenu("JungleClear", "JungleClear");
            JungleClearMenu.AddGroupLabel("JungleClear");
            JungleClearMenu.Add("JCQ", new CheckBox("Use Q"));
            JungleClearMenu.Add("JCE", new CheckBox("Use E"));
        }

        public static void Miscmenu()
        {
            MiscMenu = VMenu.AddSubMenu("Misc", "Misc");
            MiscMenu.AddGroupLabel("Misc");
            MiscMenu.AddLabel("Credits to Fluxy:");
            MiscMenu.Add("GapcloseE", new CheckBox("Gapclose E"));
            MiscMenu.Add("AntiRengar", new CheckBox("Anti Rengar"));
            MiscMenu.Add("AntiPanth", new CheckBox("Anti Pantheon"));
            MiscMenu.Add("fpsdrop", new CheckBox("Anti Fps Drop", false));
            MiscMenu.Add("InterruptE", new CheckBox("Interrupt Spells using E?"));
            MiscMenu.Add("LowLifeE", new CheckBox("Low Life E", false));
            MiscMenu.Add("dangerLevel", new ComboBox("Interrupt E Dangerlevel ", 2, "Low", "Medium", "High"));
            MiscMenu.AddGroupLabel("Utility");
            MiscMenu.Add("skinhack", new CheckBox("Activate Skin hack"));
            MiscMenu.Add("skinId", new ComboBox("Skin Hack", 0, "Default", "Vindicator", "Aristocrat", "Dragonslayer", "Heartseeker", "SKT T1", "Arclight", "Vayne Chroma Green", "Vayne Chroma Red", "Vayne Chroma Grey"));
            MiscMenu.Add("autolvl", new CheckBox("Activate Auto level"));
            MiscMenu.Add("autolvls", new ComboBox("Level Mode", 0, "Max W", "Max Q(my style)"));
            MiscMenu.Add("autobuy", new CheckBox("Autobuy Starters"));
            MiscMenu.Add("autobuyt", new CheckBox("Autobuy Trinkets", false));
            switch (MiscMenu["autolvls"].Cast<ComboBox>().CurrentValue)
            {
                case 0:
                    Variables.AbilitySequence = new[] { 1, 3, 2, 2, 2, 4, 2, 1, 2, 1, 4, 1, 1, 3, 3, 4, 3, 3 };
                    break;
                case 1:
                    Variables.AbilitySequence = new[] { 1, 3, 2, 1, 1, 4, 1, 2, 1, 2, 4, 2, 2, 3, 3, 4, 3, 3 };
                    break;
            }
        }

        public static void Itemmenu()
        {
            ItemMenu = VMenu.AddSubMenu("Activator", "Activator");
            ItemMenu.AddGroupLabel("Items");
            ItemMenu.AddLabel("Ask me if you need more Items.");
            ItemMenu.Add("botrk", new CheckBox("Use Botrk & Bilge"));
            ItemMenu.Add("autopotion", new CheckBox("Auto Healpotion"));
            ItemMenu.Add("autopotionhp", new Slider("HpPot if hp <=", 60));
            ItemMenu.Add("autobiscuit", new CheckBox("Auto Biscuit"));
            ItemMenu.Add("autobiscuithp", new Slider("Biscuit if hp <=", 60));
            ItemMenu.AddGroupLabel("Summoners");
            ItemMenu.AddLabel("Ask me if you need more Summoners.");
            ItemMenu.Add("heal", new CheckBox("Heal"));
            ItemMenu.Add("hp", new Slider("Heal if my HP <=", 20, 0, 100));
            ItemMenu.Add("healally", new CheckBox("Heal ally"));
            ItemMenu.Add("hpally", new Slider("Heal if ally HP <=", 20, 0, 100));
            ItemMenu.AddGroupLabel("Qss");
            ItemMenu.Add("qss", new CheckBox("Use Qss"));
            ItemMenu.Add("delay", new Slider("Delay", 100, 0, 2000));
            ItemMenu.Add("Blind",
                new CheckBox("Blind", false));
            ItemMenu.Add("Charm",
                new CheckBox("Charm"));
            ItemMenu.Add("Fear",
                new CheckBox("Fear"));
            ItemMenu.Add("Polymorph",
                new CheckBox("Polymorph"));
            ItemMenu.Add("Stun",
                new CheckBox("Stun"));
            ItemMenu.Add("Snare",
                new CheckBox("Snare"));
            ItemMenu.Add("Silence",
                new CheckBox("Silence", false));
            ItemMenu.Add("Taunt",
                new CheckBox("Taunt"));
            ItemMenu.Add("Suppression",
                new CheckBox("Suppression"));

        }
      
        public static void Drawingmenu()
        {
            DrawingMenu = VMenu.AddSubMenu("Drawings", "Drawings");
            DrawingMenu.AddGroupLabel("Drawings");
            DrawingMenu.Add("DrawQ", new CheckBox("Draw Q", false));
            DrawingMenu.Add("DrawE", new CheckBox("Draw E", false));
            DrawingMenu.Add("DrawOnlyReady", new CheckBox("Draw Only if Spells are ready"));
        }
    }
}
