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

namespace BuildingSmart.IFC.IfcPresentationAppearanceResource
{
	[Guid("cb9d798c-cf5d-4548-871d-319b0320dfed")]
	public partial class IfcCurveStyleFont :
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcCurveStyleFontSelect
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		IfcLabel? _Name;
	
		[DataMember(Order=1)] 
		[Required()]
		[MinLength(1)]
		IList<IfcCurveStyleFontPattern> _PatternList = new List<IfcCurveStyleFontPattern>();
	
	
		public IfcCurveStyleFont()
		{
		}
	
		public IfcCurveStyleFont(IfcLabel? __Name, IfcCurveStyleFontPattern[] __PatternList)
		{
			this._Name = __Name;
			this._PatternList = new List<IfcCurveStyleFontPattern>(__PatternList);
		}
	
		[Description("Name that may be assigned with the curve font.")]
		public IfcLabel? Name { get { return this._Name; } set { this._Name = value;} }
	
		[Description("A list of curve font pattern entities, that contains the simple patterns used for" +
	    " drawing curves. The patterns are applied in the order they occur in the list.")]
		public IList<IfcCurveStyleFontPattern> PatternList { get { return this._PatternList; } }
	
	
	}
	
}
