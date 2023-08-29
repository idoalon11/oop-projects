using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03.GarageLogic
{
    public abstract class EnergySource
    {
        private float m_MaxAmount;
        private float m_RemainingEnergyPercentage;

        internal void FillEnergy(float i_AmountToAdd)
        {
            if (this.m_RemainingEnergyPercentage + i_AmountToAdd > this.MaxAmount)
            {
                throw new ValueOutOfRangeException(this.MaxAmount, 0);
            }
            else
            {
                this.m_RemainingEnergyPercentage += i_AmountToAdd;
            }
        }

        public float RemainingEnergyPercentage
        {
            get
            {
                return m_RemainingEnergyPercentage;
            }

            set
            {
                m_RemainingEnergyPercentage = value;
            }
        }

        public float MaxAmount
        {
            get
            {
                return m_MaxAmount;
            }

            set
            {
                m_MaxAmount = value;
            }
        }
    }
}
