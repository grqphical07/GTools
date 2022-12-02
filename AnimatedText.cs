using System;
using System.Collections;
using UnityEngine;
using TMPro;

namespace GTools.AnimatedText
{
    public class AnimatedText
    {
        TextMeshProUGUI textLabel;
        string message;
        float delay;
        /// <summary>
        /// Creates an instance of the Animated text class
        /// </summary>
        /// <param name="_textLabel">The <c>TextMeshProUGUI</c></param>
        /// <param name="_message">Text you want to display</param>
        /// <param name="_delay">How long in between each character you want to delay it</param>
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

        /// <summary>
        /// Changes the message displayed by the animation. You have to use <c>Animate()</c> after this function to see the changes
        /// </summary>
        /// <param name="newMessage"></param>
        public void ChangeMessage(string newMessage)
        {
            message = newMessage;
        }
    }
}
