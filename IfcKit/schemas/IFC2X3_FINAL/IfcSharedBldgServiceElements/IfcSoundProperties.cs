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
using BuildingSmart.IFC.IfcControlExtension;
using BuildingSmart.IFC.IfcDateTimeResource;
using BuildingSmart.IFC.IfcExternalReferenceResource;
using BuildingSmart.IFC.IfcGeometricConstraintResource;
using BuildingSmart.IFC.IfcGeometryResource;
using BuildingSmart.IFC.IfcKernel;
using BuildingSmart.IFC.IfcMaterialPropertyResource;
using BuildingSmart.IFC.IfcMaterialResource;
using BuildingSmart.IFC.IfcMeasureResource;
using BuildingSmart.IFC.IfcPresentationAppearanceResource;
using BuildingSmart.IFC.IfcProductExtension;
using BuildingSmart.IFC.IfcProfileResource;
using BuildingSmart.IFC.IfcPropertyResource;
using BuildingSmart.IFC.IfcTimeSeriesResource;

namespace BuildingSmart.IFC.IfcSharedBldgServiceElements
{
	[Guid("28b9f074-33d7-4367-9560-a706ea198e5a")]
	public partial class IfcSoundProperties : IfcPropertySetDefinition
	{
		[DataMember(Order=0)] 
		[XmlAttribute]
		[Required()]
		IfcBoolean _IsAttenuating;
	
		[DataMember(Order=1)] 
		[XmlAttribute]
		IfcSoundScaleEnum? _SoundScale;
	
		[DataMember(Order=2)] 
		[Required()]
		IList<IfcSoundValue> _SoundValues = new List<IfcSoundValue>();
	
	
		[Description("If TRUE, values represent sound attenuation. If FALSE, values represent sound gen" +
	    "eration. ")]
		public IfcBoolean IsAttenuating { get { return this._IsAttenuating; } set { this._IsAttenuating = value;} }
	
		[Description("Reference sound scale")]
		public IfcSoundScaleEnum? SoundScale { get { return this._SoundScale; } set { this._SoundScale = value;} }
	
		[Description("Sound values at a specific frequency. There may be cases where less than eight va" +
	    "lues are specified.")]
		public IList<IfcSoundValue> SoundValues { get { return this._SoundValues; } }
	
	
	}
	
}
