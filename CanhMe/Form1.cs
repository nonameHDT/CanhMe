using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Net;
using System.IO;
using System.Threading;
using Microsoft.Win32;

namespace CanhMe
{
	/*	Author: nonameHDT
	 *	Email: nonameanbu@gmail.com
	 *  Facebook: https://www.facebook.com/hung.de.tien.175
	 *	Release date: 09/09/2016
	 */
    public partial class Form1 : Form
    {
		List<string> lstAgents = new List<string>();
		bool running;

        public Form1()
        {
            InitializeComponent();
			CheckForIllegalCrossThreadCalls = false;
        }


        private void Form1_Load(object sender, EventArgs e)
        {
			lstAgents = new List<string>();
			running = true;

			timer1.Interval = 3600000;
			mnuStart_Click(null, null);
			timer1_Tick(null, null);

			RegistryKey rkApp = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
			rkApp.SetValue("CanhMe", Application.ExecutablePath);
			rkApp.Close();
		}

        private void mnuStart_Click(object sender, EventArgs e)
        {
			timer1.Start();
			running = false;
		}

		private void mnuStop_Click(object sender, EventArgs e)
		{
			timer1.Stop();
			running = false;
		}

		private void mnuRestart_Click(object sender, EventArgs e)
		{
			mnuStop_Click(null, null);
			mnuStart_Click(null, null);
		}

		private void timer1_Tick(object sender, EventArgs e)
		{
			Thread t = new Thread(Run);
			t.IsBackground = true;
			t.Start();
		}

		private void Run()
		{
			this.Hide(); // hide form

			if (File.Exists("agents.txt") && File.Exists("listsites.txt") && File.Exists("folders.txt") && File.Exists("files.txt") && File.Exists("excludes.txt"))
			{
				lstAgents.Clear();
				lstAgents.AddRange(File.ReadAllText("agents.txt").Replace("\r\n", "\n").Split('\n'));
				List<string> lstSites = new List<string>(File.ReadAllText("listsites.txt").Replace("\r\n", "\n").Split('\n'));
				List<string> lstFolders = new List<string>(File.ReadAllText("folders.txt").Replace("\r\n", "\n").Split('\n'));
				List<string> lstFiles = new List<string>(File.ReadAllText("files.txt").Replace("\r\n", "\n").Split('\n'));
				List<string> lstExcludes = new List<string>(File.ReadAllText("excludes.txt").Replace("\r\n", "\n").Split('\n'));
				List<string> lstDownloads = new List<string>(File.ReadAllText("downloads.txt").Replace("\r\n", "\n").Split('\n'));
				
				List<string> lstLinks = new List<string>();

				foreach (string folder in lstFolders)
				{
					if (folder != "")
						lstLinks.Add(folder + "/");
				}

				foreach (string file in lstFiles)
				{
					if (file != "")
						lstLinks.Add(file);
				}


				// now make links
				// and send requests to server
				foreach (string site in lstSites)
				{
					List<string> domainsplit = new List<string>();
					string temp = site;

					/**** abc.com.vn to abc.com.vn.zip abc.com.zip abc.zip ***/
					while (temp.LastIndexOf('.') > 0)
					{
						int position = temp.LastIndexOf('.');
						domainsplit.Add(temp.Substring(0, position) + ".zip");
						domainsplit.Add(temp.Substring(position + 1) + ".zip");
						temp = temp.Substring(0, position);
					} 
					/**************/


					string url = MakeUrl(site);

					if (running)
					{
						foreach (string sub in domainsplit)
						{
							if (!lstExcludes.Contains(url + sub))
							{
								if (CheckUrlExists(url + sub))
								{
									MessageBox.Show("Found: " + url + sub);
								}
							}
						}

						foreach (string link in lstLinks)
						{
							if (!lstExcludes.Contains(url + link))
							{
								if (CheckUrlExists(url + link))
								{
									MessageBox.Show("Found: " + url + link);
								}
							}
						}

						foreach (string download in lstDownloads)
						{
							if (download != "")
							{
								if (!lstExcludes.Contains(url + download))
								{
									if (CheckUrlExists(url + download))
									{
										MessageBox.Show("Found: " + url + download);
										WebClient client = new WebClient();
										client.DownloadFileAsync(new Uri(url + download), site.Replace("\\", "").Replace("/", "") + " " + download);
									}
								}
							}
						}
					}
                    else
                    {
                        return;
                    }
				}
			}
			else
			{
				MessageBox.Show("Missing files.", "!!!!!!!!");
				Application.Exit();
			}
		}

		private string MakeUrl(string url)
		{
			url = url.Trim();

			if (!url.StartsWith("http://") && !url.StartsWith("https://"))
			{
				url = "http://" + url;
			}
			if (!url.EndsWith("/"))
			{
				url = url + "/";
			}

			return url;
		}

		private bool CheckUrlExists(string URL)
		{
			HttpWebRequest request = WebRequest.CreateHttp(URL);
			request.Timeout = 5000;
			request.Method = "GET";
			request.KeepAlive = false;
			request.AllowAutoRedirect = true;
			request.UserAgent = lstAgents[new Random().Next(0, lstAgents.Count - 1)];

			HttpWebResponse response = null;
			try
			{
				response = (HttpWebResponse)request.GetResponse();

				if (response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Found)
				{
					StreamWriter w = new StreamWriter("excludes.txt", true);
					w.WriteLine(URL);
					w.Close();
					response.Close();
					return true;
				}
			}
			catch { }
			if (response != null)
			{
				response.Close();
			}

			return false;
		}

		private void mnuExit_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
	}
}
