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

namespace BuildingSmart.IFC.IfcExternalReferenceResource
{
	[Guid("9a3e1026-c1d1-44fe-ab77-8497972584e4")]
	public abstract partial class IfcResourceLevelRelationship
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcText? _Description;
	
	
		public IfcResourceLevelRelationship()
		{
		}
	
		public IfcResourceLevelRelationship(IfcLabel? __Name, IfcText? __Description)
		{
			this._Name = __Name;
			this._Description = __Description;
		}
	
		[Description("A name used to identify or qualify the relationship.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("A description that may apply additional information about the relationship.")]
		public IfcText? Description { get { return this._Description; } set { this._Description = value;} }
	
	
	}
	
}
