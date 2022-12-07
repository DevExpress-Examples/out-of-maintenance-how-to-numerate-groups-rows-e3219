using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DevExpress.Web;
using System.Data;

public partial class _Default : System.Web.UI.Page {
	private List<int> groupIndexes = new List<int>();
	int rowInGroupNumber = 1;
	bool isFirstDisplayedRow = true;

	private bool IsGridUngrouped { get { return groupIndexes.Count == 0; } }

	protected void grid_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridViewColumnDisplayTextEventArgs e) {
		if (e.Column.Name != "RowNumber")
			return;

		ASPxGridView g = sender as ASPxGridView;

		if (IsGridUngrouped)
			rowInGroupNumber = e.VisibleRowIndex + 1;
		else {
			if (isFirstDisplayedRow) {
				rowInGroupNumber = e.VisibleRowIndex - GetParentGroupIndex(e.VisibleRowIndex);
				isFirstDisplayedRow = false;
			}
			else {
				if (IsRowIsFirstGroup(e.VisibleRowIndex))
					rowInGroupNumber = 1;
				else
					rowInGroupNumber++;
			}
		}
		e.Value = rowInGroupNumber;
		e.DisplayText = rowInGroupNumber.ToString();
	}
	protected void grid_BeforeGetCallbackResult(object sender, EventArgs e) {
		CollectGroupIndexes();
	}

	private void CollectGroupIndexes() {
		groupIndexes.Clear();
		for (int i = 0; i < grid.VisibleRowCount; i++) {
			if (grid.IsGroupRow(i))
				groupIndexes.Add(i);
		}
	}
	private int GetParentGroupIndex(int index) {
		return groupIndexes.FindLast(delegate(int i) { return i < index; });
	}

	private bool IsRowIsFirstGroup(int index) {
		return grid.IsGroupRow(index - 1);
	}
}