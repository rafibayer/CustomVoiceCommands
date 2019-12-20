using System;
using System.Threading.Tasks;
using Microsoft.CognitiveServices.Speech;
using System.IO;
using System.Text;


namespace voiceCommands
{
    class speechToText
    {

        public const String serviceRegion = "westus";
        public const String apiKeyPath = "speechServiceKey.txt";

        public static async Task RecognizeSpeechAsync()
        {
            String apiKey = getAPIKey();
            var config = SpeechConfig.FromSubscription(apiKey, serviceRegion);

            using (var recognizer = new SpeechRecognizer(config))
            {
                var result = await recognizer.RecognizeOnceAsync();

                // success
                if (result.Reason == ResultReason.RecognizedSpeech)
                {
                    Console.WriteLine($"STT: We recognized: {result.Text}");
                    ExecuteCommand.execute(result.Text);
                }
                else if (result.Reason == ResultReason.NoMatch)
                {
                    Console.WriteLine($"STT: Speech could not be recognized");
                }
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

       
        private static String getAPIKey()
        {
            String apiKey = File.ReadAllText(apiKeyPath);

            return apiKey;
        }


    }
}
