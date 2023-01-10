using System;
using System.Collections;
using UnityEngine;
using TMPro;

namespace GTools
{
    public class AnimatedText
    {
        public TextMeshProUGUI textLabel;
        public string message;
        public float delay;
        /// <summary>
        /// Creates an instance of the Animated text class. Creates a typing effect animation
        /// </summary>
        /// <param name="_textLabel">The <c>TextMeshProUGUI</c></param>
        /// <param name="_message">Text you want to display</param>
        /// <param name="_delay">How long to wait before typing another character</param>
        public AnimatedText(TextMeshProUGUI _textLabel, string _message, float _delay)
        {
            textLabel = _textLabel;
            message = _message;
            delay = _delay;
        }
        /// <summary>
        /// The Coroutine used to start the animation. Use <c>StartCoroutine()</c> to use it
        /// </summary>
        /// <returns></returns>
        public IEnumerator Animate()
        {
            foreach (char c in message)
            {
                textLabel.text = "";
                textLabel.text += c;
                yield return new WaitForSeconds(delay);
            }
        }
    }
}
