using NUnit.Framework;
using ChezarShifr;
namespace ChezarShifrTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
        [Test]
        public void EncryptTest5()
        {
            string expected = "иаэечб шзехтас земус тй шзехту";
            string actual = CaesarCrypt.Encrypt("дышать угарным газом не угарно", 5);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void DecryptTest3()
        {
            string expected = "ай лав ю пива";
            string actual = CaesarCrypt.Decrypt("гм оге б тлег", 3);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void EncryptTest1WithCaps()
        {
            string expected = "Бк мбг Я рйгб";
            string actual = CaesarCrypt.Encrypt("Ай лав Ю пива", 1);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void EncryptTest7OnCaps()
        {
            string expected = "Ё ИЖУ ОЖЦЧЛАЖЕ ОЖЦЧЛАЖЩГ";
            string actual = CaesarCrypt.Encrypt("Я ВАМ ЗАПРЕЩАЮ ЗАПРЕЩАТЬ", 7);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void DecryptTest10WithCaps()
        {
            string expected = "Десять круток До ГарантА";
            string actual = CaesarCrypt.Decrypt("Ноыиьё фъэьшф Нш МйъйчьЙ", 10);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void DecryptTest15OnCaps()
        {
            string expected = "МАЙНКРАФТ ЭТО МОЯ ЖИЗНЬ";
            string actual = CaesarCrypt.Decrypt("ЫОШЬЩЯОГБ ЛБЭ ЫЭН ХЧЦЬК", 15);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void EncryptTest20WithAnotherSymbols()
        {
            string expected = "ивкж12чвавэ(чу)№№22";
            string actual = CaesarCrypt.Encrypt("хочу12домой(да)№№22", 20);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void DecryptTest24WithAnotherSymbols()
        {
            string expected = "представьте320что ***** тут текст44222))";
            string actual = CaesarCrypt.Decrypt("жзьыийчщуйь320ойё ***** йкй йьвий44222))", 24);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void EncryptTestEmpty()
        {
            string expected = "";
            string actual = CaesarCrypt.Encrypt("", 1);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void DecryptTestEmpty()
        {
            string expected = "";
            string actual = CaesarCrypt.Decrypt("", 1);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void DecryptTestLongText12()
        {
            string expected = "Специально для такого случая мы собрали самые разные примеры текстов главных страниц. Вам остается только посмотреть, выбрать что-то интересное и реализовать. Просто. Практично. Удобно.";
            string actual = CaesarCrypt.Decrypt("Эырвфлчзщъ пчк юлцъоъ эчяглк шж эъмьлчф элшжр ьлущжр ыьфшрьж юрцэюън очлнщжб эюьлщфв. Нлш ъэюлрюэк юъчзцъ ыъэшъюьрюз, нжмьлюз гюъ-юъ фщюрьрэщър ф ьрлчфуънлюз. Ыьъэюъ. Ыьлцюфгщъ. Япъмщъ.", 12);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void EncryptTestLongText19()
        {
            string expected = "Двчиытюоаб цюс етэбхб дюёйтс ян дбугтюы дтянч гтъанч вгыячгн ечэдебф хютфанз дегтаыи. Фтя бдетчедс ебюоэб вбдябегчео, фнугтео йеб-еб ыаечгчдабч ы гчтюыъбфтео. Вгбдеб. Вгтэеыйаб. Ёцбуаб.";
            string actual = CaesarCrypt.Encrypt("Специально для такого случая мы собрали самые разные примеры текстов главных страниц. Вам остается только посмотреть, выбрать что-то интересное и реализовать. Просто. Практично. Удобно.", 19);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void EncryptTestOneLetter()
        {
            string expected = "ж";
            string actual = CaesarCrypt.Encrypt("ё",1);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void DecryptTestOneLetter()
        {
            string expected = "ё";
            string actual = CaesarCrypt.Decrypt("и",3);
            Assert.AreEqual(expected, actual);
        }
    }
}