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
            string expected = "������ ������� ����� �� ������";
            string actual = CaesarCrypt.Encrypt("������ ������� ����� �� ������", 5);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void DecryptTest3()
        {
            string expected = "�� ��� � ����";
            string actual = CaesarCrypt.Decrypt("�� ��� � ����", 3);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void EncryptTest1WithCaps()
        {
            string expected = "�� ��� � ����";
            string actual = CaesarCrypt.Encrypt("�� ��� � ����", 1);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void EncryptTest7OnCaps()
        {
            string expected = "� ��� �������� ���������";
            string actual = CaesarCrypt.Encrypt("� ��� �������� ���������", 7);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void DecryptTest10WithCaps()
        {
            string expected = "������ ������ �� �������";
            string actual = CaesarCrypt.Decrypt("������ ������ �� �������", 10);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void DecryptTest15OnCaps()
        {
            string expected = "��������� ��� ��� �����";
            string actual = CaesarCrypt.Decrypt("��������� ��� ��� �����", 15);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void EncryptTest20WithAnotherSymbols()
        {
            string expected = "����12�����(��)��22";
            string actual = CaesarCrypt.Encrypt("����12�����(��)��22", 20);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void DecryptTest24WithAnotherSymbols()
        {
            string expected = "�����������320��� ***** ��� �����44222))";
            string actual = CaesarCrypt.Decrypt("�����������320�� ***** ��� �����44222))", 24);
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
            string expected = "���������� ��� ������ ������ �� ������� ����� ������ ������� ������� ������� �������. ��� �������� ������ ����������, ������� ���-�� ���������� � �����������. ������. ���������. ������.";
            string actual = CaesarCrypt.Decrypt("���������� ��� ������ ������ �� ������� ����� ������ ������� ������� ������� �������. ��� �������� ������ ����������, ������� ���-�� ���������� � �����������. ������. ���������. ������.", 12);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void EncryptTestLongText19()
        {
            string expected = "���������� ��� ������ ������ �� ������� ����� ������ ������� ������� ������� �������. ��� �������� ������ ����������, ������� ���-�� ���������� � �����������. ������. ���������. ������.";
            string actual = CaesarCrypt.Encrypt("���������� ��� ������ ������ �� ������� ����� ������ ������� ������� ������� �������. ��� �������� ������ ����������, ������� ���-�� ���������� � �����������. ������. ���������. ������.", 19);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void EncryptTestOneLetter()
        {
            string expected = "�";
            string actual = CaesarCrypt.Encrypt("�",1);
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void DecryptTestOneLetter()
        {
            string expected = "�";
            string actual = CaesarCrypt.Decrypt("�",3);
            Assert.AreEqual(expected, actual);
        }
    }
}