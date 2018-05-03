// This file may be edited manually or auto-generated using IfcKit at www.buildingsmart-tech.org.
// IFC content is copyright (C) 1996-2018 BuildingSMART International Ltd.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Xml.Serialization;


namespace BuildingSmart.IFC.IfcKernel
{
	public enum IfcSimplePropertyTemplateTypeEnum
	{
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcPr" +
	    "opertySingleValue</em>.")]
		P_SINGLEVALUE = 1,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcPr" +
	    "opertyEnumeratedValue</em>.")]
		P_ENUMERATEDVALUE = 2,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcPr" +
	    "opertyBoundedValue</em>.")]
		P_BOUNDEDVALUE = 3,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcPr" +
	    "opertyListValue</em>.")]
		P_LISTVALUE = 4,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcPr" +
	    "opertyTableValue</em>.")]
		P_TABLEVALUE = 5,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcPr" +
	    "opertyReferenceValue</em>.")]
		P_REFERENCEVALUE = 6,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcQu" +
	    "antityLength</em>.")]
		Q_LENGTH = 7,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcQu" +
	    "antityArea</em>.")]
		Q_AREA = 8,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcQu" +
	    "antityVolume</em>.")]
		Q_VOLUME = 9,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcQu" +
	    "antityCount</em>.")]
		Q_COUNT = 10,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcQu" +
	    "antityWeight</em>.")]
		Q_WEIGHT = 11,
	
		[Description("The properties defined by this <em>IfcPropertyTemplate</em> are of type <em>IfcQu" +
	    "antityTime</em>.")]
		Q_TIME = 12,
	
	}
}
