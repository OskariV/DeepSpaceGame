using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Units
{
	/// <summary>
	/// Unit base.
	/// </summary>
	public class UnitBase
	{

		private int hitPoints;
		private string unitName;

		/// <summary>
		/// Dont create instances of this. Used as a base for all units.
		/// <see cref="Units.UnitBase"/> class.
		/// </summary>
		/// <param name="unitName">Unit name.</param>
		/// <param name="hitPoints">Hit points.</param>
		public UnitBase (string unitName, int hitPoints)
		{
			this.hitPoints = hitPoints;
			this.unitName = unitName;
		}

		/// <summary>
		/// Gets the hit points.
		/// </summary>
		/// <returns>The hit points.</returns>
		public virtual int GetHitPoints ()
		{
			return this.hitPoints;
		}

		/// <summary>
		/// Sets the hit points.
		/// </summary>
		/// <param name="value">Value.</param>
		public virtual void SetHitPoints (int value)
		{
			this.hitPoints = value;
		}

		/// <summary>
		/// Gets the name of the unit.
		/// </summary>
		/// <returns>The unit name.</returns>
		public virtual string GetUnitName ()
		{
			return this.unitName;
		}
	}
}
