using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Trainings
{
    public class TrainingStart : MonoBehaviour
    {
        public GameObject TrainingPanel;
        public Text textTrainir;
        public Image imgTrainir, Eyas;
        public Sprite[] spriteTrainir;
        public static IEnumerator TrainingIE;

        void Start()
        {
            TrainingIE = Training();
        }
        private IEnumerator Training()
        {
            if (!ConfigurableParameters.trainingBool)
            {
                Time.timeScale = 0;
                ConfigurableParameters.play = false;
                TrainingPanel.SetActive(true);
                Eyas.sprite = spriteTrainir[8];
                textTrainir.rectTransform.sizeDelta = new Vector2(623.7f, 193.45f);
                textTrainir.rectTransform.transform.localPosition = new Vector3(1.81f, textTrainir.transform.localPosition.y, 0);
                imgTrainir.sprite = null;
                if (PlayerPrefs.GetString("language") == "Ru")
                    textTrainir.text = "У меня не так много времени! Помните, я обратился к тебе за помощью, потому что у меня нет выбора.";
                else if (PlayerPrefs.GetString("language") == "Eng")
                    textTrainir.text = "I don't have much time! Remember, I turned to you for help because I have no choice.";
                else if (PlayerPrefs.GetString("language") == "DE")
                    textTrainir.text = "Ich habe nicht viel Zeit! Denken Sie daran, ich habe Sie um Hilfe gebeten, weil ich keine Wahl habe.";
                else if (PlayerPrefs.GetString("language") == "ZH")
                    textTrainir.text = "我时间不多了！ 记住，我向你求助，因为我别无选择。";
                yield return new WaitForSecondsRealtime(5f);
                Eyas.sprite = spriteTrainir[7];
                if (PlayerPrefs.GetString("language") == "Ru")
                    textTrainir.text = "Я расскажу тебе в крации, что произошло. " +
                        "Я просто 'позаимствовал' этот чудесный камень у циклопа, точнее у наколдованного богом, головы циклопа." +
                        " И если он меня поймает, то от меня ничего не останется.";
                else if (PlayerPrefs.GetString("language") == "Eng")
                    textTrainir.text = "I'll tell you in Kratia what happened. " +
                    "I just 'borrowed' this wonderful stone from a cyclops, or rather from a god-conjured cyclops head." +
                    "And if he catches me, then there will be nothing left of me.";
                else if (PlayerPrefs.GetString("language") == "DE")
                    textTrainir.text = "Ich werde dir in Krazia sagen, was passiert ist. " +
"Ich habe mir diesen wunderbaren Stein einfach vom Zyklopen geliehen, genauer gesagt vom von Gott verzauberten Kopf des Zyklopen." +
" Und wenn er mich erwischt, wird nichts von mir übrig bleiben.";
                else if (PlayerPrefs.GetString("language") == "ZH")
                    textTrainir.text = "我会在克拉蒂亚告诉你发生了什么事。 " +
"我只是从独眼巨人那里'借'了这块奇妙的石头，或者更确切地说是从神召唤的独眼巨人头上。" +
"如果他抓住我，那么我就不会留下任何东西.";
                yield return new WaitForSecondsRealtime(10);
                Eyas.sprite = spriteTrainir[6];
                if (PlayerPrefs.GetString("language") == "Ru")
                    textTrainir.text = "Зачем мне этот камень? Потому что он дает невероятную силу!";
                else if (PlayerPrefs.GetString("language") == "Eng")
                    textTrainir.text = "Why do I need this stone? Because it gives incredible power!";
                else if (PlayerPrefs.GetString("language") == "DE")
                    textTrainir.text = "Warum brauche ich diesen Stein? Weil es unglaubliche Kraft gibt!";
                else if (PlayerPrefs.GetString("language") == "ZH")
                    textTrainir.text = "为什么我需要这块石头？ 因为它提供了令人难以置信的力量！";
                yield return new WaitForSecondsRealtime(7);
                Eyas.sprite = spriteTrainir[7];
                if (PlayerPrefs.GetString("language") == "Ru")
                    textTrainir.text = "Кхм...Забудь, что я сказал про силу. Лучше посмотри на мой глаз, видишь?";
                else if (PlayerPrefs.GetString("language") == "Eng")
                    textTrainir.text = "Ahem...Forget what I said about power. Better look at my eye, see?";
                else if (PlayerPrefs.GetString("language") == "DE")
                    textTrainir.text = "Khm...Vergiss, was ich über die Macht gesagt habe. Schau lieber auf mein Auge, siehst du?";
                else if (PlayerPrefs.GetString("language") == "ZH")
                    textTrainir.text = "咳咳。..忘了我说的权力吧。 最好看看我的眼睛，看到了吗？";
                yield return new WaitForSecondsRealtime(7);
                Eyas.sprite = spriteTrainir[6];
                if (PlayerPrefs.GetString("language") == "Ru")
                    textTrainir.text = "Он один!";
                else if (PlayerPrefs.GetString("language") == "Eng")
                    textTrainir.text = "He's alone!";
                else if (PlayerPrefs.GetString("language") == "DE")
                    textTrainir.text = "Er ist allein!";
                else if (PlayerPrefs.GetString("language") == "ZH")
                    textTrainir.text = "他一个人！";
                ConfigurableParameters.play = false;
                yield return new WaitForSecondsRealtime(2.5f);
                Eyas.sprite = spriteTrainir[8];
                if (PlayerPrefs.GetString("language") == "Ru")
                    textTrainir.text = "Это проклятие камня, если кто то его попытается украсть, то вор станет циклопом." +
                        " И так получилось, что теперь я тоже циклом и мой глаз находится не на лице, а с боку. И я ничего не вижу!";
                else if (PlayerPrefs.GetString("language") == "Eng")
                    textTrainir.text = "This is the curse of the stone, " +
                    "if someone tries to steal it, the thief will become a cyclops. " +
                    "And it so happened that now I am also a cycle and my eye is not on the face, " +
                    "but on the side. And I can't see anything!";
                else if (PlayerPrefs.GetString("language") == "DE")
                    textTrainir.text = "Das ist der Fluch des Steins, wenn jemand versucht, ihn zu stehlen, wird der Dieb zu einem Zyklopen." +
                        " Und so kam es, dass ich jetzt auch radle und mein Auge nicht auf meinem Gesicht, sondern auf meiner Seite ist. Und ich sehe nichts!";
                else if (PlayerPrefs.GetString("language") == "ZH")
                    textTrainir.text = "这是石头的诅咒，如果有人试图偷走它，小偷就会变成独眼巨人。 " +
"恰巧，现在我也是一个循环，我的眼睛不是在脸上，而是在一边。 我什么也看不见！";
                yield return new WaitForSecondsRealtime(10);
                Eyas.sprite = spriteTrainir[8];
                if (PlayerPrefs.GetString("language") == "Ru")
                    textTrainir.text = "В чем заключается твоя помощь.";
                else if (PlayerPrefs.GetString("language") == "Eng")
                    textTrainir.text = "What is your help.";
                else if (PlayerPrefs.GetString("language") == "DE")
                    textTrainir.text = "Was ist deine Hilfe?";
                else if (PlayerPrefs.GetString("language") == "ZH")
                    textTrainir.text = "什么是你的帮助。";
                yield return new WaitForSecondsRealtime(2.5f);
                Eyas.sprite = spriteTrainir[8];
                if (PlayerPrefs.GetString("language") == "Ru")
                    textTrainir.text = "Ты должен вывести меня отсюда, чтобы я не выпал из мира и циклоп меня не съел.";
                else if (PlayerPrefs.GetString("language") == "Eng")
                    textTrainir.text = "You have to get me out of here so that " +
                    "I don't fall out of the world and the cyclops doesn't eat me.";
                else if (PlayerPrefs.GetString("language") == "DE")
                    textTrainir.text = "Du musst mich hier rausbringen, damit ich nicht aus der Welt falle und der Zyklop mich nicht isst.";
                else if (PlayerPrefs.GetString("language") == "ZH")
                    textTrainir.text = "你得把我弄出去，这样我就不会从这个世界上掉下来，独眼巨人也不会吃我。";
                yield return new WaitForSecondsRealtime(8f);
                textTrainir.rectTransform.sizeDelta = new Vector2(381.72f, 193.45f);
                textTrainir.rectTransform.transform.localPosition = new Vector3(-119.18f, textTrainir.transform.localPosition.y, 0);
                imgTrainir.sprite = spriteTrainir[0];
                Eyas.sprite = spriteTrainir[7];
                if (PlayerPrefs.GetString("language") == "Ru")
                    textTrainir.text = "Просто проводи пальцем по экрану в нужную сторону, а я буду следовать за ним.";
                else if (PlayerPrefs.GetString("language") == "Eng")
                    textTrainir.text = "Just swipe your finger across the screen in the right direction, " +
                    "and I'll look at them and move there as well.";
                else if (PlayerPrefs.GetString("language") == "DE")
                    textTrainir.text = "Streichen Sie einfach mit dem Finger über den Bildschirm in die richtige Richtung, und ich werde ihm folgen.";
                else if (PlayerPrefs.GetString("language") == "ZH")
                    textTrainir.text = "只要用你的手指在屏幕上朝正确的方向滑动，我就会跟着他。";
                yield return new WaitForSecondsRealtime(8f);
                Eyas.sprite = spriteTrainir[7];
                imgTrainir.sprite = spriteTrainir[3];
                if (PlayerPrefs.GetString("language") == "Ru")
                    textTrainir.text = "Есть блоки, которые преграждают путь, но у меня хватит сил, чтобы их разбить со второго раза.";
                else if (PlayerPrefs.GetString("language") == "Eng")
                    textTrainir.text = "There are blocks that block the way, but " +
                    "I have enough strength to break them the second time.";
                else if (PlayerPrefs.GetString("language") == "DE")
                    textTrainir.text = "Es gibt Blöcke, die den Weg blockieren, aber ich habe genug Kraft, um sie ab dem zweiten Mal zu zerschlagen.";
                else if (PlayerPrefs.GetString("language") == "ZH")
                    textTrainir.text = "有块挡住去路，但我有足够的力量第二次打破它们。";
                yield return new WaitForSecondsRealtime(8f);
                Eyas.sprite = spriteTrainir[6];
                imgTrainir.sprite = spriteTrainir[2];
                if (PlayerPrefs.GetString("language") == "Ru")
                    textTrainir.text = "Иногда могут на пути располагаться лианы, с помощью которых я смогу при полете сменить траекторию полета.";
                else if (PlayerPrefs.GetString("language") == "Eng")
                    textTrainir.text = "Sometimes there may be vines on the way," +
                    " with the help of which I can change the flight path during the flight.";
                else if (PlayerPrefs.GetString("language") == "DE")
                    textTrainir.text = "Manchmal können sich Lianen auf dem Weg befinden, mit denen ich während des Fluges die Flugbahn ändern kann.";
                else if (PlayerPrefs.GetString("language") == "ZH")
                    textTrainir.text = "有时在途中可能会有藤蔓，借助它我可以在飞行过程中改变飞行路径。";
                yield return new WaitForSecondsRealtime(8f);
                Eyas.sprite = spriteTrainir[6];
                imgTrainir.sprite = spriteTrainir[4];
                if (PlayerPrefs.GetString("language") == "Ru")
                    textTrainir.text = "Так же есть порталы, которые переместят меня, если появится на пути тупик.";
                else if (PlayerPrefs.GetString("language") == "Eng")
                    textTrainir.text = "There are also portals that will move me if a dead end appears on the way.";
                else if (PlayerPrefs.GetString("language") == "DE")
                    textTrainir.text = "Es gibt auch Portale, die mich bewegen werden, wenn eine Sackgasse auf dem Weg erscheint.";
                else if (PlayerPrefs.GetString("language") == "ZH")
                    textTrainir.text = "还有传送门，如果路上有死胡同，会让我感动。";
                yield return new WaitForSecondsRealtime(6f);
                Eyas.sprite = spriteTrainir[8];
                imgTrainir.sprite = spriteTrainir[5];
                if (PlayerPrefs.GetString("language") == "Ru")
                    textTrainir.text = "Ты же считаешься у нас богом, так что если тебе надо отлучиться, то просто нажми на экран двумя пальцами и время остановится.";
                else if (PlayerPrefs.GetString("language") == "Eng")
                    textTrainir.text = "You're considered a god here," +
                    " so if you need to leave, just tap the screen with two fingers and time will stop.";
                else if (PlayerPrefs.GetString("language") == "DE")
                    textTrainir.text = "Du hältst uns für Gott, also, wenn du weggehen musst, tippe einfach mit zwei Fingern auf den Bildschirm und die Zeit stoppt.";
                else if (PlayerPrefs.GetString("language") == "ZH")
                    textTrainir.text = "你在这里被认为是上帝，所以如果你需要离开，只需用两根手指点击屏幕，时间就会停止。";
                yield return new WaitForSecondsRealtime(8f);
                Eyas.sprite = spriteTrainir[6];
                imgTrainir.sprite = null;
                textTrainir.rectTransform.sizeDelta = new Vector2(623.7f, 193.45f);
                textTrainir.rectTransform.transform.localPosition = new Vector3(1.81f, textTrainir.transform.localPosition.y, 0);
                if (PlayerPrefs.GetString("language") == "Ru")
                    textTrainir.text = "А теперь самое интересное, когда камень подзарядится, просто нажми на мой глаз, и я покажу тебе свою новую СУПЕР ПУПЕР СИЛУ! Хе-хе";
                else if (PlayerPrefs.GetString("language") == "Eng")
                    textTrainir.text = "And now the most interesting thing is, when the stone is recharged, " +
                    "just click on my eye, and I'll show you my new SUPER DUPER POWER! He-he";
                else if (PlayerPrefs.GetString("language") == "DE")
                    textTrainir.text = "Und jetzt ist der Spaß, wenn der Stein wieder aufgeladen wird, drücke einfach auf mein Auge und ich zeige dir meine neue SUPER-DUPER-KRAFT! He-he";
                else if (PlayerPrefs.GetString("language") == "ZH")
                    textTrainir.text = "现在最有趣的是，当石头充电时，只需点击我的眼睛，我就会向你展示我的新超级骗子力量！ 呵呵";
                yield return new WaitForSecondsRealtime(8f);
                Eyas.sprite = spriteTrainir[8];
                if (PlayerPrefs.GetString("language") == "Ru")
                    textTrainir.text = "Времени на разговоры больше нет, так что не подведи меня!";
                else if (PlayerPrefs.GetString("language") == "Eng")
                    textTrainir.text = "There's no more time to talk, so don't let me down!";
                else if (PlayerPrefs.GetString("language") == "DE")
                    textTrainir.text = "Es gibt keine Zeit mehr zu reden, also lass mich nicht im Stich!";
                else if (PlayerPrefs.GetString("language") == "ZH")
                    textTrainir.text = "没时间说话了，别让我失望！";
                yield return new WaitForSecondsRealtime(6);
                Time.timeScale = 1;
                TrainingPanel.SetActive(false);
                ConfigurableParameters.play = true;
                ConfigurableParameters.trainingBool = true;
                PlayerPrefs.SetInt("TrainingStart", ConfigurableParameters.trainingBool ? 1 : 0);
                PlayerPrefs.Save();
            }
        }
    }
}