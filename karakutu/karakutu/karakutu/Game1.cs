using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace karakutu
{
   
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        #region tanimlamalar
        bool bittimi = false,kazandikmi=false;
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D karakter;
        Vector2 karakterPoz;
        Vector2 karakterHýz;
        Texture2D engel;
        Texture2D gecilenYer;
        KeyboardState suankiTus;
        KeyboardState sonrakiTus;
        SpriteFont font;
        Vector2 fontV;
        SpriteFont fonta;
        Vector2 fontVa;
        SpriteFont fontb;
        Vector2 fontVb;
        bool aaa = false;
        SoundEffect ibonungercekhayvansesi;
        SoundEffect alkislarlaYasiyorum;
        Vector2 gecici, gecici1, gecici2, gecici3;
        int  sayac = 0,puansayaci = 0, deneme=0,geriListe,geriTum,rsayac=0;
        List<Vector2> liste1 = new List<Vector2>();
        List<Vector2> listEngel = new List<Vector2>();
        List<Vector2> tumEngel = new List<Vector2>();
        Vector2 rVector = new Vector2();
        Random rndx = new Random();
        Random rndy = new Random();
        Random rndKutu = new Random();
        static int a;
        #endregion
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 800;
            graphics.ApplyChanges();
            listeyeengelEkle();
        }
           
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            karakterHýz = new Vector2(50, 50);
            karakterPoz = new Vector2(750, 550);
            fontV = new Vector2(125, 250);
            fontVa = new Vector2(125, 500);
            fontVb = new Vector2(125, 125);
            base.Initialize();
        }
 
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            karakter = Content.Load<Texture2D>("kutumuz");
            gecilenYer = Content.Load<Texture2D>("geçilenyer");
            engel = Content.Load<Texture2D>("engel");
            font = Content.Load<SpriteFont>("SpriteFont1");
            fonta = Content.Load<SpriteFont>("SpriteFont2");
            fontb = Content.Load<SpriteFont>("SpriteFont3");
            ibonungercekhayvansesi = Content.Load<SoundEffect>("ibos2");
            alkislarlaYasiyorum = Content.Load<SoundEffect>("alkis");
        }
  
        protected override void Update(GameTime gameTime)
        {
            suankiTus = Keyboard.GetState();
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();  
            if (!gidecekYerVarmi())
            {
                bittimi = true;
                if (suankiTus.IsKeyDown(Keys.Escape))
                    this.Exit();
                if (suankiTus.IsKeyDown(Keys.Y))
                    yenidenBaslat();
            }
            if (kazandikMi())
            {
                kazandikmi = true;
                 if (suankiTus.IsKeyDown(Keys.Escape))
                    this.Exit();
                if (suankiTus.IsKeyDown(Keys.Y))
                    yenidenBaslat();
            }
            else
            {
                if (suankiTus.IsKeyDown(Keys.R))
                {
                    if (aaa)
                    {
                        if (rsayac == 0)
                        {
                            if (sonrakiTus.IsKeyUp(Keys.R))
                            {
                                karakterPoz.X = rVector.X;
                                karakterPoz.Y = rVector.Y;
                                liste1.RemoveAt(geriListe - 1);
                                tumEngel.RemoveAt(geriTum - 1);
                                rsayac++;
                                puansayaci--;
                                bittimi = false;
                            }
                        }
                    }
                }
                else
                {

                    sayac = 0;
                  
                    #region W
                    if (suankiTus.IsKeyDown(Keys.W))
                    {
                        gecici1.Y = karakterPoz.Y - 50;
                        if (!(gecici1.Y < 0))
                        {
                            if (sonrakiTus.IsKeyUp(Keys.W))
                            {
                                for (int i = 0; i < liste1.Count; i++)
                                {
                                    gecici = liste1[i];
                                    if (karakterPoz.X == gecici.X && karakterPoz.Y - 50 == gecici.Y)
                                        sayac++;
                                }
                                for (int i = 0; i < listEngel.Count; i++)
                                {
                                    gecici3 = listEngel[i];
                                    if (karakterPoz.X == gecici3.X && karakterPoz.Y - 50 == gecici3.Y)
                                        sayac++;
                                }
                                if (sayac == 0)
                                {
                                    liste1.Add(karakterPoz);
                                    tumEngel.Add(karakterPoz);
                                    oncekiHareket(karakterPoz, liste1.Count, tumEngel.Count);
                                    karakterPoz.Y -= 50;
                                    rsayac = 0;
                                    puansayaci++;
                                   
                                }
                            }
                        }
                    }
                    #endregion
                    #region A
                    if (suankiTus.IsKeyDown(Keys.A))
                    {
                        gecici1.X = karakterPoz.X - 50;
                        if (!(gecici1.X < 0))
                        {
                            if (sonrakiTus.IsKeyUp(Keys.A))
                            {
                                for (int i = 0; i < liste1.Count; i++)
                                {
                                    gecici = liste1[i];
                                    if (karakterPoz.X - 50 == gecici.X && karakterPoz.Y == gecici.Y)
                                        sayac++;
                                }
                                for (int i = 0; i < listEngel.Count; i++)
                                {
                                    gecici3 = listEngel[i];
                                    if (karakterPoz.X - 50 == gecici3.X && karakterPoz.Y == gecici3.Y)
                                        sayac++;
                                }
                                if (sayac == 0)
                                {
                                    liste1.Add(karakterPoz);
                                    tumEngel.Add(karakterPoz);
                                    oncekiHareket(karakterPoz, liste1.Count, tumEngel.Count);
                                    karakterPoz.X -= 50;
                                    rsayac = 0;
                                    puansayaci++;
                                    
                                }
                            }
                        }
                    }
                    #endregion
                    #region S
                    if (suankiTus.IsKeyDown(Keys.S))
                    {
                        gecici1.Y = karakterPoz.Y + 50;
                        if (!(gecici1.Y >= 600))
                        {
                            if (sonrakiTus.IsKeyUp(Keys.S))
                            {
                                for (int i = 0; i < liste1.Count; i++)
                                {
                                    gecici = liste1[i];
                                    if (karakterPoz.X == gecici.X && karakterPoz.Y + 50 == gecici.Y)
                                        sayac++;
                                }
                                for (int i = 0; i < listEngel.Count; i++)
                                {
                                    gecici3 = listEngel[i];
                                    if (karakterPoz.X == gecici3.X && karakterPoz.Y + 50 == gecici3.Y)
                                        sayac++;
                                }
                                if (sayac == 0)
                                {
                                    liste1.Add(karakterPoz);
                                    tumEngel.Add(karakterPoz);
                                    oncekiHareket(karakterPoz, liste1.Count, tumEngel.Count);
                                    karakterPoz.Y += 50;
                                    rsayac = 0;
                                    puansayaci++;
                                   
                                }
                            }
                        }
                    }
                    #endregion
                    #region D
                    if (suankiTus.IsKeyDown(Keys.D))
                    {
                        if (sonrakiTus.IsKeyUp(Keys.D))
                        {
                            gecici1.X = karakterPoz.X + 50;
                            if (!(gecici1.X >= 800))
                            {
                                for (int i = 0; i < liste1.Count; i++)
                                {
                                    gecici = liste1[i];
                                    if (karakterPoz.X + 50 == gecici.X && karakterPoz.Y == gecici.Y)
                                        sayac++;
                                }
                                for (int i = 0; i < listEngel.Count; i++)
                                {
                                    gecici3 = listEngel[i];
                                    if (karakterPoz.X + 50 == gecici3.X && karakterPoz.Y == gecici3.Y)
                                        sayac++;
                                }
                                if (sayac == 0)
                                {
                                    liste1.Add(karakterPoz);
                                    tumEngel.Add(karakterPoz);
                                    oncekiHareket(karakterPoz, liste1.Count, tumEngel.Count);
                                    karakterPoz.X += 50;
                                    rsayac = 0;
                                    puansayaci++;

                                }
                            }
                        }
                    }
                    #endregion
                }
            }
            sonrakiTus = suankiTus;
            base.Update(gameTime);
        }
        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        /// 
        public void formAc()
        {
            Form2 frm = new Form2();
            frm.Show();
        }
        #region Draw
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            if (kazandikmi)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(font,"K A Z A N D I N I Z.Cikmak icin ESC,Devam icin Y", fontV, Color.White);
                spriteBatch.DrawString(fonta,"MURAT DAS-MUHAMMET CAN TONBUL", fontVa, Color.White);
                aaa = false;
                if (!aaa)
                    alkislarlaYasiyorum.Play();
                spriteBatch.End();
                if (suankiTus.IsKeyDown(Keys.Escape))
                    this.Exit();
                if (suankiTus.IsKeyDown(Keys.Y))
                    yenidenBaslat();
            }
            else    if (bittimi)
            {
                spriteBatch.Begin();
                spriteBatch.DrawString(fontb,"Puaniniz="+puansayaci, fontVb, Color.White);
                spriteBatch.DrawString(font,"Oyun bitti,Son Hamleyi Geri Almak icin R'ye \ncikmak icin esc'ye,devam icin Y'ye Basiniz", fontV, Color.White);
                spriteBatch.DrawString(fonta,"MURAT DAS-MUHAMMET CAN TONBUL", fontVa, Color.White);

                               if (!aaa)
                 ibonungercekhayvansesi.Play();  
                aaa = true;
                spriteBatch.End();
                if (suankiTus.IsKeyDown(Keys.Escape))
                    this.Exit();
                if (suankiTus.IsKeyDown(Keys.Y))
                    yenidenBaslat();
            }
            else
            {
                spriteBatch.Begin();
                spriteBatch.Draw(karakter, karakterPoz, Color.White);
                if (liste1 != null)
                {
                    for (int i = 0; i < liste1.Count; i++)
                    {
                        spriteBatch.Draw(gecilenYer, liste1[i], Color.White);
                    }
                }
                if (listEngel != null)
                {
                    for (int i = 0; i < listEngel.Count; i++)
                    {
                        spriteBatch.Draw(engel, listEngel[i], Color.White);
                    }
                }
                spriteBatch.End();
            }
            base.Draw(gameTime);
        }
        #endregion
        #region Fonksiyonlar
        public bool gidecekYerVarmi()
        {
            int deneme = 4;
            if (karakterPoz.X == 0)
                deneme--;
            if (karakterPoz.X == 750)
                deneme--;
            if (karakterPoz.Y == 0)
                deneme--;
            if (karakterPoz.Y == 550)
                deneme--;
            for (int i = 0; i < tumEngel.Count; i++)
            {
                if (
                    (tumEngel[i].X == karakterPoz.X - 50 && tumEngel[i].Y == karakterPoz.Y) ||
                    (tumEngel[i].X == karakterPoz.X + 50 && tumEngel[i].Y == karakterPoz.Y) ||
                    (tumEngel[i].X == karakterPoz.X && tumEngel[i].Y == karakterPoz.Y - 50) ||
                    (tumEngel[i].X == karakterPoz.X && tumEngel[i].Y == karakterPoz.Y + 50))
                {
                    deneme--;
                }
            }
            if (deneme <= 0)
                return false;
            return true;
        }
        public bool kazandikMi()
        {
            if (!gidecekYerVarmi())
            {
                if (192 - tumEngel.Count < 2)
                   return true;
            }
            return false;
        }
        public void yenidenBaslat()
        {
            liste1.Clear();
            listEngel.Clear();
            tumEngel.Clear();
            karakterPoz.X = 750;
            karakterPoz.Y = 550;
            deneme = 0;
            bittimi = false; 
            kazandikmi = false;
            listeyeengelEkle();
            aaa = false;
            puansayaci = 0;
        }
        public void listeyeengelEkle()
        {
            int x;
            int y;
            int pp = 0;
            // a = 0;
            a = 5;
            int o = a;
            for (int i = 0; i < a; i++)
            {
                puansayaci = 0;
                pp = 0;
                do
                    x = rndx.Next(0, 700);
                while (x % 50 != 0);
                do
                    y = rndy.Next(0, 500);
                while (y % 50 != 0);
                gecici2.X = x;
                gecici2.Y = y;
                for (int k = 0; k < listEngel.Count; k++)
                {
                    if ((x == listEngel[k].X + 50 && y == listEngel[k].Y - 50) || (x == listEngel[k].X - 50 && y == listEngel[k].Y - 50) || (x == listEngel[k].X - 50 && y == listEngel[k].Y + 50) || (x == listEngel[k].X + 50 && y == listEngel[k].Y + 50))
                        pp = 1;
                }
                if (pp == 0)
                {
                    listEngel.Add(gecici2);
                    tumEngel.Add(gecici2);
                }
                
            }
        }
        public void oncekiHareket(Vector2 xNesne, int engelsayac, int tumsayac)
        {
            rVector.X = xNesne.X;
            rVector.Y = xNesne.Y;
            geriListe = engelsayac;
            geriTum = tumsayac;

        }
        #endregion

    }
}
