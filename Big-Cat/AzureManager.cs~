﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;

namespace BigCat
{
    public class AzureManager
    {

        private static AzureManager instance;
        private MobileServiceClient client;
        private IMobileServiceTable<BigCatorNotModel> BigCatorNotTable;

        private AzureManager()
        {   
            this.client = new MobileServiceClient("http://bigcat-ornot.azurewebsites.net");
            this.BigCatorNotTable = this.client.GetTable<BigCatorNotModel>();
        }

        public MobileServiceClient AzureClient
        {
            get { return client; }
        }

        public static AzureManager AzureManagerInstance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AzureManager();
                }

                return instance;
            }
        }
        public async Task<List<BigCatorNotModel>> GetBigCatorNot()
        {
            return await this.BigCatorNotTable.ToListAsync();
        }
	public async Task PostBigCatorNot(BigCatorNotModel bigCatorNotModel)
		{
			await this.BigCatorNotTable.InsertAsync(bigCatorNotModel);
		}
    }
}