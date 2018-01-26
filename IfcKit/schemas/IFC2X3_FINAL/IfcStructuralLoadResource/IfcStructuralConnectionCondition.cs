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

using BuildingSmart.IFC.IfcMeasureResource;

namespace BuildingSmart.IFC.IfcStructuralLoadResource
{
	[Guid("5757b5f5-4ec7-4c4d-a8b7-79cfc34dac48")]
	public abstract partial class IfcStructuralConnectionCondition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
	
		public IfcStructuralConnectionCondition()
		{
		}
	
		public IfcStructuralConnectionCondition(IfcLabel? __Name)
		{
			this._Name = __Name;
		}
	
		[Description("Optionally defines a name for this connection condition.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
	
	}
	
}
