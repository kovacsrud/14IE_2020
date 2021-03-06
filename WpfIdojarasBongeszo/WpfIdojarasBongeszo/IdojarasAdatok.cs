﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfIdojarasBongeszo
{
    public class IdojarasAdatok
    {
        private List<IdojarasAdat> idojarasadatok;

        public IdojarasAdatok(string fajl)
        {
            idojarasadatok = new List<IdojarasAdat>();
            try
            {
                var sorok = File.ReadAllLines(fajl,Encoding.Default);
                for (int i = 1; i < sorok.Length; i++)
                {
                    var e = sorok[i].Split(';');
                    idojarasadatok.Add(
                        new IdojarasAdat
                        {
                            Ev=Convert.ToInt32(e[0]),
                            Honap=Convert.ToInt32(e[1]),
                            Nap=Convert.ToInt32(e[2]),
                            Ora=Convert.ToInt32(e[3]),
                            Homerseklet=Convert.ToDouble(e[4]),
                            Szelsebesseg=Convert.ToDouble(e[5]),
                            Paratartalom=Convert.ToDouble(e[6])
                        }
                        );
                }
                Debug.WriteLine(idojarasadatok.Count);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Hiba!", MessageBoxButton.OK, MessageBoxImage.Error);                
            }

        }

        public List<int> GetEvek()
        {
            List<int> evek = new List<int>();

            var eveklookup = idojarasadatok.ToLookup(x => x.Ev).OrderBy(x=>x.Key);

            foreach (var i in eveklookup)
            {
                evek.Add(i.Key);
            }

            return evek;
        }

        public List<int> GetHonapok(int ev)
        {
            List<int> honapok = new List<int>();
            var evadatok = GetGridAdatok(ev);
            var evlookup = evadatok.ToLookup(x => x.Honap).OrderBy(x => x.Key);
            foreach (var i in evlookup)
            {
                honapok.Add(i.Key);
            }
            return honapok;
        }

        public List<int> GetNapok(int ev,int honap)
        {
            List<int> napok = new List<int>();
            var honapadatok = GetGridAdatok(ev, honap);
            var honaplookup = honapadatok.ToLookup(x => x.Nap).OrderBy(x => x.Key);
            foreach (var i in honaplookup)
            {
                napok.Add(i.Key);
            }
            return napok;
        }

        public IOrderedEnumerable<IdojarasAdat> GetGridAdatok(int ev)
        {
            var adatok = idojarasadatok.FindAll(x=>x.Ev==ev).OrderBy(x=>x.Honap).ThenBy(x=>x.Nap).ThenBy(x=>x.Ora);
            return adatok;
        }

        public IOrderedEnumerable<IdojarasAdat> GetGridAdatok(int ev,int honap)
        {
            var adatok = idojarasadatok.FindAll(x => x.Ev == ev && x.Honap==honap).OrderBy(x => x.Honap).ThenBy(x => x.Nap).ThenBy(x => x.Ora);
            return adatok;
        }
        
        public IOrderedEnumerable<IdojarasAdat> GetGridAdatok(int ev,int honap,int nap)
        {
            var adatok = idojarasadatok.FindAll(x => x.Ev == ev && x.Honap == honap && x.Nap==nap).OrderBy(x => x.Honap).ThenBy(x => x.Nap).ThenBy(x => x.Ora);
            return adatok;
        }
    }
}
