using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TP_fichier;

namespace UnitTestProject2
{
    [TestClass]
    public class UnitTest1
    {
        
        [TestInitialize]
        public void SetUp()
        {
            // la configuration de base qui va être rétablie après chaque test unitaire
            Path utilisateur = new Path();
            Dossier home = new Dossier("c:");
            utilisateur.start(home);
            utilisateur.current.create("f","unfichier");
            utilisateur.current.create("d", "undossier");

        }

        #region ls
        [TestMethod]
        public void ls()
        {
            utilisateur.chmod(7);
            Assert.AreEqual(utilisateur.current.ls(), true);   
        }

        [TestMethod]
        public void ls2()
        {
            utilisateur.chmod(0);
            Assert.AreNotEqual(utilisateur.current.ls(), true);
        }
        #endregion

        [TestMethod] //affiche le chemin depuis le dossier parent
        public void path()
        {
            utilisateur.chmod(7);
            Assert.AreEqual(utilisateur.current.path()) , true);
        }

        #region cd
        [TestMethod]
        public void cd()
        {
            utilisateur.chmod(7);
            Assert.AreEqual(utilisateur.cd("undossier"),undossier);
        }

        [TestMethod]
        public void cd2()
        {
            utilisateur.chmod(0);
            Assert.AreNotEqual(utilisateur.cd("undossier"), undossier);
        }

        [TestMethod]
        public void cd3()
        {
            utilisateur.chmod(7);
            Assert.AreEqual(utilisateur.cd("unfichier"), unfichier);
        }

        [TestMethod]
        public void cd4()
        {
            utilisateur.chmod(0);
            Assert.AreNotEqual(utilisateur.cd("unfichier"), unfichier);
        }

        [TestMethod] //essai pour rentrer dans un dossier dans depuis un fichier
        public void cd5()
        {
            utilisateur.chmod(7);
            utilisateur.cd("unfichier");
            utilisateur.chmod(7);
            Assert.AreNotEqual(utilisateur.cd("autredossier"), autredossier);
        }
        #endregion

        #region mkdir
        [TestMethod]
        public void mkdir()
        {
            utilisateur.chmod(7);
            Assert.AreEqual(utilisateur.current.mkdir("newdossier", "dossier", utilisateur.current), true);
        }

        [TestMethod]
        public void mkdir2()
        {
            utilisateur.chmod(0);
            Assert.AreNotEqual(utilisateur.current.mkdir("newdossier", "dossier", utilisateur.current), true);
        }

        [TestMethod]  //essaie de créer un dossier dans un fichier
        public void mkdir3()
        {
            utilisateur.chmod(7);
            utilisateur.cd("unfichier");
            Assert.AreNotEqual(utilisateur.current.mkdir("newdossier", "dossier", utilisateur.current), true);
        }
        #endregion

        #region getroot
        [TestMethod]
        public void getroot()
        {
            utilisateur.chmod(7);
            Assert.AreEqual(utilisateur.current.getroot() , true);
        }

        [TestMethod]
        public void getroot2()
        {
            utilisateur.chmod(0);
            Assert.AreNotEqual(utilisateur.current.getroot(), true);
        }
        #endregion

        #region search
        [TestMethod]
        public void search()
        {
            utilisateur.chmod(7);
            Assert.AreEqual(utilisateur.current.search("undossier") , true);
        }

        [TestMethod]
        public void search2()
        {
            utilisateur.chmod(7);
            Assert.AreNotEqual(utilisateur.current.search("unfichier"), true);
        }

        [TestMethod] // essaie de toucher un dossier contenue dans un autre dossier dans lequel ont ne peut pas éxécuter
        public void search3()
        {
            utilisateur.chmod(7);
            utilisateur.cd("undossier");
            utilisateur.current.mkdir("autredossier", "dossier", utilisateur.current);
            utilisateur.chmod(0);
            utilisateur.current.parent();
            Assert.AreNotEqual(utilisateur.current.search("autredossier"), true);
        }
        #endregion

        #region create
        [TestMethod]
        public void create()
        {
            utilisateur.chmod(7);
            Assert.AreEqual(utilisateur.current.create("f","newfichier") , true);
        }

        [TestMethod]
        public void create2()
        {
            utilisateur.chmod(7);
            Assert.AreEqual(utilisateur.current.create("d", "newdossier"), true);
        }

        [TestMethod]
        public void create3()
        {
            utilisateur.chmod(0);
            Assert.AreNotEqual(utilisateur.current.create("f", "newfichier"), true);
        }

        [TestMethod]
        public void create4()
        {
            utilisateur.chmod(0);
            Assert.AreNotEqual(utilisateur.current.create("d", "newdossier"), true);
        }

