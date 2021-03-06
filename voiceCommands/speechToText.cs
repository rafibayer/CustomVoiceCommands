﻿using System;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using System.IO;
using System.Media;


namespace voiceCommands
{
    static class speechToText
    {

        // TODO: prevent running multiple instances at the same time

        // Azure Service Region
        public static readonly String serviceRegion = "westus";
        // Untracked file with my Azure service token key
        public static readonly String apiKeyPath = @"speechServiceKey.txt";

        private static bool inUse = false;

        public static async Task RecognizeSpeechAsync()
        {

            if (inUse)
            {
                return;
            }


            // read API key file
            String apiKey = getAPIKey();
            // Build Speech config
            var config = SpeechConfig.FromSubscription(apiKey, serviceRegion);

            // create the recognizer object
            using (var recognizer = new SpeechRecognizer(config))
            {
                // play sfx to let user know recording has started
                startSound();
                inUse = true;

                // make the API call to Azure Service
                var result = await recognizer.RecognizeOnceAsync();

                // play sfx to let user know recording has finished;
                stopSound();
                inUse = false;

                // success
                if (result.Reason == ResultReason.RecognizedSpeech)
                {
                    Console.WriteLine($"STT: We recognized: {result.Text}");
                    ExecuteCommand.Execute(result.Text);
                }
                // couldn't understand
                else if (result.Reason == ResultReason.NoMatch)
                {
                    Console.WriteLine($"STT: Speech could not be recognized");
                }
                // canceled
                else if (result.Reason == ResultReason.Canceled)
                {
                    var cancellation = CancellationDetails.FromResult(result);
                    Console.WriteLine($"STT CANCELED: Reason={cancellation.Reason}");

                    if (cancellation.Reason == CancellationReason.Error)
                    {
                        Console.WriteLine($"STT CANCELED: ErrorCode={cancellation.ErrorCode}");
                        Console.WriteLine($"STT CANCELED: ErrorDetails={cancellation.ErrorDetails}");
                        Console.WriteLine($"STT CANCELED: Did you update the subscription info?");
                    }
                }
            }

        }

       // read the API key from the file specified by the class const
        private static String getAPIKey()
        {
            try
            {
                return File.ReadAllText(apiKeyPath);
            }
            catch (IOException)
            {
                Console.WriteLine("Could not read API key file");
                throw;
            }

        }


        private static void startSound()
        {


            SoundPlayer startSound = new SoundPlayer("sounds/startSound.wav");
            startSound.Play();
        }

        private static void stopSound()
        {
            SoundPlayer stopSound = new SoundPlayer("sounds/stopSound.wav");
            stopSound.Play();
        }

    }
}
