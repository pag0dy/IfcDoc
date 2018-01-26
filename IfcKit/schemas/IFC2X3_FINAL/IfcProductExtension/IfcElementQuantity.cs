// This file was automatically generated from IFCDOC at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;

using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcQuantityResource;
using BuildingSmart.IFC.IfcUtilityResource;

namespace BuildingSmart.IFC.IfcProductExtension
{
	[Guid("a7b07360-a4d7-4991-b1f5-b9a68def1659")]
	public partial class IfcElementQuantity : IfcPropertySetDefinition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _MethodOfMeasurement;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcPhysicalQuantity> _Quantities = new HashSet<IfcPhysicalQuantity>();
	
	
		public IfcElementQuantity()
		{
		}
	
		public IfcElementQuantity(IfcGloballyUniqueId __GlobalId, IfcOwnerHistory __OwnerHistory, IfcLabel? __Name, IfcText? __Description, IfcLabel? __MethodOfMeasurement, IfcPhysicalQuantity[] __Quantities)
			: base(__GlobalId, __OwnerHistory, __Name, __Description)
		{
			this._MethodOfMeasurement = __MethodOfMeasurement;
			this._Quantities = new HashSet<IfcPhysicalQuantity>(__Quantities);
		}
	
		[Description(@"<EPM-HTML>Name of the method of measurement used to calculate the element quantity. The method of measurement attribute has to be made recognizable by further agreements.
	
	<BLOCKQUOTE> <FONT COLOR=""#FF0000"" SIZE=""-1"">IFC2x2 Addendum 1 change: The attribute has been changed to be optional </FONT></BLOCKQUOTE>
	</EPM-HTML>")]
		public IfcLabel? MethodOfMeasurement { get { return this._MethodOfMeasurement; } set { this._MethodOfMeasurement = value;} }
	
		[Description("The individual quantities for the element, can be a set of length, area, volume, " +
	    "weight or count based quantities.")]
		public ISet<IfcPhysicalQuantity> Quantities { get { return this._Quantities; } }
	
	
	}
	
}
