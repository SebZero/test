using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SynthetizerLib;

namespace SynthetizerApp
{
    public partial class WaveFormControl : UserControl
    {
        public WaveFormControl()
        {
            InitializeComponent();

            numAmplitude.ValueChanged += numAmplitude_ValueChanged;
            tbAmplitude.ValueChanged += tbAmplitude_ValueChanged;
            
            numDuration.ValueChanged += numDuration_ValueChanged;
            tbDuration.ValueChanged += tbDuration_ValueChanged;
            
            numFrequency.ValueChanged += numFrequency_ValueChanged;
            tbFrequency.ValueChanged += tbFrequency_ValueChanged;

            _changingFreq = false;
            _changingAmp = false;
            _changingDuration = false;

            Amplitude = 15000;
            Duration = 1000;
            Frequency = 440;

            _fireEvent = true;

        }

        public event EventHandler AmplitudeChanged;
        public event EventHandler DurationChanged;
        public event EventHandler FrequencyChanged;


        private bool _fireEvent = false;

        private Oscillator _form = null;

        public void SetForm(Oscillator form)
        {
            _fireEvent = false;

            _form = form;

            Amplitude = form.Amplitude;
            Duration = form.Duration;
            Frequency = (int)form.Frequency;

            _fireEvent = true;

        }

        private int _amplitude;

        public int Amplitude
        {
            get { return _amplitude; }
            set { _amplitude = value; OnAmplitudeChanged(); }
        }


        private int _duration;

        public int Duration
        {
            get { return _duration; }
            set { _duration = value; OnDurationChanged(); }
        }

        private int _frequency;

        public int Frequency
        {
            get { return _frequency; }
            set { _frequency = value; OnFrequencyChanged(); }
        }


        private void OnAmplitudeChanged()
        {
            numAmplitude.Value = _amplitude;
            if (_form != null)
                _form.Amplitude = _amplitude;

            if (!_fireEvent)
                return;

            if (AmplitudeChanged != null)
                AmplitudeChanged.Invoke(this, null);
        }

        private void OnDurationChanged()
        {
            numDuration.Value = _duration;
            if (_form != null)
                _form.Duration = _duration;

            if (!_fireEvent)
                return;

            if (DurationChanged != null)
                DurationChanged.Invoke(this, null);
        }

        private void OnFrequencyChanged()
        {
            numFrequency.Value = _frequency;
            if (_form != null)
                _form.Frequency = _frequency;

            if (!_fireEvent)
                return;

            if (FrequencyChanged != null)
                FrequencyChanged.Invoke(this, null);
        }

        private bool _allowChangeDuration = true;

        public bool AllowChangeDuration
        {
            get { return _allowChangeDuration; }
            set { _allowChangeDuration = value; OnAllowChangeDurationChanged(); }
        }

        private void OnAllowChangeDurationChanged()
        {
            tbDuration.Enabled = _allowChangeDuration;
            numDuration.Enabled = _allowChangeDuration;
        }


        private bool _changingFreq = true;
        private void numFrequency_ValueChanged(object sender, EventArgs e)
        {
            if (!_changingFreq)
            {
                _changingFreq = true;
                tbFrequency.Value = (int)numFrequency.Value;
                Application.DoEvents();
                _changingFreq = false;
            }
            _frequency = (int)numFrequency.Value;
            if (_form != null)
                _form.Frequency = _frequency;
        }

        private void tbFrequency_ValueChanged(object sender, EventArgs e)
        {
            if (!_changingFreq)
            {
                _changingFreq = true;
                numFrequency.Value = tbFrequency.Value;
                Application.DoEvents();
                _changingFreq = false;
            }
            _frequency = tbFrequency.Value;
            if (_form != null)
                _form.Frequency = _frequency;
        }

        private bool _changingAmp = true;

        private void tbAmplitude_ValueChanged(object sender, EventArgs e)
        {
            if (!_changingAmp)
            {
                _changingAmp = true;
                numAmplitude.Value = tbAmplitude.Value;
                Application.DoEvents();
                _changingAmp = false;
            }
            _amplitude = tbAmplitude.Value;
            if (_form != null)
                _form.Amplitude = _amplitude;
        }

        private void numAmplitude_ValueChanged(object sender, EventArgs e)
        {
            if (!_changingAmp)
            {
                _changingAmp = true;
                tbAmplitude.Value = (int)numAmplitude.Value;
                Application.DoEvents();
                _changingAmp = false;
            }
            _amplitude = (int)numAmplitude.Value;
            if (_form != null)
                _form.Amplitude = _amplitude;
        }

        private bool _changingDuration = true;

        private void numDuration_ValueChanged(object sender, EventArgs e)
        {
            if (!_changingDuration)
            {
                _changingDuration = true;
                tbDuration.Value = (int)numDuration.Value;
                Application.DoEvents();
                _changingDuration = false;
            }
            _duration = (int)numDuration.Value;
            if (_form != null)
                _form.Duration = _duration;
        }

        private void tbDuration_ValueChanged(object sender, EventArgs e)
        {
            if (!_changingDuration)
            {
                _changingDuration = true;
                numDuration.Value = tbDuration.Value;
                Application.DoEvents();
                _changingDuration = false;
            }
            _duration = (int)tbDuration.Value;
            if (_form != null)
                _form.Duration = _duration;
        }
        

    }
}
