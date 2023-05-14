using System.Globalization;

namespace Minesweeper
{
    partial class Minesweeper
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Minesweeper));
            menuStrip = new MenuStrip();
            menuStrip_Game = new ToolStripMenuItem();
            menuStrip_Game_New = new ToolStripMenuItem();
            menuStrip_Game_New_Mini = new ToolStripMenuItem();
            menuStrip_Game_New_Beginner = new ToolStripMenuItem();
            menuStrip_Game_New_Intermediate = new ToolStripMenuItem();
            menuStrip_Game_New_Expert = new ToolStripMenuItem();
            menuStrip_Game_New_Custom = new ToolStripMenuItem();
            menuStrip_Game_Save = new ToolStripMenuItem();
            menuStrip_Game_Load = new ToolStripMenuItem();
            menuStrip_Game_Settings = new ToolStripMenuItem();
            menuStrip_Game_Exit = new ToolStripMenuItem();
            menuStrip_Statistics = new ToolStripMenuItem();
            menuStrip_Help = new ToolStripMenuItem();
            menuStrip_Help_Tutorial = new ToolStripMenuItem();
            menuStrip_Help_About = new ToolStripMenuItem();
            mainTableLayout = new TableLayoutPanel();
            gameOverview = new TableLayoutPanel();
            gameOverview_Timer = new Label();
            gameOverview_RemainingMines = new Label();
            gameOverview_Hints = new Label();
            gameOverview_ResumePause = new Label();
            timer_UpdateGameTime = new System.Windows.Forms.Timer(components);
            menuStrip.SuspendLayout();
            mainTableLayout.SuspendLayout();
            gameOverview.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip
            // 
            menuStrip.BackColor = Color.White;
            menuStrip.Items.AddRange(new ToolStripItem[] { menuStrip_Game, menuStrip_Statistics, menuStrip_Help });
            resources.ApplyResources(menuStrip, "menuStrip");
            menuStrip.Name = "menuStrip";
            // 
            // menuStrip_Game
            // 
            menuStrip_Game.DropDownItems.AddRange(new ToolStripItem[] { menuStrip_Game_New, menuStrip_Game_Save, menuStrip_Game_Load, menuStrip_Game_Settings, menuStrip_Game_Exit });
            menuStrip_Game.Name = "menuStrip_Game";
            resources.ApplyResources(menuStrip_Game, "menuStrip_Game");
            // 
            // menuStrip_Game_New
            // 
            menuStrip_Game_New.DropDownItems.AddRange(new ToolStripItem[] { menuStrip_Game_New_Mini, menuStrip_Game_New_Beginner, menuStrip_Game_New_Intermediate, menuStrip_Game_New_Expert, menuStrip_Game_New_Custom });
            menuStrip_Game_New.Name = "menuStrip_Game_New";
            resources.ApplyResources(menuStrip_Game_New, "menuStrip_Game_New");
            // 
            // menuStrip_Game_New_Mini
            // 
            menuStrip_Game_New_Mini.Name = "menuStrip_Game_New_Mini";
            resources.ApplyResources(menuStrip_Game_New_Mini, "menuStrip_Game_New_Mini");
            menuStrip_Game_New_Mini.Click += MenuStripGameNewMiniClick;
            // 
            // menuStrip_Game_New_Beginner
            // 
            menuStrip_Game_New_Beginner.Name = "menuStrip_Game_New_Beginner";
            resources.ApplyResources(menuStrip_Game_New_Beginner, "menuStrip_Game_New_Beginner");
            menuStrip_Game_New_Beginner.Click += MenuStripGameNewBeginnerClick;
            // 
            // menuStrip_Game_New_Intermediate
            // 
            menuStrip_Game_New_Intermediate.Name = "menuStrip_Game_New_Intermediate";
            resources.ApplyResources(menuStrip_Game_New_Intermediate, "menuStrip_Game_New_Intermediate");
            menuStrip_Game_New_Intermediate.Click += MenuStripGameNewIntermediateClick;
            // 
            // menuStrip_Game_New_Expert
            // 
            menuStrip_Game_New_Expert.Name = "menuStrip_Game_New_Expert";
            resources.ApplyResources(menuStrip_Game_New_Expert, "menuStrip_Game_New_Expert");
            menuStrip_Game_New_Expert.Click += MenuStripGameNewExpertClick;
            // 
            // menuStrip_Game_New_Custom
            // 
            menuStrip_Game_New_Custom.Name = "menuStrip_Game_New_Custom";
            resources.ApplyResources(menuStrip_Game_New_Custom, "menuStrip_Game_New_Custom");
            menuStrip_Game_New_Custom.Click += MenuStripGameNewCustomClick;
            // 
            // menuStrip_Game_Save
            // 
            menuStrip_Game_Save.Name = "menuStrip_Game_Save";
            resources.ApplyResources(menuStrip_Game_Save, "menuStrip_Game_Save");
            // 
            // menuStrip_Game_Load
            // 
            menuStrip_Game_Load.Name = "menuStrip_Game_Load";
            resources.ApplyResources(menuStrip_Game_Load, "menuStrip_Game_Load");
            // 
            // menuStrip_Game_Settings
            // 
            menuStrip_Game_Settings.Name = "menuStrip_Game_Settings";
            resources.ApplyResources(menuStrip_Game_Settings, "menuStrip_Game_Settings");
            menuStrip_Game_Settings.Click += MenuStripGameSettingsClick;
            // 
            // menuStrip_Game_Exit
            // 
            menuStrip_Game_Exit.Name = "menuStrip_Game_Exit";
            resources.ApplyResources(menuStrip_Game_Exit, "menuStrip_Game_Exit");
            menuStrip_Game_Exit.Click += MenuStripGameExitClick;
            // 
            // menuStrip_Statistics
            // 
            menuStrip_Statistics.Name = "menuStrip_Statistics";
            resources.ApplyResources(menuStrip_Statistics, "menuStrip_Statistics");
            menuStrip_Statistics.Click += MenuStripStatisticsClick;
            // 
            // menuStrip_Help
            // 
            menuStrip_Help.DropDownItems.AddRange(new ToolStripItem[] { menuStrip_Help_Tutorial, menuStrip_Help_About });
            menuStrip_Help.Name = "menuStrip_Help";
            resources.ApplyResources(menuStrip_Help, "menuStrip_Help");
            // 
            // menuStrip_Help_Tutorial
            // 
            menuStrip_Help_Tutorial.Name = "menuStrip_Help_Tutorial";
            resources.ApplyResources(menuStrip_Help_Tutorial, "menuStrip_Help_Tutorial");
            menuStrip_Help_Tutorial.Click += MenuStripHelpTutorialClick;
            // 
            // menuStrip_Help_About
            // 
            menuStrip_Help_About.Name = "menuStrip_Help_About";
            resources.ApplyResources(menuStrip_Help_About, "menuStrip_Help_About");
            menuStrip_Help_About.Click += MenuStripHelpAboutClick;
            // 
            // mainTableLayout
            // 
            resources.ApplyResources(mainTableLayout, "mainTableLayout");
            mainTableLayout.Controls.Add(gameOverview, 0, 0);
            mainTableLayout.Name = "mainTableLayout";
            // 
            // gameOverview
            // 
            resources.ApplyResources(gameOverview, "gameOverview");
            gameOverview.Controls.Add(gameOverview_Timer, 1, 0);
            gameOverview.Controls.Add(gameOverview_RemainingMines, 2, 0);
            gameOverview.Controls.Add(gameOverview_Hints, 3, 0);
            gameOverview.Controls.Add(gameOverview_ResumePause, 0, 0);
            gameOverview.GrowStyle = TableLayoutPanelGrowStyle.AddColumns;
            gameOverview.Name = "gameOverview";
            // 
            // gameOverview_Timer
            // 
            resources.ApplyResources(gameOverview_Timer, "gameOverview_Timer");
            gameOverview_Timer.Name = "gameOverview_Timer";
            // 
            // gameOverview_RemainingMines
            // 
            resources.ApplyResources(gameOverview_RemainingMines, "gameOverview_RemainingMines");
            gameOverview_RemainingMines.Name = "gameOverview_RemainingMines";
            // 
            // gameOverview_Hints
            // 
            resources.ApplyResources(gameOverview_Hints, "gameOverview_Hints");
            gameOverview_Hints.Cursor = Cursors.Hand;
            gameOverview_Hints.Name = "gameOverview_Hints";
            gameOverview_Hints.Click += GameOverviewHintsClick;
            // 
            // gameOverview_ResumePause
            // 
            resources.ApplyResources(gameOverview_ResumePause, "gameOverview_ResumePause");
            gameOverview_ResumePause.Cursor = Cursors.Hand;
            gameOverview_ResumePause.Name = "gameOverview_ResumePause";
            gameOverview_ResumePause.Click += GameOverviewResumePauseClick;
            // 
            // timer_UpdateGameTime
            // 
            timer_UpdateGameTime.Enabled = true;
            timer_UpdateGameTime.Tick += TimerUpdateGameTimeTick;
            // 
            // Minesweeper
            // 
            resources.ApplyResources(this, "$this");
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(mainTableLayout);
            Controls.Add(menuStrip);
            ForeColor = Color.Black;
            MainMenuStrip = menuStrip;
            Name = "Minesweeper";
            Deactivate += Minesweeper_Deactivated;
            FormClosing += MinesweeperFormClosing;
            Load += Minesweeper_Load;
            Shown += Minesweeper_Shown;
            menuStrip.ResumeLayout(false);
            menuStrip.PerformLayout();
            mainTableLayout.ResumeLayout(false);
            mainTableLayout.PerformLayout();
            gameOverview.ResumeLayout(false);
            gameOverview.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip;
        private ToolStripMenuItem menuStrip_Game;
        private ToolStripMenuItem menuStrip_Game_New;
        private ToolStripMenuItem menuStrip_Game_New_Mini;
        private ToolStripMenuItem menuStrip_Game_New_Beginner;
        private ToolStripMenuItem menuStrip_Game_New_Intermediate;
        private ToolStripMenuItem menuStrip_Game_New_Expert;
        private ToolStripMenuItem menuStrip_Game_New_Custom;
        private ToolStripMenuItem menuStrip_Game_Save;
        private ToolStripMenuItem menuStrip_Game_Load;
        private ToolStripMenuItem menuStrip_Game_Settings;
        private ToolStripMenuItem menuStrip_Game_Exit;
        private ToolStripMenuItem menuStrip_Statistics;
        private ToolStripMenuItem menuStrip_Help;
        private ToolStripMenuItem menuStrip_Help_Tutorial;
        private ToolStripMenuItem menuStrip_Help_About;
        private TableLayoutPanel mainTableLayout;
        private TableLayoutPanel gameOverview;
        private Label gameOverview_ResumePause;
        private Label gameOverview_Timer;
        private Label gameOverview_RemainingMines;
        private Label gameOverview_Hints;
        private System.Windows.Forms.Timer timer_UpdateGameTime;
    }
}