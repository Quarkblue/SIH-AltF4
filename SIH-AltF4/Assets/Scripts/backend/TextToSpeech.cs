using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.Runtime.CompilerServices;

namespace TtS
{
    public class TextToSpeech
    {
        
        static void Main(string[] args)
        {
            SpeechSynthesizer _Ss = new SpeechSynthesizer();
            _Ss.Speak("Teri Maa ki chut");

        }
    }
}
