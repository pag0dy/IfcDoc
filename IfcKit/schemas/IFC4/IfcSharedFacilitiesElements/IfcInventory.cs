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

using BuildingSmart.IFC.IfcActorResource;
using BuildingSmart.IFC.IfcCostResource;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcProductExtension;

namespace BuildingSmart.IFC.IfcSharedFacilitiesElements
{
	[Guid("73471cd5-1296-4091-bcc3-f7f5e32ff3de")]
	public partial class IfcInventory : IfcGroup
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcInventoryTypeEnum? _PredefinedType;
	
		[DataMember(Order=1)] 
		IfcActorSelect _Jurisdiction;
	
		[DataMember(Order=2)] 
		ISet<IfcPerson> _ResponsiblePersons = new HashSet<IfcPerson>();
	
		[DataMember(Order=3)] 
		[XmlAttribute]
		IfcDate? _LastUpdateDate;
	
		[DataMember(Order=4)] 
		[XmlElement("IfcCostValue")]
		IfcCostValue _CurrentValue;
	
		[DataMember(Order=5)] 
		[XmlElement("IfcCostValue")]
		IfcCostValue _OriginalValue;
	
	
		[Description("<EPM-HTML>A list of the types of inventories from which that required may be sele" +
	    "cted.\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE Attribute made optional.</b" +
	    "lockquote> \r\n</EPM-HTML>\r\n")]
		public IfcInventoryTypeEnum? PredefinedType { get { return this._PredefinedType; } set { this._PredefinedType = value;} }
	
		[Description("<EPM-HTML>The organizational unit to which the inventory is applicable.</EPM-HTML" +
	    ">")]
		public IfcActorSelect Jurisdiction { get { return this._Jurisdiction; } set { this._Jurisdiction = value;} }
	
		[Description("<EPM-HTML>Persons who are responsible for the inventory.</EPM-HTML>")]
		public ISet<IfcPerson> ResponsiblePersons { get { return this._ResponsiblePersons; } }
	
		[Description("<EPM-HTML> \r\n<p>The date on which the last update of the inventory was carried ou" +
	    "t.</p>\r\n<blockquote class=\"change-ifc2x4\">IFC4 CHANGE Type changed from IfcDateT" +
	    "imeSelect.</blockquote> \r\n</EPM-HTML> \r\n")]
		public IfcDate? LastUpdateDate { get { return this._LastUpdateDate; } set { this._LastUpdateDate = value;} }
	
		[Description("<EPM-HTML>An estimate of the current cost value of the inventory.</EPM-HTML>")]
		public IfcCostValue CurrentValue { get { return this._CurrentValue; } set { this._CurrentValue = value;} }
	
		[Description("<EPM-HTML>An estimate of the original cost value of the inventory.</EPM-HTML>")]
		public IfcCostValue OriginalValue { get { return this._OriginalValue; } set { this._OriginalValue = value;} }
	
	
	}
	
}
