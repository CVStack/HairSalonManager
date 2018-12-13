﻿using HairSalonManager.Model.Repository;
using HairSalonManager.Model.Vo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HairSalonManager.ViewModel
{
    class TimetableViewModel : ViewModelBase
    {
        #region field, property
        readonly TimetableRepository _timetableRepository;

        readonly ReservedServiceRepository _reservedServiceRepository;

        DataTable _dataTable = new DataTable("StyistTimeTable");

        DataRow _row;

        DataColumn _col;

        private int _stylistId;

        public int StylistId
        {
            get { return _stylistId; }
            set {
                _stylistId = value;
                OnPropertyChanged("StylistId");
            }
        }

        private string _stylistName;

        public string StylistName
        {
            get { return _stylistName; }
            set {
                _stylistName = value;
                OnPropertyChanged("StylistName");
            }
        }

        private int _resNum;

        public int ResNum
        {
            get { return _resNum; }
            set {
                _resNum = value;
                OnPropertyChanged("ResNum");
            }
        }

        private DateTime _startAt;

        public DateTime StartAt
        {
            get { return _startAt; }
            set {
                _startAt = value;
                OnPropertyChanged("StartAt");
            }
        }

        private DateTime _endAt;

        public DateTime EndAt
        {
            get { return _endAt; }
            set {
                _endAt = value;
                OnPropertyChanged("EndAt");
            }
        }

        private int _operationTime;

        public int OperationTime
        {
            get { return _operationTime; }
            set {
                _operationTime = value;
                OnPropertyChanged("OperationTime");
            }
        }

        private int _serId;

        public int SerId
        {
            get { return _serId; }
            set {
                _serId = value;
                OnPropertyChanged("SerId");
            }
        }

        private string _serName;

        public string SerName
        {
            get { return _serName; }
            set {
                _serName = value;
                OnPropertyChanged("SerName");
            }
        }

        private string _selectedRow;

        public string SelectedRow
        {
            get { return _selectedRow; }
            set {
                _selectedRow = value;
                OnPropertyChanged("SelectedRow");
            }
        }

        public Command CheckCommand { get; set; }
        #endregion //property

        #region ctor
        public TimetableViewModel(TimetableRepository timetableRepository, ReservedServiceRepository reservedServiceRepository)
        {
            _timetableRepository = timetableRepository;
            _reservedServiceRepository = reservedServiceRepository;
            CheckCommand = new Command(ExecuteCheckMethod, CanExecuteMethod);
        }        
        #endregion

        #region method
        public void CreateTimeTable()
        {
            _row = _dataTable.NewRow();
            _dataTable.Rows.Add(_row);
            
            _col.ColumnName = "StylistName";
            _dataTable.Columns.Add(_col);

            for(int i=0; i<48; i++)
            {
                _col.ColumnName = string.Format("{0} : {1} ", i * 30 / 6, i * 30 % 6);
                _dataTable.Columns.Add(_col);
            }
        }

        public void FillUpTimeTable()
        {
            TimeSpan dateDiff = EndAt - StartAt;
            int diffHour = dateDiff.Hours;
            int diffMinute = dateDiff.Minutes;
            int result = ((diffHour * 60) + diffMinute) / 30;
            int indexNum = (((diffHour * 60) + diffMinute) / 30) + 1;

            if (_col.ColumnName==(StartAt.Hour+" : " + StartAt.Minute))
            {
                for(int i=0; i<result; i++)
                {
                    _row[indexNum] = ResNum;
                }
            }
        }
        
        private bool CanExecuteMethod(object arg)
        {
            return true;
        }

        private void ExecuteCheckMethod(object obj)
        {
            _reservedServiceRepository.GetReservedServices(ResNum);
        }
        #endregion
    }
}