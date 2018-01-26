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
	[Guid("fd3317d3-182e-4997-ac65-2a24e7894912")]
	public partial class IfcFillAreaStyle : IfcPresentationStyle,
		BuildingSmart.IFC.IfcPresentationAppearanceResource.IfcPresentationStyleSelect
	{
		[DataMember(Order=0)] 
		[Required()]
		[MinLength(1)]
		ISet<IfcFillStyleSelect> _FillStyles = new HashSet<IfcFillStyleSelect>();
	
	
		public IfcFillAreaStyle()
		{
		}
	
		public IfcFillAreaStyle(IfcLabel? __Name, IfcFillStyleSelect[] __FillStyles)
			: base(__Name)
		{
			this._FillStyles = new HashSet<IfcFillStyleSelect>(__FillStyles);
		}
	
		[Description("The set of fill area styles to use in presenting visible curve segments, annotati" +
	    "on fill areas or surfaces.")]
		public ISet<IfcFillStyleSelect> FillStyles { get { return this._FillStyles; } }
	
	
	}
	
}
