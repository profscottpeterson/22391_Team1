using System;
using System.Linq;

namespace XAATArcade
{
    public class XAATArcadeTest
    {
        public bool memoryPlayed = false;
        public bool sequencePlayed = false;
        public bool buttonSoundOn = true;
        public bool backgroundSoundOn = true;
        MemoryTest memory = new MemoryTest();
        SequenceTest sequence = new SequenceTest();

        public bool createTitlePage;
        public bool createConfig;
        public bool addTitlePage;
        public bool removeTitlePage;
        public bool backgroundSound;
        public bool buttonSound;
        public string memoryButtonStatus;
        public string sequenceButtonStatus;
        public string reflexButtonStatus;
        public bool changeBackgroundColor;
        public bool openConfig;
        public bool closeConfig;
        public bool closeForm;

        public void XAATArcade_Load(bool formLoad)
        {
            CreateTitlePage();
            CreateConfig();
            PlayBackgroundSound();
        }

        public void CreateTitlePage()
        {
            createTitlePage = true;
        }

        public void CreateConfig()
        {
            createConfig = true;
        }

        public void AddTitlePage()
        {
            addTitlePage = true;
        }

        public void RemoveTitlePage()
        {
            removeTitlePage = true;
        }


        #region Memory
        public void Memory(bool memoryButton)
        {
            if (memoryButton == true)
            {
                memoryButtonStatus = "clicked";
                memoryPlayed = true;
                RemoveTitlePage();
                memory.Memory(this, memoryButton);
            }
        }

        public void MemoryHover(bool memoryButton)
        {
            if (memoryButton == true)
                memoryButtonStatus = "enter";
        }

        public void MemoryMouseLeave(bool memoryButton)
        {
            if (memoryButton == true)
                memoryButtonStatus = "leave";
        }
        #endregion


        #region Sequence
        public void Sequence(bool sequenceButton)
        {
            if (sequenceButton == true)
            {
                sequenceButtonStatus = "clicked";
                sequencePlayed = true;
                RemoveTitlePage();
                sequence.Sequence(this, sequenceButton);
            }
        }

        public void SequenceHover(bool sequenceButton)
        {
            if (sequenceButton == true)
                sequenceButtonStatus = "enter";
        }

        public void SequenceMouseLeave(bool sequenceButton)
        {
            if (sequenceButton == true)
                sequenceButtonStatus = "leave";
        }
        #endregion


        #region Reflex
        public void Reflex(bool reflexButton)
        {
            if (reflexButton == true)
                reflexButtonStatus = "clicked";
        }

        public void ReflexHover(bool reflexButton)
        {
            if (reflexButton == true)
                reflexButtonStatus = "enter";
        }

        public void ReflexMouseLeave(bool reflexButton)
        {
            if (reflexButton == true)
                reflexButtonStatus = "leave";
        }
        #endregion


        #region Config
        public void OpenConfig(bool openConfigButton)
        {
            if (openConfigButton == true)
                openConfig = true;
        }

        public void ChangeBackColor(bool changeBackgroundButton)
        {
            if (changeBackgroundButton == true)
                changeBackgroundColor = true;
        }

        public void CloseConfig(bool closeConfigButton)
        {
            if (closeConfigButton == true)
                closeConfig = true;
        }
        #endregion

        #region Sound
        public void TurnButtonSoundOn(bool buttonSoundOnButton)
        {
            if (buttonSoundOnButton == true)
                buttonSoundOn = true;
        }

        public void TurnButtonSoundOff(bool buttonSoundOffButton)
        {
            if (buttonSoundOffButton == true)
                buttonSoundOn = false;
        }

        public void PlaySound(bool playSoundButton)
        {
            if (playSoundButton == true)
            {
                if (buttonSoundOn == true)
                    buttonSound = true;
            }
        }

        public void TurnBackgroundSoundOn(bool backgroundSoundOnButton)
        {
            if (backgroundSoundOnButton == true)
            {
                backgroundSoundOn = true;
                PlayBackgroundSound();
            }
        }

        public void TurnBackgroundSoundOff(bool backgroundSoundOffButton)
        {
            if (backgroundSoundOffButton == true)
            {
                backgroundSoundOn = false;
                StopBackgroundSound();
            }
        }

        public void PlayBackgroundSound()
        {
            backgroundSound = true;
        }

        public void StopBackgroundSound()
        {
            backgroundSound = false;
        }
        #endregion


        public void XAATArcade_FormClosed(bool formClosedButton)
        {
            if (formClosedButton == true)
                closeForm = true;
        }
    }
}