        [TestMethod] // essaie de créer un dossier dans un fichier
        public void create5()
        {
            utilisateur.chmod(7);
            utilisateur.current.cd("unfichier");
            Assert.AreNotEqual(utilisateur.current.create("d", "newdossier"), true);
        }

        [TestMethod] // essaie de créer un fichier dans un fichier
        public void create6()
        {
            utilisateur.chmod(7);
            utilisateur.current.cd("unfichier");
            Assert.AreNotEqual(utilisateur.current.create("f", "newfichier"), true);
        }
        #endregion

        #region delete
        [TestMethod]
        public void delete()
        {
            utilisateur.chmod(7);
            Assert.AreEqual(utilisateur.current.delete("unfichier"), true);
        }

        [TestMethod]
        public void delete2()
        {
            utilisateur.chmod(7);
            Assert.AreEqual(utilisateur.current.delete("undossier"), true);
        }

        [TestMethod]
        public void delete3()
        {
            utilisateur.chmod(0);
            Assert.AreNotEqual(utilisateur.current.delete("unfichier"), true);
        }

        [TestMethod]
        public void delete4()
        {
            utilisateur.chmod(0);
            Assert.AreNotEqual(utilisateur.current.delete("undossier"), true);
        }
        #endregion

        #region renameto
        [TestMethod]
        public void renameto()
        {
            utilisateur.chmod(7);
            Assert.AreEqual(utilisateur.current.renameto("undossier", "autrenom"), true);
        }

        [TestMethod]
        public void renameto2()
        {
            utilisateur.chmod(7);
            Assert.AreEqual(utilisateur.current.renameto("unfichier", "autrenom"), true);
        }

        [TestMethod]
        public void renameto3()
        {
            utilisateur.chmod(0);
            Assert.AreEqual(utilisateur.current.renameto("undossier", "autrenom"), true);
        }

        [TestMethod]
        public void renameto4()
        {
            utilisateur.chmod(0);
            Assert.AreEqual(utilisateur.current.renameto("unfichier", "autrenom"), true);
        }
        #endregion

        [TestMethod]
        public void chmod()
        {
            Assert.AreEqual(utilisateur.chmod(7), utilisateur.current.autorisation );
        }

        #region istype
        [TestMethod]
        public void isfile()
        {
            utilisateur.current.cd("unfichier");
            Assert.AreEqual(utilisateur.current.file, true);
        }

        [TestMethod]
        public void isnotfile()
        {
            Assert.AreNotEqual(utilisateur.current.file, true );
        }

        [TestMethod]
        public void isdirectory()
        {
            Assert.AreEqual(utilisateur.current.directory, true);
        }

        [TestMethod]
        public void isnotdirectory()
        {
            utilisateur.current.cd("unfichier");
            Assert.AreNotEqual(utilisateur.current.directory, true);
        }
        #endregion

        [TestMethod]
        public void parent()
        {
            Assert.AreEqual(utilisateur.current.parent(), true);
        }

        #region show // affiche le contenue des fichiers
        [TestMethod] // essaie d'afficher un dossier
        public void show()
        {
            utilisateur.chmod(7);
            Assert.AreNotEqual(utilisateur.current.show, true);
        }

        [TestMethod]
        public void show2()
        {
            utilisateur.chmod(7);
            utilisateur.cd("unfichier");
            Assert.AreEqual(utilisateur.current.show, true);
        }

        [TestMethod] 
        public void show3()
        {
            utilisateur.cd("unfichier");
            utilisateur.chmod(0);
            Assert.AreNotEqual(utilisateur.current.show, true);
        }
        #endregion

        #region write/read/execute
        [TestMethod]
        public void canwrite()
        {
            utilisateur.chmod(7);
            Assert.AreEqual(utilisateur.current.canwrite(), true);
        }

        [TestMethod]
        public void cantwrite()
        {
            utilisateur.chmod(0);
            Assert.AreNotEqual(utilisateur.current.canwrite(), true);
        }

        [TestMethod]
        public void canread()
        {
            utilisateur.chmod(7);
            Assert.AreEqual(utilisateur.current.canread(), true);
        }

        [TestMethod]
        public void cantread()
        {
            utilisateur.chmod(0);
            Assert.AreNotEqual(utilisateur.current.canread(), true);
        }

        [TestMethod]
        public void execute()
        {
            utilisateur.chmod(7);
            Assert.AreEqual(utilisateur.current.execute(), true);
        }

        [TestMethod]
        public void cantexecute()
        {
            utilisateur.chmod(0);
            Assert.AreNotEqual(utilisateur.current.execute(), true);
        }
        #endregion
    }
}
