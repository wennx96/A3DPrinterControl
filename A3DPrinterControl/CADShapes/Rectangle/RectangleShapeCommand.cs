﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace A3DPrinterControl
{
	[DataContract(IsReference = true), KnownType(typeof(RectangleCADShape))]
	public class RectangleShapeCommand : IBindable, IShapeCommand, IInfill
	{
		[DataMember]
		private string _descriptionName = "Rectangle";
		public RectangleShapeCommand()
		{
			Shape = new RectangleCADShape(this);
			RecipeViewItem = Recipe.CreateRecipeViewItem(this, "RectangleShape");
		}

		[OnDeserializing]
		private void OnDeserializing(StreamingContext c)
		{
			RecipeViewItem = Recipe.CreateRecipeViewItem(this, "RectangleShape");
		}

		public string DescriptionName
		{
			get
			{
				return _descriptionName;
			}
			set
			{
				_descriptionName = value;
				OnPropertyChanged("DescriptionName");
			}
		}

		[DataMember]
		public ICADShape Shape { get; private set; }

		public UserControl OptionView => RectangleShapeCommandOptionView.Show(this);

		[DataMember]
		public IActionCommand ParentCommand { get; private set; } = null;

		[DataMember]
		public List<IActionCommand> ChildrenCommands { get; private set; } = null;

		public ListViewItem RecipeViewItem { get; private set; }

		[DataMember]
		public MotionOption MotionOption { get; private set; } = new MotionOption();

		[DataMember]
		public InfillOption InfillOption { get; private set; } = new InfillOption();

		public void OnAdd()
		{
			CADCanvas.AddShape(Shape);
		}

		public void OnCompile()
		{
			
		}

		public void OnMove()
		{
			
		}

		public void OnPause()
		{
			
		}

		public void OnRecipeFinish()
		{
			
		}

		public void OnRecipeStart()
		{
			
		}

		public void OnRecipeStop()
		{
			
		}

		public void OnRemove()
		{
			CADCanvas.RemoveShape(Shape);
		}

		public void OnReset()
		{
			
		}

		public void OnRun()
		{
			
		}

		public void OnStop()
		{
			
		}

		public void OnSelect()
		{
			Shape.OnSelect();
		}

		public void OnDeselect()
		{
			Shape.OnDeselect();
		}
	}
}
